using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestWarsongKillDruids : QuestData{


    private static int _experienceReward = 10000;

    protected override string CompletionPopup => "Nordrassil has been captured. The Warsong is supreme!";

    protected override string CompletionDescription => "Grom Hellscream gains " + I2S(_experienceReward) + " experience";

    protected override void OnComplete(){
      AddHeroXP(LEGEND_GROM.Unit, _experienceReward, true);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Tear It Down", "The World Tree, Nordrassil, is the Night ElvesFourCC(" source of immortality. Capture it to cripple them permanently.","ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp"");
      AddQuestItem(new QuestItemControlLegend(LEGEND_NORDRASSIL, false));
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_GROM));
      
    }


  }
}
