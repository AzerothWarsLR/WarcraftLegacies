using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  public sealed class QuestAstranaar : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestAstranaar(List<Rectangle> rescueRects, LegendaryHero shandris) : base("Daughters of the Moon",
      "Shandris need to reach the Dark Shore and warn the Sentinels of the Horde invadors",
      "ReplaceableTextures\\CommandButtons\\BTNShandris.blp")
    {
      AddObjective(new ObjectiveLegendReachRect(shandris, Regions.AstranaarUnlock,
        "Astranaar Outpost"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N05N_WINDSHEAR_CROSSING_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01Y_DESOLACE_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N05U_FEATHERMOON_STRONGHOLD_20GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1430, Title));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03N_QUEST_COMPLETED_DAUGHTERS_OF_THE_MOON;

      foreach (var rectangle in rescueRects)
      foreach (var unit in CreateGroup().EnumUnitsInRect(rectangle.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      Required = true;
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "Auberdine has been reached and has joined the Sentinels in their war effort";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units in Astranaar Outpost and Auberdine. Tyrande and Maiev will de trainable at Altar";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
  }
}