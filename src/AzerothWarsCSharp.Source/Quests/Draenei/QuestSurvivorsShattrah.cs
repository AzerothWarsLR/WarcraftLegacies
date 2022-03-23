using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestSurvivorsShattrah : QuestData{

  
    private static readonly int QuestResearchId = FourCC("R082")   ;//This research is given when the quest is completed
  



    protected override string CompletionPopup => "The hero Maraad is now trainable at the Altar";

    protected override string CompletionDescription => "Maraad will join the survivors on the Exodar";

    public  QuestSurvivorsShattrah ( ){
      thistype this = thistype.allocate("The Survivors of Shattrah", "The Shattrah massacre was swift && brutal, if (the Draenei hold long enough in Outland, they might regroup with some of the survivors.", "ReplaceableTextures\\CommandButtons\\BTNGlazeroth.blp");
      AddQuestItem(new QuestItemTime(480));
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_EXODARSHIP));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QuestResearchId;
      ;;
    }


  }
}
