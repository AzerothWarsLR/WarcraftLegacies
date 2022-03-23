using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestTownWatch : QuestData
  {
    private const int QUEST_RESEARCH_ID = FourCC("R077"); //This research is given when the quest is completed

    public QuestTownWatch() : base("The Cult of the Damned",
      "Unholy Cultists are spreading a deadly plague among the villages of Lordaeron. We must stop them, prevent the corruption, && kill all the Cultists.",
      "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp")
    {
      this.AddQuestItem(new QuestItemResearch(FourCC("Rhse"),)h083)));
      this.AddQuestItem(new QuestItemBuild(FourCC("h084"), 8));
      this.AddQuestItem(new QuestItemKillXUnit(FourCC("u01U"), 3));
      ResearchId = QUEST_RESEARCH_ID;
      ;
      ;
    }


    protected override string CompletionPopup => "The Cultists have been eliminated. Our towns are now safe.";

    protected override string CompletionDescription => "Gain 4000 lumber && 500 gold";

    protected override void OnComplete()
    {
      AdjustPlayerStateBJ(500, Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
      AdjustPlayerStateBJ(4000, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER);
    }

    protected override void OnAdd()
    {
    }
  }
}