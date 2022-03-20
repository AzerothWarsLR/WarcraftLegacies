using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public class QuestRetakeSunwell{


    protected override string CompletionPopup => 
      return "Sylvanas && all the Banshee Hall units gain 500 bonus hit points";
    }

    protected override string CompletionDescription => 
      return "Sylvanas && her Banshees will be empowered with 500 additional hitpoints each";
    }

    protected override void OnComplete(){
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
