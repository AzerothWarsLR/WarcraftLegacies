using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Skywall
{ 
  /// <summary>
  /// Gain the Throne of the Four Winds base
  /// </summary>
  public sealed class QuestThroneWind : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestThroneWind"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
    public QuestThroneWind(Rectangle rescueRect) : base("The Throne of the Four Winds",
      "We have lost contact with the Elemental Realm, conquer Uldum to access the Vortex Pinnacle.",
      @"ReplaceableTextures\CommandButtons\BTNAlAkirTownHall3.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N026_THOUSAND_NEEDLES));
      AddObjective(new ObjectiveControlPoint(UNIT_N022_STONEMAUL));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll,
        filterUnit => filterUnit.GetTypeId() != FourCC("ngme"));

    }

    /// <inheritdoc />
    public override string RewardFlavour => "The Throne of the Four Winds have joined us";

    /// <inheritdoc />
    protected override string RewardDescription => $"Gain Control of all buildings in the Throne of the Four Winds";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction) => 
      completingFaction.Player.RescueGroup(_rescueUnits);
  }
}