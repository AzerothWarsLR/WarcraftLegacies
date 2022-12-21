using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Objectives;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// The Draenei acquire some kind of power source to power their ship.
  /// </summary>
  public class QuestDimensionalShip : QuestData
  {
    private readonly ObjectivePowerSource _objectivePowerSource;
    private readonly unit _dimensionalGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestDimensionalShip"/> class.
    /// </summary>
    public QuestDimensionalShip(Rectangle questRect, PreplacedUnitSystem preplacedUnitSystem) : base(
      "The Dimensional Ship", "The broken Exodar could be rebuild, unlocking a powerful asset for the Draenei.", "")
    {
      _dimensionalGenerator = preplacedUnitSystem.GetUnit(Constants.UNIT_N00E_DIMENSIONAL_GENERATOR_DRAENEI);
      Required = true;
      AddObjective(
        new ObjectiveBuildInRect(questRect, "inside the Exodar", Constants.UNIT_O056_ARCANE_WELL_DRAENEI, 10));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0BL_EXODAR_REGALIS_25GOLD_MIN), 20));
      AddObjective(
        new ObjectiveUnitReachesFullHealth(
          preplacedUnitSystem.GetUnit(Constants.UNIT_N00E_DIMENSIONAL_GENERATOR_DRAENEI)));
      _objectivePowerSource = new ObjectivePowerSource(_dimensionalGenerator, new[]
      {
        Constants.ITEM_I006_BOOK_OF_MEDIVH,
        Constants.ITEM_I003_EYE_OF_SARGERAS,
        Constants.ITEM_I011_CROWN_OF_THE_TRIUMVIRATE,
        Constants.ITEM_I018_VIAL_OF_THE_SUNWELL
      });
      AddObjective(_objectivePowerSource);

      ResearchId = Constants.UPGRADE_R09A_QUEST_COMPLETED_THE_DIMENSIONAL_SHIP;
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      _objectivePowerSource.UsedPowerSource?.SetDroppable(false);
      CreateTrigger()
        .RegisterUnitEvent(_dimensionalGenerator, EVENT_UNIT_DEATH)
        .AddAction(() => { _objectivePowerSource.UsedPowerSource?.SetDroppable(true); });
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "TODO";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "The Exodar gains the ability to teleport, but the power source used is locked within the Dimensional Generator";
  }
}