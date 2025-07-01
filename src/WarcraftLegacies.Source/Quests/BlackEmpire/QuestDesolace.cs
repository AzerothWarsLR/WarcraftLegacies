using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  public sealed class QuestDesolace : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestDesolace"/> class.
    /// </summary>
    public QuestDesolace(Rectangle Desolace) : base("Desolace",
      "We must establish a forward base in Desolace to stop Night elf incursions.",
      @"ReplaceableTextures\CommandButtons\BTNCentaurKhan.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N01Y_DESOLACE));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = Desolace.PrepareUnitsForRescue(RescuePreparationMode.HideAll);

    }

    /// <inheritdoc />
    public override string RewardFlavour => "With the local centaurs destroyed we can establish an outpost.";

    /// <inheritdoc />
    protected override string RewardDescription => "Gain control of all buildings in Desolace";

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