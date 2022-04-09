using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestDragonmawPort : QuestData
  {
    public QuestDragonmawPort() : base("Dragonmaw Port",
      "The Dragonmaw Port will be the perfect staging ground of the invasion of Azeroth",
      "ReplaceableTextures\\CommandButtons\\BTNIronHordeSummoningCircle.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08T"))));
      AddQuestItem(new QuestItemExpire(1227));
      AddQuestItem(new QuestItemSelfExists());
      ;
      ;
    }


    protected override string CompletionPopup =>
      "Dragonmaw Port has fallen under our control && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all buildings in Dragonmaw Port";

    private void GrantDragonmawPort(player whichPlayer)
    {
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in DragonmawPort
      GroupEnumUnitsInRect(tempGroup, Regions.DragonmawUnlock.Rect, null);
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
      GrantDragonmawPort(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantDragonmawPort(Holder.Player);
    }

    protected override void OnAdd()
    {
    }
  }
}