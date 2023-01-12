using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Legion
{
 
  public sealed class QuestAlteracBase : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestAlteracBase"/> class
    /// </summary>
    /// <param name="rescueRect"></param>
    public QuestAlteracBase(Rectangle rescueRect) : base("Ruins of Alterac",
      "The orcs that occupied Alterac have maintained a secret demon gate, the Legion will make good use of it",
      "ReplaceableTextures\\CommandButtons\\BTNDemonCrypt.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N019_ALTERAC_MOUNTAINS_20GOLD_MIN)));

      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
      {
        SetUnitInvulnerable(unit, true);
        ShowUnit(unit, false);
        _rescueUnits.Add(unit);
      }
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Control and reveal a small base in Alterac";

    /// <inheritdoc/>
    protected override string RewardFlavour => "The Legion will reveal their plot in Alterac, unlocking demon-gathering portals";
    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}