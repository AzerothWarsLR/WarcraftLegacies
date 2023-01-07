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
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestMaievOutland"/> class
    /// </summary>
    /// <param name="rescueRect"></param>
    public QuestMaievOutland(Rectangle rescueRect) : base("Driven by Vengeance",
      "Maiev drive for vengeance leads her to chase Illidan all the way to other worlds.",
      "ReplaceableTextures\\CommandButtons\\BTNMaievArmor.blp")
    {
      AddObjective(new ObjectiveCastSpell(FourCC("A0J5"), true));
      AddObjective(new ObjectiveControlLegend(LegendSentinels.Maiev, true));
      AddObjective(new ObjectiveControlCapital(LegendSentinels.VaultOfTheWardens, true));

      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        ShowUnit(unit, false);
        _rescueUnits.Add(unit);
      }
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of Maiev's Outland outpost and moves Maiev to Outland";

    /// <inheritdoc/>
    protected override string CompletionPopup => "Maiev's Outland outpost have been constructed.";
    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      SetUnitPosition(LegendSentinels.Maiev.Unit, -5252, -27597);
      UnitRemoveAbility(LegendSentinels.VaultOfTheWardens.Unit, FourCC("A0J5"));
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}