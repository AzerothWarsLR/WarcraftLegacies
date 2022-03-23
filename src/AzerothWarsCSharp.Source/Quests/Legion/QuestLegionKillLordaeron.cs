using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestLegionKillLordaeron : QuestData{


    protected override string CompletionPopup => "The Kingdom of Lordaeron has fallen, eliminating AzerothFourCC(s vanguard against the Legion.";

    protected override string CompletionDescription => "Tichondrius gains 15 Strength, Agility && Intelligence";

    protected override void OnComplete(){
      DisplayHeroReward(LEGEND_TICHONDRIUS.Unit, 15, 15, 15, 0);
      AddHeroAttributes(LEGEND_TICHONDRIUS.Unit, 15, 15, 15);
    }

    public  QuestLegionKillLordaeron ( ){
      thistype this = thistype.allocate("Token Resistance", "The Kingdom of Lordaeron must be eliminated to pave the way for the LegionFourCC("s arrival.", "ReplaceableTextures\\CommandButtons\\BTNTichondrius.blp"");
      AddQuestItem(new QuestItemLegendDead(LEGEND_CAPITALPALACE));
      AddQuestItem(new QuestItemLegendDead(LEGEND_STRATHOLME));
      AddQuestItem(new QuestItemLegendDead(LEGEND_TYRSHAND));
      ;;
    }


  }
}
