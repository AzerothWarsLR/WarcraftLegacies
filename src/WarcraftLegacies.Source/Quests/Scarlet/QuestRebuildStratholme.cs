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

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  /// <summary>
  /// Rebuild Stratholme and get a bunch of exp on Saiden.
  /// </summary>
  public sealed class QuestRebuildStratholme : QuestData
  {
    private readonly LegendaryHero _saiden;
    private const int ExperienceReward = 6000;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildStratholme"/> class.
    /// </summary>
    public QuestRebuildStratholme(Rectangle questRect, LegendaryHero saiden) : base(
      "Reclaiming Stratholme",
      "Saiden was the lord of Satratholme before the plague. He now wants to reconquer it, rebuild it and re-establish it's old glory",
      @"ReplaceableTextures\CommandButtons\BTNStromgardeCastle.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "in Stratholme", Constants.UNIT_H0BM_TOWN_HALL_CRUSADE_T1, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Stratholme", Constants.UNIT_H0BP_HOUSEHOLD_CRUSADE_FARM, 6));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Stratholme", Constants.UNIT_H0AG_HALL_OF_SWORDS_CRUSADE_BARRACKS, 2));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Stratholme", Constants.UNIT_H09X_SHIPYARD_CRUSADE_SHIPYARD, 1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Stratholme", Constants.UNIT_N0D8_TRADE_HOUSE_CRUSADE_SHOP, 1));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01M_STRATHOLME), 4));
      _saiden = saiden;
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      _saiden.Unit?.AddExperience(ExperienceReward);
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "Saiden, the new Lord of Stratholme, has managed to regain, purge and rebuild the once mighty city of Stratholme.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Saiden Dathrohan gains {ExperienceReward} experience";
  }
}