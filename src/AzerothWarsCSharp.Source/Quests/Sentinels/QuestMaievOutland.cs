using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Legends;
using WCSharp.Shared.Data;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestMaievOutland : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    
    protected override string RewardDescription => "Control of Maiev's Outland outpost and moves Maiev to Outland";
    protected override string CompletionPopup => "Maiev's Outland outpost have been constructed.";

    protected override void OnComplete()
    {
      SetUnitPosition(LegendSentinels.legendMaiev.Unit, -5252, -27597);
      UnitRemoveAbility(LegendSentinels.legendMaiev.Unit, FourCC("A0J5"));
      foreach (var unit in _rescueUnits)
      {
        UnitRescue(unit, Holder.Player);
      }
    }

    public QuestMaievOutland(Rectangle rescueRect) : base("Driven by Vengeance",
      "Maiev drive for vengeance leads her to chase Illidan all the way to other worlds.",
      "ReplaceableTextures\\CommandButtons\\BTNMaievArmor.blp")
    {
      AddQuestItem(new QuestItemCastSpell(FourCC("A0J5"), true));
      AddQuestItem(new QuestItemControlLegend(LegendSentinels.legendMaiev, true));
      
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        ShowUnit(unit, false);
        _rescueUnits.Add(unit);
      }
    }
  }
}
