using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  public sealed class QuestMaievOutland : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestMaievOutland(Rectangle rescueRect) : base("Driven by Vengeance",
      "Maiev drive for vengeance leads her to chase Illidan all the way to other worlds.",
      "ReplaceableTextures\\CommandButtons\\BTNMaievArmor.blp")
    {
      AddObjective(new ObjectiveCastSpell(FourCC("A0J5"), true));
      AddObjective(new ObjectiveControlCapital(LegendSentinels.VaultOfTheWardens, true));

      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        ShowUnit(unit, false);
        _rescueUnits.Add(unit);
      }
    }

    protected override string RewardDescription => "Control of Maiev's Outland outpost and moves Maiev to Outland";
    protected override string CompletionPopup => "Maiev's Outland outpost have been constructed.";

    protected override void OnComplete(Faction completingFaction)
    {
      SetUnitPosition(LegendSentinels.Maiev.Unit, -5252, -27597);
      UnitRemoveAbility(LegendSentinels.Maiev.Unit, FourCC("A0J5"));
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}