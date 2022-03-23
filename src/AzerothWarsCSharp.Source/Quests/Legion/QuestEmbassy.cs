using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestEmbassy : QuestData{

  
    private const int HERO_ID = FourCC("U00L");
    private const int ALTAR_ID = FourCC("u01N");
  


    protected override string CompletionPopup => 
      return "The Legion has secured a foothold on Azeroth.";
    }

    protected override string CompletionDescription => 
      return "You can build the Infernal Machine Factory && summon Anetheron from the " + GetObjectName(ALTAR_ID);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Infernal Foothold", "A stronger foothold in this world will be required to field the Burning LegionFourCC("s war machines && to in more of its lieutenants.", "ReplaceableTextures\\CommandButtons\\BTNDemonBlackCitadel.blp"");
      this.AddQuestItem(new QuestItemUpgrade(FourCC("e01H"), )e01F)));
      this.ResearchId = FourCC("R042");
      ;;
    }


  }
}
