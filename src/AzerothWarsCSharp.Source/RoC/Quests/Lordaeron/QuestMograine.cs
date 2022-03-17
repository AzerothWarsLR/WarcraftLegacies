//Destroy the Frozen Throne to unlock Mograine.

using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Lordaeron
{
  public class QuestMograine{

  
    private const int ALTAR_ID = FourCC(halt);
    private const int HERO_ID = FourCC(H01J);
  


    private string operator CompletionPopup( ){
      return "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. Alexandros Mograine gains recognition as a champion of the war, && prepares himself to aid Lordaeron in future conflicts in a greater capacity.";
    }

    private string operator CompletionDescription( ){
      return "You can summon Alexandros Mograine from the " + GetObjectName(ALTAR_ID);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(HERO_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Exile", "The Lich King, looming over Northrend from IcecrownFourCC(s peak, is the greatest threat Lordaeron has ever faced. He must be destroyed.", "ReplaceableTextures\\CommandButtons\\BTNAlexandros.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LICHKING));
      this.ResearchId = FourCC(R06P);
      ;;
    }


  }
}
