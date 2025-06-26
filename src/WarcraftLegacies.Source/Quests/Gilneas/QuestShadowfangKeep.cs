using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Gilneas
{
  /// <summary>
  /// Capture control points close to Keel Harbor to gain control of it.
  /// </summary>
  public sealed class QuestShadowfangKeep: QuestData
  {
    private readonly List<unit> _rescueUnits;

    public QuestShadowfangKeep(Rectangle rescueRect) : base("Shadowfang Keep", 
      "Placeholder.",
      @"ReplaceableTextures\CommandButtons\BTNworgen.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N01D_SILVERPINE_FOREST));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

    }

    /// <inheritdoc/>
    public override string RewardFlavour => "Shadowfang Keep and Ambermill has been liberated.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all buildings and units in Shadowfang.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits)
        unit.Rescue(completingFaction.Player);
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }
  }
}
