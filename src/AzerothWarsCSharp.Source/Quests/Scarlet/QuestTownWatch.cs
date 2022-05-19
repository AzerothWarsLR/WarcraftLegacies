using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common; 

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestTownWatch : QuestData
  {
    private static readonly int QUEST_RESEARCH_ID = FourCC("R077"); //This research is given when the quest is completed

    public QuestTownWatch() : base("The Cult of the Damned",
      "Unholy Cultists are spreading a deadly plague among the villages of Lordaeron. We must stop them, prevent the corruption, and kill all the Cultists.",
      "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp")
    {
      AddQuestItem(new QuestItemResearch(FourCC("Rhse"), FourCC("h083")));
      AddQuestItem(new QuestItemBuild(FourCC("h084"), 8));
      AddQuestItem(new QuestItemKillXUnit(FourCC("u01U"), 3));
      ResearchId = QUEST_RESEARCH_ID;
    }
    
    protected override string CompletionPopup => "The Cultists have been eliminated. Our towns are now safe.";

    protected override string RewardDescription => "Gain 4000 lumber and 500 gold";

    protected override void OnComplete()
    {
      Holder.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 500);
      Holder.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 4000);
    }
  }
}