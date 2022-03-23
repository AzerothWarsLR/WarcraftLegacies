using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestBeyondPortal : QuestData{

 
    private const int QUEST_RESEARCH_ID = FourCC("R085")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "The orcs are no more && we can now train Fusillier.";

    protected override string CompletionDescription => "You will be able to train Fusillier from the Barrack";

    public  thistype ( ){
      thistype this = thistype.allocate("Beyond the Dark Portal", "The Orc threat from Draenor still looms over all. Eliminate every trace of the Orcs && their bases.", "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp");
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_BLACKTEMPLE, false));
      this.AddQuestItem(new QuestItemLegendDead(LEGEND_HELLFIRECITADEL));
      this.AddQuestItem(new QuestItemLegendDead(LEGEND_BLACKROCKSPIRE));
      this.AddQuestItem(new QuestItemSelfExists());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
