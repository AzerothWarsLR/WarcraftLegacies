using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public class QuestMoreWyverns{

  
    private const int UNITTYPE_ID = FourCC(owyv);
    private const int LIMIT_CHANGE = 2;
  


    protected override string CompletionPopup => 
      return "The Sentinels have been eliminated. Warchief Thrall breathes a sigh of relief, knowing that his people are safe - for now.";
    }

    protected override string CompletionDescription => 
      return "Learn to train " + I2S(LIMIT_CHANGE) + " additional " + GetObjectName(UNITTYPE_ID) + "s";
    }

    protected override void OnComplete(){
      this.Holder.ModObjectLimit(UNITTYPE_ID, LIMIT_CHANGE);
      DisplayUnitLimit(this.Holder, UNITTYPE_ID);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Perfect Warriors", "The prowess && savagery of the Sentinels is to be respected - && feared. They must be eliminated.", "ReplaceableTextures\\CommandButtons\\BTNArcher.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_FEATHERMOON));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_AUBERDINE));
      ;;
    }


  }
}
