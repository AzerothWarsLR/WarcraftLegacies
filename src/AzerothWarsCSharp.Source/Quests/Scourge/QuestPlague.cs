using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public class QuestPlague{

  
    private const int RESEARCH_ID = FourCC(R06I);
  


    private bool Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies.";
    }

    protected override string CompletionDescription => 
      return "A plague is unleashed upon the lands of Lordaeron";
    }

    protected override void OnComplete(){
      this.Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED);
      TriggerExecute( gg_trg_Plague_Actions );
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Plague of Undeath", "You can unleash a devastating zombifying plague across the lands of Lordaeron. Once itFourCC(s started, you can type -off to deactivate Cauldron Zombie spawns. Type -end to stop citizens from turning into zombies.", "ReplaceableTextures\\CommandButtons\\BTNPlagueBarrel.blp");
      this.AddQuestItem(QuestItemEitherOf.create(QuestItemResearch.create(RESEARCH_ID, FourCC(u000)), QuestItemTime.create(960)));
      this.AddQuestItem(QuestItemTime.create(660));
      ;;
    }


  }
}
