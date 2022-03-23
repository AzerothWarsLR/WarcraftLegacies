using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestGuldansLegacy : QuestData{

  
    private int _researchId = FourCC(""R041"");
  


    protected override string CompletionPopup => "GulFourCC("dan")s remains have been located within the Tomb of Sargeras. His eldritch knowledge may now be put to purpose.";

    protected override string CompletionDescription => 

    }

    protected override void OnComplete(){

      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("GulFourCC("dans Legacy", "The Orc Warlock Gul")dan is ultimately responsible for the formation of the Fel Horde. Though long dead, his teachings could still be extracted from his body.", "ReplaceableTextures\\CommandButtons\\BTNGuldan.blp");
      this.AddQuestItem(new QuestItemAnyUnitInRect(Regions.Guldan, "GulFourCC("dan")s corpse in the Tomb of Sargeras".Rect, true));
      
    }


  }
}
