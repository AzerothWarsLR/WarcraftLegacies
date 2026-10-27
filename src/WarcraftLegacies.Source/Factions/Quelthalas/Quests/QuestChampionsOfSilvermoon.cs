using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Quelthalas.Quests;

/// <summary>Roleplay replacement for <see cref="QuestTheBloodElves"/> that unlocks Rommath and Lor'themar without Blood Mages.</summary>
public sealed class QuestChampionsOfSilvermoon : QuestData
{
  public QuestChampionsOfSilvermoon(Capital draktharonKeep) : base("Champions of Silvermoon",
    "The finest of Silvermoon will only march once the elves prove they can strike beyond the runestones. Seize Drak'Tharon Keep, stronghold of the Drakkari trolls, and break the old troll alliance that has threatened Quel'thalas for millennia.",
    @"ReplaceableTextures\CommandButtons\BTNLorthemarv1.blp")
  {
    ResearchId = UPGRADE_R04Q_QUEST_COMPLETED_THE_BLOOD_ELVES_OR_CHAMPIONS_OF_SILVERMOON_QUEL_THALAS;
    AddObjective(new ObjectiveControlCapital(draktharonKeep, false));
    AddObjective(new ObjectiveControlLevel(UNIT_N030_DRAK_THARON_KEEP, 10));
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "With Drak'Tharon fallen, the trolls' ancient alliance lies broken. Ranger-Captain Lor'themar Theron and Magister Rommath step forward to lead the armies of Silvermoon.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    Loc.Format("You can summon Magister Rommath & Lor'themar Theron from the {altar}",
      ("{altar}", GetObjectName(UNIT_H01H_ALTAR_OF_PROWESS_QUELTHALAS_ALTAR)));
}
