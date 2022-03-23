using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public class QuestLumberQuota : QuestData {
    private readonly int _researchId = FourCC(""R05O""); //This research is required to complete the quest
    private readonly int _questResearchId = FourCC(""R05R""); //This research is given when the quest is completed

    public QuestLumberQuota() : base("To Tame a Land",
      "This new continent is ripe for opportunity, if (the Horde is going to survive, a new city needs to be built.",
      "ReplaceableTextures\\CommandButtons\\BTNFortress.blp")
    {
      AddQuestItem(new QuestItemResearch(_researchId, FourCC(""o02S"")));
      AddQuestItem(new QuestItemExpire(1500));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = _questResearchId;

      CompletionPopup = () => "Control of all units in Orgrimmar, able to train Varok";
      CompletionDescription = () => "Control of all units in Orgrimmar, able to train Varok";
      OnComplete = () =>
      {
        GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_Orgrimmar, Holder.Player);
        if (GetLocalPlayer() == Holder.Player)
        {
          PlayThematicMusicBJ("war3mapImported\\OrgrimmarTheme.mp3");
        }
      };
      OnFail = () =>
      {
        GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_Orgrimmar, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      };
      OnAdd = () =>
      {
        Holder.ModObjectLimit(_researchId, 1);
      };
    }
  }
}
