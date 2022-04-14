using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestGoldshire : QuestData
  {
    public QuestGoldshire(unit hogger) : base("The Scourge of Elwynn",
      "Hogger and his pack have taken over Goldshire, clear them out!",
      "ReplaceableTextures\\CommandButtons\\BTNGnoll.blp")
    {
      AddQuestItem(new QuestItemKillUnit(hogger)); //Hogger
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00Z"))));
      AddQuestItem(new QuestItemExpire(1335));
      AddQuestItem(new QuestItemSelfExists());
    }

    protected override string CompletionPopup => "The Gnolls have been defeated, Goldshire is safe.";

    protected override string RewardDescription => "Control of all units in Goldshire";

    //Todo: replace with GeneralHelpers function
    private static void GrantGoldshire(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Goldshire
      GroupEnumUnitsInRect(tempGroup, Regions.ElwinForestAmbient.Rect, null);
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
      GrantGoldshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantGoldshire(Holder.Player);
    }
  }
}