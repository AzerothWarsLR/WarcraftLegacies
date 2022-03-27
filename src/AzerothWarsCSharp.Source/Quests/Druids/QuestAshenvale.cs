using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestAshenvale : QuestData
  {
    private const int RESEARCH_ID = FourCC("R06R"); //This research is given when the quest is completed

    public QuestAshenvale()
    {
      thistype this = thistype.allocate("The Spirits of Ashenvale",
        "The forest needs healing. Regain control of it to summon itFourCC("s Guardian,
        the Demigod Cenarius", "ReplaceableTextures\\CommandButtons\\BTNKeeperC.blp");
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_MALFURION, Regions.AshenvaleUnlock.Rect, "Ashenvale"));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n07C"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01Q"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08U"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("etol"), FourCC("etol")));
      AddQuestItem(new QuestItemExpire(1440));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = RESEARCH_ID;
    }


    protected override string CompletionPopup => "Ashenvale is under control && Cenarius can now be awaken";

    protected override string CompletionDescription =>
      "Control of all units in Ashenvale && make Cenarius trainable at the Altar";

    private void GrantAshenvale(player whichPlayer)
    {
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Ashenvale
      GroupEnumUnitsInRect(tempGroup, Regions.AshenvaleUnlock.Rect, null);
      u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, whichPlayer);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
      tempGroup = null;
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