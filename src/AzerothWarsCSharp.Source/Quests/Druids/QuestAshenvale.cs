using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestAshenvale : QuestData
  {
    public QuestAshenvale() : base("The Spirits of Ashenvale",
      "The forest needs healing. Regain control of it to summon it's Guardian, the Demigod Cenarius",
      "ReplaceableTextures\\CommandButtons\\BTNKeeperC.blp")
    {
      AddQuestItem(
        new QuestItemLegendReachRect(LegendDruids.LegendMalfurion, Regions.AshenvaleUnlock.Rect, "Ashenvale"));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n07C"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01Q"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08U"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("etol"), FourCC("etol")));
      AddQuestItem(new QuestItemExpire(1440));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R06R");
    }


    protected override string CompletionPopup => "Ashenvale is under control and Cenarius can now be awaken";

    protected override string RewardDescription =>
      "Control of all units in Ashenvale and make Cenarius trainable at the Altar";

    private static void GrantAshenvale(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Ashenvale
      GroupEnumUnitsInRect(tempGroup, Regions.AshenvaleUnlock.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, whichPlayer);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
    }

    protected override void OnFail()
    {
      GrantAshenvale(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantAshenvale(Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\DruidTheme.mp3");
    }
  }
}