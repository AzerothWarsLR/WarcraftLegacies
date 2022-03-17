using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Legion
{
  public class QuestEmbassy{

  
    private const int HERO_ID = FourCC(U00L);
    private const int ALTAR_ID = FourCC(u01N);
  


    private string operator CompletionPopup( ){
      return "The Legion has secured a foothold on Azeroth.";
    }

    private string operator CompletionDescription( ){
      return "You can build the Infernal Machine Factory && summon Anetheron from the " + GetObjectName(ALTAR_ID);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Infernal Foothold", "A stronger foothold in this world will be required to field the Burning LegionFourCC(s war machines && to in more of its lieutenants.", "ReplaceableTextures\\CommandButtons\\BTNDemonBlackCitadel.blp");
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(e01H), )e01F)));
      this.ResearchId = FourCC(R042);
      ;;
    }


  }
}
