using System.Collections.Generic;
using System.Linq;
using MacroTools;
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

    private readonly unit _legionDemonGate;
    public QuestAlteracBase(Rectangle rescueRect, PreplacedUnitSystem preplacedUnitSystem) : base("Ruins of Alterac",
      "The orcs that occupied Alterac have maintained a secret demon gate, the Legion will make good use of it",
      "ReplaceableTextures\\CommandButtons\\BTNDemonCrypt.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N019_ALTERAC_MOUNTAINS_20GOLD_MIN)));

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      _legionDemonGate = preplacedUnitSystem.GetUnit(Constants.UNIT_N081_UNFOCUSED_DEMON_GATE_T0, new Point(10921, 6405));
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Control and reveal a small base in Alterac";

    /// <inheritdoc/>
    protected override string RewardFlavour => "The Legion will reveal their plot in Alterac, unlocking demon-gathering portals";
    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
      _legionDemonGate.Rescue(completingFaction.Player);

    }
  }
}