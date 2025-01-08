using System.Collections.Generic;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  public sealed class QuestFeathermoon : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private readonly Capital _feathermoon; // Reference to the capital Feathermoon unit

    public QuestFeathermoon(Rectangle questRect, Capital feathermoon) : base("Shores of Feathermoon",
      "Feathermoon Stronghold will undoubtedly fall to the assault of the Old gods, we will need to restore it.",
      @"ReplaceableTextures\CommandButtons\BTNBearDen.blp")
    {
     
      _feathermoon = feathermoon;
      AddObjective(new ObjectiveBuildUniqueBuildingsInRect(questRect, "in Feathermoon", 3));
      AddObjective(new ObjectiveControlPoint(UNIT_N05U_FEATHERMOON_STRONGHOLD, 900));
      ResearchId = UPGRADE_R06M_QUEST_COMPLETED_SHORES_OF_FEATHERMOON;

      // Prepare units for rescue excluding the capital
      _rescueUnits = Regions.FeathermoonUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures, unit => unit != feathermoon.Unit);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      // Include the capital unit in the rescue group
      _rescueUnits.Add(_feathermoon.Unit);
      completingFaction.Player.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      // Include the capital unit in the rescue group
      _rescueUnits.Add(_feathermoon.Unit);
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "Feathermoon Stronghold has been restored and has joined the Sentinels in their war effort";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Learn to train Maiev from the {GetObjectName(UNIT_E00R_ALTAR_OF_WATCHERS_SENTINEL_ALTAR)}";
  }
}
