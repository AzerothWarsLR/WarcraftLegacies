using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Quests;

/// <summary>Arthas defiles the Sunwell, unlocking the Boneyard and its Obsidian Destroyers.</summary>
public sealed class QuestKeyOfTheThreeMoons : QuestData
{
  private const int DestroyerLimit = 4;

  public QuestKeyOfTheThreeMoons(Capital sunwell, LegendaryHero arthas) : base("The Key of the Three Moons",
    "The Sunwell is the beating heart of Quel'thalas, a font of arcane power older than any kingdom of men. March Arthas through the Elfgates and claim it, and its defiled energies will give rise to horrors far greater than any the Scourge has wielded.",
    @"ReplaceableTextures\CommandButtons\BTNDestroyer.blp")
  {
    AddObjective(new ObjectiveControlCapital(sunwell, false));
    AddObjective(new ObjectiveLegendInRect(arthas, Regions.Sunwell, "The Sunwell"));
    ResearchId = UPGRADE_R107_QUEST_COMPLETED_THE_KEY_OF_THE_THREE_MOONS_FALLENPRINCE;
    Global = true;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Arthas has defiled the Sunwell, its light guttering before the chill of Frostmourne. From its tainted magic, the Fallen Prince's servants have begun to forge new horrors of obsidian and bone.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "Learn to build the {boneyard} and train up to {limit} {destroyer}s from it",
    ("{boneyard}", GetObjectName(UNIT_UBON_BONEYARD_SCOURGE_SIEGE)),
    ("{limit}", DestroyerLimit.ToString()),
    ("{destroyer}", GetObjectName(UNIT_UBSP_OBSIDIAN_DESTROYER_SCOURGE)));
}
