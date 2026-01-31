using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Quelthalas;

/// <summary>
/// Quel'thalas either wins or loses their duel to get Blood Mages and some other stuff.
/// </summary>
public sealed class QuestTheBloodElves : QuestData
{
  private const int UnittypeId = UNIT_N048_BLOOD_MAGE_QUELTHALAS;
  private const int BuildingId = UNIT_N0A2_CONSORTIUM_QUELTHALAS_SIEGE;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestTheBloodElves"/> class.
  /// </summary>
  public QuestTheBloodElves(Capital draktharonKeep) : base("The Blood Elves",
    "The Elves of Quel'thalas have a deep reliance on the Sunwell's magic. But perhaps in these dark times, they might turn to darker magicks to sate themselves.",
    @"ReplaceableTextures\CommandButtons\BTNHeroBloodElfPrince.blp")

  {
    ResearchId = UPGRADE_R04Q_QUEST_COMPLETED_THE_BLOOD_ELVES_QUEL_THALAS;
    AddObjective(new ObjectiveControlCapital(draktharonKeep, false));
    AddObjective(new ObjectiveControlLevel(UNIT_N030_DRAK_THARON_KEEP, 10));
  }


  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Legion Nexus has been obliterated. A group of ambitious mages seize the opportunity to study the demons' magic, becoming the first Blood Mages.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    $"Learn to train {GetObjectName(UnittypeId)}s from the Consortium, and you can summon Magister Rommath & Lor'themar Theron from the Altar of Prowess";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player?.DisplayUnitTypeAcquired(UnittypeId,
      $"You can now train {GetObjectName(UnittypeId)}s from the {GetObjectName(BuildingId)}.");
  }
}
