using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Goblin
{
  public sealed class QuestBusinessExpansion : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R07G");

    protected override string RewardDescription => "The shipyard will be buildable";

    protected override string CompletionPopup => "You can now build shipyards and ships";

    private static void GrantGadetzan(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Gadetzan
      GroupEnumUnitsInRect(tempGroup, Regions.GadgetUnlock.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null)
        {
          break;
        }

        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          UnitRescue(u, whichPlayer);
        }

        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnFail()
    {
      GrantGadetzan(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantGadetzan(Holder.Player);
      if (GetLocalPlayer() == Holder.Player)
      {
        PlayThematicMusicBJ("war3mapImported\\GoblinTheme.mp3");
      }
    }

    public QuestBusinessExpansion() : base ("Business Expansion",
      "Trade Prince Gallywix will need a great amount of wealth to rule the future Goblin Empire; he needs to expand his business all over the world quickly.",
      "ReplaceableTextures\\CommandButtons\\BTNGoblinPrince.blp")
    {
      AddQuestItem(new QuestItemTrain(FourCC("nzep"), FourCC("o04M"), 16));
      AddQuestItem(new QuestItemTrain(FourCC("o04S"), FourCC("o04M"), 10));
      ResearchId = QuestResearchId;
    }
  }
}