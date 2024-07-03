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
  /// Kill some constructs to gain cthun and the inner temple base.
  /// </summary>
  public sealed class QuestTitanJailors : QuestData
  {
    private readonly AllLegendSetup _allLegendSetup;
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTitanJailors"/> class.
    /// </summary>
    public QuestTitanJailors(AllLegendSetup allLegendSetup, Rectangle rescueRect) : base("Titan Jailors",
      "C'thun is currently watched by a Titan Construct, we need to destroy it to free our god.",
      @"ReplaceableTextures\CommandButtons\BTNArmorGolem.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_NLSE_TEMPLE_OF_AHN_QIRAJ));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      _allLegendSetup = allLegendSetup;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc />
    public override string RewardFlavour => "With the Titan Construct defeat, C'thun is now free";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units in inner Ahn'qiraj and gain control of C'thun";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
      var cthun = _allLegendSetup.Ahnqiraj.Cthun.Unit;
      if (cthun != null)
        PassiveAbilityManager.ForceOnCreated(cthun);
    }
  }
}