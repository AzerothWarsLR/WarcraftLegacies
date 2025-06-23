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
  /// Capture control points close to Stormglen to gain control of it.
  /// </summary>
  public sealed class QuestSouthshoregil : QuestData
  {
    private List<unit> RescueUnits { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestSouthshoregil"/> class.
    /// </summary>
    public QuestSouthshoregil(Rectangle rescueRect) : base("SouthShore", "Placeholder.", @"ReplaceableTextures\CommandButtons\BTNGilneasWizardTower.blp")
    {
      RescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
      AddObjective(new ObjectiveControlPoint(UNIT_N08M_SOUTHSHORE));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "Southshore Village has been liberated.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all buildings in Southshore Village";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in RescueUnits)
        unit.Rescue(completingFaction.Player);
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(RescueUnits);
    }
  }
}
