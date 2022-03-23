using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Quests.Druids;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestTortolla : QuestData{

  
    private static readonly int HeroId = FourCC("H04U");
  


    static unit SleepingTortolla

    protected override string CompletionPopup => "Tortolla has finally awoken from his ancient slumber.";

    protected override string CompletionDescription => "You can summon Tortolla from the Altar of Elders";

    protected override void OnComplete(){
      RemoveUnit(thistype.sleepingTortolla);
    }

    protected override void OnFail( ){
      RemoveUnit(thistype.sleepingTortolla);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(HeroId, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Turtle Demigod", "Tortolla was badly wounded during the War of the Ancients, && has been resting ever since.", "ReplaceableTextures\\CommandButtons\\BTNSeaTurtleGreen.blp");
      AddQuestItem(new QuestItemTime(1200));
      AddQuestItem(QuestItemSelfExists);
      ResearchId = FourCC("R049");
      
    }


    public static void Setup( ){
      QuestTortolla.SleepingTortolla = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), HeroId, -12827, 5729, 333);
      SetUnitInvulnerable(QuestTortolla.SleepingTortolla, true);
      AddSpecialEffectTarget("Abilities\\Spells\\Undead\\Sleep\\SleepTarget.mdl", QuestTortolla.SleepingTortolla, "overhead");
      SetHeroXP(QuestTortolla.SleepingTortolla, LEGEND_TORTOLLA.StartingXP, false);
    }

  }
}
