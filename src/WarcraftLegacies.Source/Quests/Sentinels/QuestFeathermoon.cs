using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  /// <summary>
  /// Build unique buildings and own the control point to rescue the Feathermoon Stronghold.
  /// </summary>
  public sealed class QuestFeathermoon : QuestData
  {
    private List<unit> _rescueUnits;
    private readonly Capital _feathermoon;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestFeathermoon"/> class.
    /// </summary>
    /// <param name="feathermoon">The Feathermoon Stronghold capital to be associated with this quest.</param>
    /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
    public QuestFeathermoon(Capital feathermoon, Rectangle rescueRect) 
      : base(
        "Shores of Feathermoon",
        "Without aid from the primary Sentinel force, Feathermoon Stronghold will undoubtedly fall to the assault of the Old Gods. We will need to restore it.",
        @"ReplaceableTextures\CommandButtons\BTNBearDen.blp")
    {
      _feathermoon = feathermoon; 

      AddObjective(new ObjectiveBuildUniqueBuildingsInRect(Regions.FeathermoonUnlock, "in Feathermoon", 3));
      AddObjective(new ObjectiveControlPoint(UNIT_N05U_FEATHERMOON));
      ResearchId = UPGRADE_R06M_QUEST_COMPLETED_SHORES_OF_FEATHERMOON;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "The Sentinels have rebuilt Feathermoon Stronghold to its former glory. Maiev Shadowsong now joins their efforts.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Learn to train Maiev Shadowsong from the {GetObjectName(UNIT_E00R_ALTAR_OF_WATCHERS_SENTINEL_ALTAR)} and gain control of the survivors hiding in Feathermoon.";

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      _rescueUnits = Regions.FeathermoonUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      // Rescue units in Feathermoon Unlock.
      completingFaction.Player.RescueGroup(_rescueUnits);
      
      // Restore Feathermoon Stronghold's hit points to 100%.
      if (_feathermoon.Unit != null && GetUnitState(_feathermoon.Unit, UNIT_STATE_LIFE) > 0)
      {
        _feathermoon.Unit.SetLifePercent(100); // Restore life to 100%.
      }
    }

    /// <inheritdoc />
    protected override void OnFail(Faction failingFaction)
    {
      // If players fail, the neutral aggressive faction rescues the units.
      var rescuer = failingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : failingFaction.Player;
      
      rescuer.RescueGroup(_rescueUnits);

      // Restore Feathermoon Stronghold's hit points to 100%.
      if (_feathermoon.Unit != null && GetUnitState(_feathermoon.Unit, UNIT_STATE_LIFE) > 0)
      {
        _feathermoon.Unit.SetLifePercent(100); // Restore life to 100%.
      }
    }
  }
}