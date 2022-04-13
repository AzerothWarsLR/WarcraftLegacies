using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestBoralus : QuestData
  {
    private static readonly int QUEST_RESEARCH_ID = FourCC("R00L"); //This research is given when the quest is completed

    public QuestBoralus() : base("The City at Sea",
      "Proudmoore is stranded at sea. Rejoin Boralus to take control of the city.",
      "ReplaceableTextures\\CommandButtons\\BTNHumanShipyard.blp")
    {
      AddQuestItem(new QuestItemResearch(FourCC("R04R"), FourCC("h06I")));
      AddQuestItem(new QuestItemUpgrade(FourCC("h062"), FourCC("h062")));
      AddQuestItem(new QuestItemExpire(900));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QUEST_RESEARCH_ID;
    }


    protected override string CompletionPopup =>
      "KulFourCC(Tiras has joined the war and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Control of all units in KulFourCC(Tiras and enables Katherine Proodmoure to be trained at the altar";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.Kultiras.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.Kultiras.Rect, Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\KultirasTheme.mp3");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }
  }
}