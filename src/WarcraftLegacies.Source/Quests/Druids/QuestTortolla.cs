using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Druids
{
  public sealed class QuestTortolla : QuestData
  {
    private static readonly int HeroId = FourCC("H04U");
    private readonly unit _sleepingTortolla;

    public QuestTortolla() : base("The Turtle Demigod",
      "Tortolla was badly wounded during the War of the Ancients, and has been resting ever since.",
      "ReplaceableTextures\\CommandButtons\\BTNSeaTurtleGreen.blp")
    {
      AddObjective(new ObjectiveTime(1200));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = FourCC("R049");

      _sleepingTortolla = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), HeroId, -12827, 5729, 333);
      SetUnitInvulnerable(_sleepingTortolla, true);
      AddSpecialEffectTarget("Abilities\\Spells\\Undead\\Sleep\\SleepTarget.mdl", _sleepingTortolla,
        "overhead");
      SetHeroXP(_sleepingTortolla, LegendDruids.LegendTortolla.StartingXp, false);
    }

    protected override string CompletionPopup => "Tortolla has finally awoken from his ancient slumber.";

    protected override string RewardDescription => "You can summon Tortolla from the Altar of Elders";

    protected override void OnComplete(Faction completingFaction)
    {
      RemoveUnit(_sleepingTortolla);
    }

    protected override void OnFail(Faction completingFaction)
    {
      RemoveUnit(_sleepingTortolla);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(HeroId, 1);
    }
  }
}