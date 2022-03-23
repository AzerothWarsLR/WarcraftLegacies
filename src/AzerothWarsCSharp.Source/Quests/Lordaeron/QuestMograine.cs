//Destroy the Frozen Throne to unlock Mograine.

using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestMograine : QuestData{

  
    private static readonly int AltarId = FourCC("halt");
    private static readonly int HeroId = FourCC("H01J");
  


    protected override string CompletionPopup => "With the Lich King eliminated, the Kingdom of Lordaeron is free of its greatest threat. Alexandros Mograine gains recognition as a champion of the war, && prepares himself to aid Lordaeron in future conflicts in a greater capacity.";

    protected override string CompletionDescription => 
      return "You can summon Alexandros Mograine from the " + GetObjectName(ALTAR_ID);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(HERO_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Exile", "The Lich King, looming over Northrend from IcecrownFourCC("s peak, is the greatest threat Lordaeron has ever faced. He must be destroyed.", "ReplaceableTextures\\CommandButtons\\BTNAlexandros.blp"");
      this.AddQuestItem(new QuestItemLegendDead(LEGEND_LICHKING));
      this.ResearchId = FourCC("R06P");
      ;;
    }


  }
}
