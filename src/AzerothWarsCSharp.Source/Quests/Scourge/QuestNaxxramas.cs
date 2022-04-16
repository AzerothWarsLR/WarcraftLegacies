using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestNaxxramas : QuestData
  {
    private readonly unit _naxxramas;
    private readonly List<unit> _rescueUnits = new();

    public QuestNaxxramas(Rectangle rescueRect, unit naxxramas) : base("The Dread Citadel",
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
      SetUnitInvulnerable(naxxramas, true);

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => $"The Naxxramas has now been raised and under the control of the {Holder.Team.Name}.";

    protected override string RewardDescription => "Control of all units in Naxxramas";

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
      UnitRescue(_naxxramas, Holder.Player);
      SetPlayerAbilityAvailableBJ(false, FourCC("A0O2"), Holder.Player);
    }
  }
}