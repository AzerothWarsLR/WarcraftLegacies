using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestDarkshire : QuestData
  {
    public QuestDarkshire()
    {
      thistype this = thistype.allocate("Gnoll troubles", "The town of Darkshire is under attack by GnollFourCC("s,
        clear them out!", "ReplaceableTextures\\CommandButtons\\BTNGnollArcher.blp");
      AddQuestItem(QuestItemKillUnit.create(gg_unit_ngnv_0586)); //Gnoll Overseer
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00V"))));
      AddQuestItem(new QuestItemExpire(1425));
      AddQuestItem(new QuestItemSelfExists());
    }


    protected override string CompletionPopup =>
      "Darkshire has been liberated, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Darkshire";

    private void GrantDarkshire(player whichPlayer)
    {
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Darkshire
      GroupEnumUnitsInRect(tempGroup, Regions.DarkshireUnlock.Rect, null);
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
      GrantDarkshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantDarkshire(Holder.Player);
    }

    protected override void OnAdd()
    {
    }
  }
}