using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  /// <summary>
  /// Rebuild Brill to buff Renault.
  /// </summary>
  public sealed class QuestRebuildBrill : QuestData
  {
    private readonly LegendaryHero _renault;
    private const int ExperienceReward = 6000;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildBrill"/> class.
    /// </summary>
    public QuestRebuildBrill(Rectangle questRect, LegendaryHero renault) : base(
      "Rebuild Brill",
      "Brill is the hometown of Renault, saving it would make him happy and motivated. It was one of the first town ravaged by the undead.",
      @"ReplaceableTextures\CommandButtons\BTNStromgardeFarm.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_H0BM_TOWN_HALL_CRUSADE_T1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_H0BP_FARMSTEAD_CRUSADE_FARM, 3));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_H09X_SHIPYARD_CRUSADE_SHIPYARD));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_N0D8_VENDOR_HALL_CRUSADE_SHOP));
      AddObjective(new ObjectiveControlLevel(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N03H_BRILL), 2));
      _renault = renault;
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      _renault.Unit?.AddExperience(ExperienceReward);
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With Brill now rebuilt, Renault shines with a new vigour and motivation to save Lordaeron";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Renault gains {ExperienceReward} experience";
  }
}