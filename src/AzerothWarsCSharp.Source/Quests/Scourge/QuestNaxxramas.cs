using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestNaxxramas : QuestData
  {
    public QuestNaxxramas() : base("The Dread Citadel",
      "This fallen necropolis can be transformed into a potent war machine by the Lich Kel'thuzad", @"ReplaceableTextures\CommandButtons\BTNBlackCitadel.blp")
    {
      QuestItemChannelRect questItemChannelRect =
        AddQuestItem(new QuestItemChannelRect(Regions.NaxUnlock.Rect, "Naxxramas", LegendScourge.LegendKelthuzad, 60, 270));
      questItemChannelRect.RequiredUnitTypeId = UNITTYPE_KELTHUZAD_LICH;
    }


    protected override string CompletionPopup =>
      "The Naxxramas has now been raised && under the control of the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Naxxramas";

    private static void GrantNaxxramas(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Naxxramas
      GroupEnumUnitsInRect(tempGroup, Regions.NaxAmbient.Rect, null);
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

    protected override void OnComplete()
    {
      GrantNaxxramas(Holder.Player);
      SetUnitOwner(gg_unit_e013_1815, Holder.Player, true);
      SetUnitInvulnerable(gg_unit_e013_1815, false);
      SetPlayerAbilityAvailableBJ(false, FourCC("A0O2"), Holder.Player);
    }
  }
}