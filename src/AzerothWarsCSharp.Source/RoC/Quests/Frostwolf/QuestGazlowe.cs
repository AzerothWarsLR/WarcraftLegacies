using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Frostwolf
{
  public class QuestGazlowe{

  
    private const int RESEARCH_ID = FourCC(R01F);
    private const int HERO_ID = FourCC(Ntin);
  



    private string operator CompletionPopup( ){
      return "With the Goblin homeland of Kezan now under " + this.Holder.Name + " control, the goblin Gazlowe offers his services as an expert engineer, upgrading your Shredders with new weaponry.";
    }

    private string operator CompletionDescription( ){
      return "You can summon Gazlowe from the Altar of Storms, && Shredders learn to cast Pocket Factory, Saw Bombardment, && Emergency Repairs";
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(HERO_ID, 1);
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Explosive Engineering", "The Horde needs engineering skills if (it is to thrive. The Goblins of Kezan could provide such expertise.", "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n04Z))));
      ;;
    }


  }
}
