using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>A Wildhammer unit must kill Mal'Ganis or Tichondrius, sharpening the gryphon riders against the dark.</summary>
public sealed class QuestTheHammerFalls : QuestData
{
  public QuestTheHammerFalls(LegendaryHero malganis, LegendaryHero tichondrius) : base("The Hammer Falls",
    "The dreadlords lead the Scourge and the Burning Legion against the living. Strike one of them down with Wildhammer steel, and every gryphon rider will learn how to kill the dark.",
    @"ReplaceableTextures\CommandButtons\BTNStormHammer.blp")
  {
    AddObjective(new ObjectiveEitherOf(
      new ObjectiveLegendKilledBy(malganis, "a Wildhammer unit", IsWildhammer),
      new ObjectiveLegendKilledBy(tichondrius, "a Wildhammer unit", IsWildhammer)));
    ResearchId = UPGRADE_R11A_THE_HAMMER_FALLS_WILDHAMMER;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "A dreadlord has fallen to the Wildhammer, and the gryphon riders now know how to fight the dark.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Gryphon Riders, Gryphons, Soarers, Cloud Guardians, Aerie Riders and Sharpbeak deal 15% more damage to undead units and to the Burning Legion";

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);

  private static bool IsWildhammer(player whichPlayer) => whichPlayer.GetPlayerData().Faction is WildhammerFaction;
}
