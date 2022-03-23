//Illidan Goes to Aetheneum, Finds Immoltar and kills him

using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestIllidanChapterOne : QuestData
  {
    private readonly QuestData _questToDiscover;

    public QuestIllidanChapterOne(QuestData questToDiscover) : base("Chapter One: The Aetheneum Secrets",
      "In order to gain the power he craves, Illidan must plunder the hidden Aetheneum library for its secrets.",
      "ReplaceableTextures\\CommandButtons\\BTNDoomlord.blp")
    {
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, Regions.DireMaulEntrance.Rect, "Feralas"));
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, Regions.AethneumLibraryEntrance.Rect,
        "the Aetheneum Library"));
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, Regions.ImmolFight.Rect,
        "ImmolFourCC("thar")s Lair"));
      AddQuestItem(new QuestItemLegendDead(LEGEND_IMMOLTHAR));
      _questToDiscover = questToDiscover;
      ;
      ;
    }

    protected override string CompletionPopup =>
      "Illidan has learned of the existence of the Skull of GulFourCC(dan, hidden in Dalaran";

    protected override string CompletionDescription => "Chapter Two - The Skull of GulFourCC(dan";

    protected override void OnComplete()
    {
      _questToDiscover.Progress = QUEST_PROGRESS_INCOMPLETE;
    }
  }
}