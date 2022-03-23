using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestPlague : QuestData{

  
    private static readonly int ResearchId = FourCC("R06I");
  


    private bool Global( ){
      return true;
    }

    protected override string CompletionPopup => "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies.";

    protected override string CompletionDescription => "A plague is unleashed upon the lands of Lordaeron";

    protected override void OnComplete(){
      Holder.ModObjectLimit(ResearchId, -UNLIMITED);
      TriggerExecute( gg_trg_Plague_Actions );
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Plague of Undeath", "You can unleash a devastating zombifying plague across the lands of Lordaeron. Once itFourCC("s started, you can type -off to deactivate Cauldron Zombie spawns. Type -end to stop citizens from turning into zombies.", "ReplaceableTextures\\CommandButtons\\BTNPlagueBarrel.blp"");
      this.AddQuestItem(new QuestItemEitherOf.create(QuestItemResearch.create(ResearchId, FourCC("u000")), QuestItemTime(960)));
      AddQuestItem(new QuestItemTime(660));
      ;;
    }


  }
}
