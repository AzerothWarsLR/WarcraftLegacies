using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Forsaken
{
  public class QuestRetakeSunwell{


    private string operator CompletionPopup( ){
      return "Sylvanas && all the Banshee Hall units gain 500 bonus hit points";
    }

    private string operator CompletionDescription( ){
      return "Sylvanas && her Banshees will be empowered with 500 additional hitpoints each";
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, FourCC(R07V), 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Retaking the Sunwell", "Even in undeath, the SunwellFourCC(s energy to the Forsaken banshees. Reclaim it to bolster their vitality", "ReplaceableTextures\\CommandButtons\\BTNGhost.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SUNWELL, false));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NATHANOS, false));
      ;;
    }


  }
}
