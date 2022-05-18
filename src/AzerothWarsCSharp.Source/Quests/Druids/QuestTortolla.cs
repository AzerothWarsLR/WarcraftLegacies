using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestTortolla : QuestData
  {
    private static readonly int HeroId = FourCC("H04U");
    private readonly unit _sleepingTortolla;

    public QuestTortolla() : base("The Turtle Demigod",
      "Tortolla was badly wounded during the War of the Ancients, and has been resting ever since.",
      "ReplaceableTextures\\CommandButtons\\BTNSeaTurtleGreen.blp")
    {
      AddQuestItem(new QuestItemTime(1200));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R049");

      _sleepingTortolla = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), HeroId, -12827, 5729, 333);
      SetUnitInvulnerable(_sleepingTortolla, true);
      AddSpecialEffectTarget("Abilities\\Spells\\Undead\\Sleep\\SleepTarget.mdl", _sleepingTortolla,
        "overhead");
      SetHeroXP(_sleepingTortolla, LegendDruids.LegendTortolla.StartingXp, false);
    }

    protected override string CompletionPopup => "Tortolla has finally awoken from his ancient slumber.";

    protected override string RewardDescription => "You can summon Tortolla from the Altar of Elders";

    protected override void OnComplete()
    {
      RemoveUnit(_sleepingTortolla);
    }

    protected override void OnFail()
    {
      RemoveUnit(_sleepingTortolla);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(HeroId, 1);
    }
  }
}