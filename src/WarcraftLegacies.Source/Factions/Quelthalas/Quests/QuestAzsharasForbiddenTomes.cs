using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Quelthalas.Quests;

/// <summary>Roleplay replacement for <see cref="QuestQueensArchive"/>, told from the high elves' side.</summary>
public sealed class QuestAzsharasForbiddenTomes : QuestData
{
  public QuestAzsharasForbiddenTomes(LegendaryHero rommath) : base("Azshara's Forbidden Tomes",
    "The high elves descend from the Highborne of Queen Azshara's court. Her sunken library at Nazjatar holds magic the quel'dorei swore to forget when they left Kalimdor. In these desperate times, Magister Rommath would reclaim it, whatever the cost.",
    @"ReplaceableTextures\CommandButtons\BTNBloodElfWizard.blp")
  {
    AddObjective(new ObjectiveControlLevel(UNIT_N04Y_NAZJATAR, 8));
    AddObjective(new ObjectiveChannelRect(Regions.Nazjatar, "Nazjatar", rommath, 80, 270));
    ResearchId = UPGRADE_R075_QUEST_COMPLETED_THE_QUEEN_S_ARCHIVE_OR_AZSHARA_S_FORBIDDEN_TOMES;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "A circle of magisters pores over Azshara's forbidden tomes and learns to bind demons to their will, becoming the first elven Warlocks.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    Loc.Format("You can now train {unit}s at the {building}",
      ("{unit}", GetObjectName(UNIT_N02F_WARLOCK_QUELTHALAS)),
      ("{building}", GetObjectName(UNIT_N0A2_CONSORTIUM_QUELTHALAS_SIEGE)));
}
