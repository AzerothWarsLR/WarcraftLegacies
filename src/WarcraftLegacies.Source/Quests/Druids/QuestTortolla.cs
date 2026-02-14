using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Quests.Druids;

public sealed class QuestTortolla : QuestData
{
  private const int HeroId = UNIT_H04U_DEMIGOD_DRUIDS;
  private readonly unit _sleepingTortolla;
  private readonly effect _effect;

  public QuestTortolla(LegendaryHero tortolla) : base("The Turtle Demigod",
    "Tortolla was badly wounded during the War of the Ancients, and has been resting ever since.",
    @"ReplaceableTextures\CommandButtons\BTNSeaTurtleGreen.blp")
  {
    AddObjective(new ObjectiveTurn(8));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R049_QUEST_COMPLETED_THE_TURTLE_DEMIGOD;

    var sleepingTurtle = unit.Create(player.NeutralPassive, HeroId, -11315, 9389, 333);
    sleepingTurtle.IsInvulnerable = true;
    _sleepingTortolla = sleepingTurtle;
    AddHeroXP(sleepingTurtle, tortolla.StartingXp, true);
    _effect = effect.Create(@"Abilities\Spells\Undead\Sleep\SleepTarget.mdl", _sleepingTortolla, "overhead");
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "Tortolla has finally awoken from his ancient slumber.";

  /// <inheritdoc/>
  protected override string RewardDescription => "You can summon Tortolla from the Altar of Elders";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    _sleepingTortolla.Dispose();
    _effect.Dispose();
  }

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    _sleepingTortolla.Dispose();
    _effect.Dispose();
  }
}
