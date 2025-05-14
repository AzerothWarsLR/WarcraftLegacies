using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.PassiveAbilitySystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  /// <summary>
  /// Kill the constructs to gain control of C'thun and the inner temple base.
  /// </summary>
  public sealed class QuestTitanJailors : QuestData
  {
    private readonly AllLegendSetup _allLegendSetup;
    private readonly List<unit> _rescueUnits;
    private readonly List<unit> _preparedUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTitanJailors"/> class.
    /// </summary>
    public QuestTitanJailors(AllLegendSetup allLegendSetup, Rectangle rescueRect) : base("Titan Jailors",
      "C'thun is currently watched by a Titan Construct. We must rid the temple of hostiles and destroy the Titan to free our god.",
      @"ReplaceableTextures\CommandButtons\BTNArmorGolem.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_NLSE_TEMPLE_OF_AHN_QIRAJ, 1500));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());

      _allLegendSetup = allLegendSetup;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

      // Prepare neutral passive units in AQ_Blockers and store them in a list
      _preparedUnits = Regions.AQ_Blockers.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
    }

    /// <inheritdoc />
    public override string RewardFlavour => "With the Titan Construct defeated, C'thun is now free.";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units in inner Ahn'Qiraj and gain control of C'thun.";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      // Remove all previously prepared units in AQ_Blockers
      CleanupPreparedUnits();

      // Rescue the units in the rescue rectangle or transfer them to neutral hostile if necessary
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      // Remove all previously prepared units in AQ_Blockers
      CleanupPreparedUnits();
     

      // Rescue the rescue region units for the completing faction
      completingFaction.Player.RescueGroup(_rescueUnits);

      // Check if C'thun exists and enable his abilities
      var cthun = _allLegendSetup.Ahnqiraj.Cthun.Unit;
      if (cthun != null)
      {
        PassiveAbilityManager.ForceOnCreated(cthun);
      }
    }

    /// <summary>
    /// Removes all units that were prepared in AQ_Blockers during quest initialization.
    /// </summary>
    private void CleanupPreparedUnits()
    {
      foreach (var unit in _preparedUnits)
      {
        // Ensure the unit is still valid before attempting to remove it
        if (unit != null)
        {
          // Remove the unit directly, regardless of its owner
          unit.Remove();
        }
      }
    }
  }
}