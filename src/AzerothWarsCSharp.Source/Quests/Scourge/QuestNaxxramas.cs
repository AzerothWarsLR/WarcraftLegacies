using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestNaxxramas : QuestData
  {
    private readonly unit _naxxramas;
    
    public QuestNaxxramas(unit naxxramas) : base("The Dread Citadel",
      "This fallen necropolis can be transformed into a potent war machine by the Lich Kel'thuzad",
      @"ReplaceableTextures\CommandButtons\BTNBlackCitadel.blp")
    {
      _naxxramas = naxxramas;
      QuestItemChannelRect questItemChannelRect =
        new(Regions.NaxUnlock, "Naxxramas", LegendScourge.LegendKelthuzad, 60, 270)
        {
          RequiredUnitTypeId = LegendScourge.UnittypeKelthuzadLich
        };
      AddQuestItem(questItemChannelRect);
    }


    protected override string CompletionPopup =>
      "The Naxxramas has now been raised and under the control of the " + Holder.Team.Name + ".";

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
      UnitRescue(_naxxramas, Holder.Player);
      SetPlayerAbilityAvailableBJ(false, FourCC("A0O2"), Holder.Player);
    }
  }
}