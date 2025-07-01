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
  public sealed class QuestShimmering : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestShimmering"/> class.
    /// </summary>
    public QuestShimmering(Rectangle Skywallshimmering) : base("Shimmering Flats",
      "With our lands secured we must establish a forward base.",
      @"ReplaceableTextures\CommandButtons\BTNPavilion.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N0BN_SHIMMERING_FLATS));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = Skywallshimmering.PrepareUnitsForRescue(RescuePreparationMode.HideAll);

    }

    /// <inheritdoc />
    public override string RewardFlavour => "The hostile wild life has been eliminated";

    /// <inheritdoc />
    protected override string RewardDescription => "Gain Control all buildings in Shimmering Flats";

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