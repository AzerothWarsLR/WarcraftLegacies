using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Ironforge
{
  public sealed class QuestDunMorogh : QuestData
  {
    private readonly List<unit> _rescueUnits;

    public QuestDunMorogh() : base("Mountain Village",
      "A small troll skirmish is attacking Dun Morogh. Push them back!",
      @"ReplaceableTextures\CommandButtons\BTNIceTrollShadowPriest.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N014_DUN_MOROGH));
      AddObjective(new ObjectiveExpire(660, Title));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = Regions.DunmoroghAmbient2.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "The Trolls have been defeated, Dun Morogh will join your cause.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all units in Dun Morogh";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) => completingFaction.Player.RescueGroup(_rescueUnits);
  }
}