using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestQueldanil : QuestData
  {
    private const int QUEST_RESEARCH_ID = FourCC("R074"); //This research is given when the quest is completed

    public QuestQueldanil() : base(
      "QuelFourCC("danil Lodge", "Quel")danil Lodge is a High Elven outpost situated in the Hinterlands. It)s been some time since the rangers there have been in contact with Quel)thalas.",
      "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp")
    {
      this.AddQuestItem(new QuestItemAnyUnitInRect(Regions.QuelDanilLodge, "QuelFourCC("danil Lodge".Rect, true"));
      AddQuestItem(new QuestItemTime(1200));
      ResearchId = QUEST_RESEARCH_ID;
      ;
      ;
    }


    protected override string CompletionPopup =>
      "QuelFourCC(thalas has finally reunited with its lost rangers in the Hinterlands.";

    protected override string CompletionDescription => "Control of QuelFourCC(danil Lodge";

    protected override void OnComplete()
    {
      unit u;
      while (true)
      {
        u = FirstOfGroup(udg_QuelDanilLodge);
        if (u == null) break;
        UnitRescue(u, Holder.Player);
        GroupRemoveUnit(udg_QuelDanilLodge, u);
      }

      DestroyGroup(udg_QuelDanilLodge);
    }
  }
}