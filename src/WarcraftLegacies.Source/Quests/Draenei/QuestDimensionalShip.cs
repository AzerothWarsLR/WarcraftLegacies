using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Objectives;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Draenei;

/// <summary>
/// The Draenei acquire some kind of power source to power their ship.
/// </summary>
public sealed class QuestDimensionalShip : QuestData
{
  private readonly ObjectivePowerSource _objectivePowerSource;
  private readonly unit _dimensionalGenerator;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestDimensionalShip"/> class.
  /// </summary>
  public QuestDimensionalShip(Rectangle questRect, QuestData prerequisite, Capital dimensionalGenerator) : base(
    "The Dimensional Ship",
    "The core of the Exodar is rebuilt, but it requires a great source of power to function again. Finding that source of power would make the Exodar a powerful asset for the Draenei.",
    @"ReplaceableTextures\CommandButtons\BTNArcaneEnergy.blp")
  {
    _dimensionalGenerator = dimensionalGenerator.Unit;

    AddObjective(new ObjectiveQuestComplete(prerequisite));
    AddObjective(new ObjectiveTime(1200));
    AddObjective(new ObjectiveBuildInRect(questRect, "inside the Exodar", UNIT_O056_ARCANE_WELL_DRAENEI_FARM, 10));
    AddObjective(new ObjectiveControlLevel(UNIT_N0BL_EXODAR_REGALIS, 20));
    _objectivePowerSource = new ObjectivePowerSource(_dimensionalGenerator, new[]
    {
      ITEM_I006_BOOK_OF_MEDIVH,
      ITEM_I003_EYE_OF_SARGERAS,
      ITEM_I011_CROWN_OF_THE_TRIUMVIRATE,
      ITEM_I018_VIAL_OF_THE_SUNWELL,
      ITEM_I00H_SULFURAS_HAND_OF_RAGNAROS,
      ITEM_I01Y_HELM_OF_DOMINATION
    });
    AddObjective(_objectivePowerSource);
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R09A_QUEST_COMPLETED_THE_DIMENSIONAL_SHIP;
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction whichFaction)
  {
    if (_objectivePowerSource.UsedPowerSource != null)
    {
      _objectivePowerSource.UsedPowerSource.IsDroppable = false;
    }

    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(_dimensionalGenerator, unitevent.Death);
    deathTrigger.AddAction(() =>
    {
      if (_objectivePowerSource.UsedPowerSource != null)
      {
        _objectivePowerSource.UsedPowerSource.IsDroppable = true;
      }
    });
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "With the acquisition of a replacement power source, the Exodar's gemcrafters set to work reigniting the ship's dimensional portals. The Dimensional Generator can now now be used to travel the planes once more.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "The Dimensional Generator gains the ability to channel portals to Argus and Outland. The Lightforged units and A'dal will become available";
}
