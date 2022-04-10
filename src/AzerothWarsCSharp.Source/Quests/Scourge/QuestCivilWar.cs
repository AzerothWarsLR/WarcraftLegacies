using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestCivilWar : QuestData
  {
    protected override string CompletionPopup => "The Lich King has rebelled against his demon masters";

    protected override string RewardDescription => "Unally from the Legion team";

    protected override void OnComplete()
    {
      Holder.Team = TeamSetup.TeamScourge;
    }

    public QuestCivilWar() : base("Civil War",
      "The Lich King wants to break free from his Demon Master, but he will need a champion first",
      "ReplaceableTextures\\CommandButtons\\BTNTheLichKingQuest.blp")
    {
      AddQuestItem(new QuestItemResearch(FourCC("R07W"), FourCC("u000")));
      AddQuestItem(new QuestItemControlLegend(LegendLordaeron.LegendArthas, false));
      AddQuestItem(new QuestItemTime(900));
      Global = true;
    }
  }
}