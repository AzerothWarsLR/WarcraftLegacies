using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestDominion : QuestData
  {
    public QuestDominion() : base("Dwarven Dominion",
      "The Dwarven Dominion must be established before Ironforge can join the war.",
      "ReplaceableTextures\\CommandButtons\\BTNNorthrendCastle.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n017"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n014"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n013"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("h07E"), FourCC("h07E")));
      AddQuestItem(new QuestItemExpire(1462));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R043");
    }
    
    protected override string CompletionPopup =>
      "The Dwarven Empire is re-united again, Ironforge is ready for war again.";

    protected override string CompletionDescription => "Control of all units in Ironforge";

    private void GrantDominion(player whichPlayer)
    {
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Dominion
      GroupEnumUnitsInRect(tempGroup, Regions.IronforgeAmbient.Rect, null);
      u = FirstOfGroup(tempGroup);
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
      GrantDominion(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantDominion(Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\DwarfTheme.mp3");
    }
  }
}