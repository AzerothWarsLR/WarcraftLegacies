//When Black Temple is destroyed, Stormwind can train Khadgar.

using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Stormwind
{
  public class QuestKhadgar{

  
    private const int HERO_ID = FourCC(H05Y);
  


    protected override string CompletionPopup => 
      return "Khadgar has been freed from his confines under the Black Temple, && he is now free to serve the Kingdom of Stormwind.";
    }

    protected override string CompletionDescription => 
      return "You can summon Khadgar from the Altar of Kings";
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(HERO_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Keeper of the Eternal Watch", "At the end of the Second War, Khadgar remained in Draenor to seal the Dark Portal, effectively ending the conflict. He has been stranded deep in Outland ever since.", "ReplaceableTextures\\CommandButtons\\BTNMageWC2blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_BLACKTEMPLE, false));
      this.ResearchId = FourCC(R016);
      ;;
    }


  }
}
