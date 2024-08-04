using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;

namespace WarcraftLegacies.Source.Quests.Gilneas
{
  /// <summary>
  /// Capture control points close to Keel Harbor to gain control of it.
  /// </summary>
  public sealed class QuestKeelHarbor: QuestData
  {
    private List<unit> RescueUnits { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestKeelHarbor"/> class.
    /// </summary>
    public QuestKeelHarbor() : base("Keel Harbor", "The final village is the coastal harbor near the capital.", @"ReplaceableTextures\CommandButtons\BTNGilneasShipyard.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N08X_KEEL_HARBOR));
      AddObjective(new ObjectiveControlPoint(UNIT_N031_DUSKHAVEN));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      RescueUnits = Regions.GilneasUnlock3.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "Keel Harbor has been liberated.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all buildings in Keel Harbor.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      whichFaction.Player?.RescueGroup(RescueUnits);
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
