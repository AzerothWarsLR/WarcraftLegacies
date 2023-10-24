using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using MacroTools.LegendSystem;
using WarcraftLegacies.Source.Objectives;
using WCSharp.Shared.Data;
using static War3Api.Common;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;

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
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_H0BM_TOWN_HALL_CRUSADE_T1, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_H0BP_HOUSEHOLD_CRUSADE_FARM, 3));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_H09X_SHIPYARD_CRUSADE_SHIPYARD, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Brill", Constants.UNIT_N0D8_TRADE_HOUSE_CRUSADE_SHOP, 1));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N03H_BRILL), 2));
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