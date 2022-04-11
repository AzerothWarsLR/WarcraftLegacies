using static AzerothWarsCSharp.MacroTools.GeneralHelpers;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Factions;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestDunMorogh : QuestData
  {
    public QuestDunMorogh() : base("Mountain Village",
      "A small troll skirmish is attacking Dun Morogh. Push them back!",
      "ReplaceableTextures\\CommandButtons\\BTNIceTrollShadowPriest.blp")
    {
      AddQuestItem(new QuestItemKillUnit(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nith")))); //Troll
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n014"))));
      AddQuestItem(new QuestItemExpire(1435));
      AddQuestItem(new QuestItemSelfExists());
    }

    protected override string CompletionPopup => "The Trolls have been defeated, Dun Morogh will join your cause.";

    protected override string RewardDescription => "Control of all units in Dun Morogh";

    private static void GrantDunMorogh(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in DunMorogh
      GroupEnumUnitsInRect(tempGroup, Regions.DunmoroghAmbient2.Rect, null);
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
      GrantDunMorogh(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantDunMorogh(Holder.Player);
    }
  }
}