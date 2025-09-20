using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Scarlet;

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
    "Lordaeron City",
    "Lordaeron City was once the heart of the Alliance and the center of the humanity before its fall. It must be reclaimed at all costs.",
    "ReplaceableTextures/CommandButtons/BTNStromgardeAltar.blp")
  {

    AddObjective(new ObjectiveBuildUniqueBuildingsInRect(questRect, "in Capital City", 3));
    AddObjective(new ObjectiveControlCapital(capitalPalace, false));
    AddObjective(new ObjectiveControlLevel(UNIT_N01G_LORDAERON_CITY, 4));
    _saiden = saiden;
    _renault = renault;
    _sally = sally;
    _brigitte = brigitte;
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction whichFaction)
  {
    if (_saiden.Unit != null)
    {
      AddHeroXP(_saiden.Unit, ExperienceReward, true);
    }

    if (_renault.Unit != null)
    {
      AddHeroXP(_renault.Unit, ExperienceReward, true);
    }

    if (_sally.Unit != null)
    {
      AddHeroXP(_sally.Unit, ExperienceReward, true);
    }

    if (_brigitte.Unit != null)
    {
      AddHeroXP(_brigitte.Unit, ExperienceReward, true);
    }
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Scarlet Crusade has successfully rebuilt Lordaeron City, cementing their position as the rightful successors of Lordaeron's legacy.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"All of your heroes gain {ExperienceReward} experience";
}
