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

    public QuestAstranaar(List<Rectangle> rescueRects, LegendaryHero tyrande) : base("Astranaar Stronghold",
      "Darkshore is under attack by some Murloc. We should deal with them swiftly and make for the Astranaar Outpost. Clearing the Murlocs will also reestablish communication with Darnassus.",
      "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp")
    {
      AddObjective(new ObjectiveLegendReachRect(tyrande, Regions.AstranaarUnlock,
        "Astranaar Outpost"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N02U_DARKSHORE_10GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1430));
      AddObjective(new ObjectiveSelfExists());

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
      "Astranaar has been relieved and has joined the Sentinels in their war effort";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units in Astranaar Outpost and Darnassus";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
      completingFaction.Player?.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 200);
      completingFaction.Player?.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 100);
    }
  }
}