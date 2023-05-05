using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using static War3Api.Common;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using System.Collections.Generic;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;

namespace WarcraftLegacies.Source.Quests.Sunfury
{
  /// <summary>
  /// Build various structures inside <see cref="Regions.AzuremystAmbient"/>
  /// </summary>
  public sealed class QuestArea52 : QuestData
  {
    private readonly List<unit> _rescueUnits;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestArea52"/> class.
    /// </summary>
    public QuestArea52(Rectangle rescueRect) : base("The Way Forward", "The Draenei will need to rebuild their civilisation in Azeroth. Desolace seems like a perfect place for the birth of the second Draenei settlement.", "ReplaceableTextures\\CommandButtons\\BTNDraeneiDivineCitadel.blp")
    {
      Required = true;
      AddObjective(new ObjectiveKillAllInArea(new List<Rectangle> { Regions.DraeneiQuestKill }, "in Desolace"));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0BF_ANTORAN_WASTES_10GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1430, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
        whichFaction.Player.AddGold(200);
        whichFaction.Player.AddLumber(200);
      if (whichFaction.Player != null)
        whichFaction.Player.RescueGroup(_rescueUnits);
      else
        Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "Maraad joins the Draenai and the new settlement is born";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain 200 Gold, 200 Lumber, an Outpost in Desolace and Maraad is now trainable at the altar.";

   }
 }