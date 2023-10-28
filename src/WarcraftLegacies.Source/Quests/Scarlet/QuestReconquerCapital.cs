using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  /// <summary>
  /// Recapture Capital and rebuild it to empower all your heroes.
  /// </summary>
  public sealed class QuestReconquerCapital : QuestData
  {
    private readonly LegendaryHero _saiden;
    private readonly LegendaryHero _renault;
    private readonly LegendaryHero _sally;
    private readonly LegendaryHero _brigitte;
    private const int ExperienceReward = 2000;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestReconquerCapital"/> class.
    /// </summary>
    public QuestReconquerCapital(Rectangle questRect, Capital capitalPalace, LegendaryHero saiden, LegendaryHero renault, LegendaryHero sally, LegendaryHero brigitte) : base(
      "Reconquer Capital",
      "Lordaeron City was almost completly destroyed by the scourge, it would be a symbol for the Scarlet Crusade if they could recapture it and rebuild it!",
      @"ReplaceableTextures/CommandButtons/BTNStromgardeAltar.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "in Lordaeron City", Constants.UNIT_H0BP_FARMSTEAD_CRUSADE_FARM, 4));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Lordaeron City", Constants.UNIT_H0AG_HALL_OF_SWORDS_CRUSADE_BARRACKS));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Lordaeron City", Constants.UNIT_H0BQ_ALTAR_OF_CRUSADERS_CRUSADE_ALTAR));
      AddObjective(new ObjectiveControlCapital(capitalPalace, false));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01G_LORDAERON_CITY), 4));
      _saiden = saiden;
      _renault = renault;
      _sally = sally;
      _brigitte = brigitte;
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      _saiden.Unit?.AddExperience(ExperienceReward);
      _renault.Unit?.AddExperience(ExperienceReward);
      _sally.Unit?.AddExperience(ExperienceReward);
      _brigitte.Unit?.AddExperience(ExperienceReward);
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "Reconquering and rebuilding the Capital of Lordaeron has inspired and legitimized the Scarlet in the eye of all the surviving humen of Lordaeron";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "All of your heroes gain {ExperienceReward} experience";
  }
}