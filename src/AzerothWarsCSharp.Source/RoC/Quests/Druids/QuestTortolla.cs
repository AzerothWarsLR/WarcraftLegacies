using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Druids
{
  public class QuestTortolla{

  
    private const int HERO_ID = FourCC(H04U);
  


    static unit sleepingTortolla

    protected override string CompletionPopup => 
      return "Tortolla has finally awoken from his ancient slumber.";
    }

    protected override string CompletionDescription => 
      return "You can summon Tortolla from the Altar of Elders";
    }

    protected override void OnComplete(){
      RemoveUnit(thistype.sleepingTortolla);
    }

    private void OnFail( ){
      RemoveUnit(thistype.sleepingTortolla);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(HERO_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Turtle Demigod", "Tortolla was badly wounded during the War of the Ancients, && has been resting ever since.", "ReplaceableTextures\\CommandButtons\\BTNSeaTurtleGreen.blp");
      this.AddQuestItem(QuestItemTime.create(1200));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = FourCC(R049);
      ;;
    }


    public static void Setup( ){
      QuestTortolla.sleepingTortolla = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), HERO_ID, -12827, 5729, 333);
      SetUnitInvulnerable(QuestTortolla.sleepingTortolla, true);
      AddSpecialEffectTarget("Abilities\\Spells\\Undead\\Sleep\\SleepTarget.mdl", QuestTortolla.sleepingTortolla, "overhead");
      SetHeroXP(QuestTortolla.sleepingTortolla, LEGEND_TORTOLLA.StartingXP, false);
    }

  }
}
