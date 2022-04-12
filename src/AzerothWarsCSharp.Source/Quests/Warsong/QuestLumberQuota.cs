using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestLumberQuota : QuestData
  {
    private readonly int _researchId = FourCC("R05O"); //This research is required to complete the quest
    private readonly int _questResearchId = FourCC("R05R"); //This research is given when the quest is completed

    protected override string CompletionPopup => "Control of all units in Orgrimmar, able to train Varok";

    protected override string RewardDescription => "Control of all units in Orgrimmar, able to train Varok";

    protected override void OnComplete()
    {
      RescueNeutralUnitsInRect(Regions.Orgrimmar.Rect, Holder.Player);
      if (GetLocalPlayer() == Holder.Player)
      {
        PlayThematicMusicBJ("war3mapImported\\OrgrimmarTheme.mp3");
      }
    }

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.Orgrimmar.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(_researchId, 1);
    }

    public QuestLumberQuota() : base("To Tame a Land",
      "This new continent is ripe for opportunity, if (the Horde is going to survive, a new city needs to be built.",
      "ReplaceableTextures\\CommandButtons\\BTNFortress.blp")
    {
      AddQuestItem(new QuestItemResearch(_researchId, FourCC("o02S")));
      AddQuestItem(new QuestItemExpire(1500));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = _questResearchId;
    }
  }
}