using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Warsong
{
  public class QuestWarsongKillDruids{


    private static int EXPERIENCE_REWARD = 10000;

    private string operator CompletionPopup( ){
      return "Nordrassil has been captured. The Warsong is supreme!";
    }

    private string operator CompletionDescription( ){
      return "Grom Hellscream gains " + I2S(EXPERIENCE_REWARD) + " experience";
    }

    private void OnComplete( ){
      AddHeroXP(LEGEND_GROM.Unit, EXPERIENCE_REWARD, true);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Tear It Down", "The World Tree, Nordrassil, is the Night ElvesFourCC( source of immortality. Capture it to cripple them permanently.","ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NORDRASSIL, false));
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_GROM));
      ;;
    }


  }
}
