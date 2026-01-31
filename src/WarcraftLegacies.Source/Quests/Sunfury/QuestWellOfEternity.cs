using MacroTools.FactionSystem;
using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Sunfury;

public sealed class QuestWellOfEternity : QuestData
{
  private readonly unit _well;

  public QuestWellOfEternity(LegendaryHero kiljaeden) : base(
    "The Well of Eternity",
    "The Maelstrom still hides the shattered Well of Eternity. With his immense power, Kil'jaeden can summon a new well that will bring forth the destruction of the world.",
    @"ReplaceableTextures\CommandButtons\BTNFountainOfLife.blp")
  {
    _well = PreplacedWidgets.Units.Get(UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_OTHER);
    _well.IsVisible = false;
    AddObjective(new ObjectiveChannelRect(Regions.MaelstromChannel, "The Maelstrom", kiljaeden, 420, 90, Title));
    Global = true;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Kil'jaeden has reformed the ancient Well of Eternity. From its wellsprings, unlimited arcane energies spring forth. For the first time in their miserable existences, the Sunfury are truly sated.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Gain control of the Well of Eternity, which will grant every Sunfury unit unlimited mana";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    _well.IsVisible = true;
    _well.SetOwner(completingFaction.Player);
  }
}
