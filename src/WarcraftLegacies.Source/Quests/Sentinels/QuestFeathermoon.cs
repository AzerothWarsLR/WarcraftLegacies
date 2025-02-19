using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  /// <summary>
  /// Unlocks Feathermoon Stronghold upon securing the area and bringing a hero to it.
  /// </summary>
  public sealed class QuestFeathermoon : QuestData
  {
    private List<unit> _rescueUnits = new();

    /// <summary>
    /// Initializes a new instance of <see cref="QuestFeathermoon"/>.
    /// </summary>
    public QuestFeathermoon() : base("Shores of Feathermoon",
      "Without aid from the primary Sentinel force, Feathermoon Stronghold will undoubtedly fall to the assault of the Old Gods. We will need to recapture it.",
      @"ReplaceableTextures\CommandButtons\BTNBearDen.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N05U_FEATHERMOON_STRONGHOLD));
      AddObjective(new ObjectiveExpire(1200, Title));
      ResearchId = UPGRADE_R06M_QUEST_COMPLETED_SHORES_OF_FEATHERMOON;
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "Those stationed at Feathermoon Stronghold were among the first casualties claimed by the Black Empire. With the base recaptured, the process of avenging them can begin.";

    /// <inheritdoc />
    protected override string RewardDescription => 
      $"Learn to train Maiev from the {GetObjectName(UNIT_E00R_ALTAR_OF_WATCHERS_SENTINEL_ALTAR)} and gain control of Feathermoon Stronghold";

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      _rescueUnits = Regions.FeathermoonUnlock.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
    
    /// <inheritdoc />
    protected override void OnFail(Faction failingFaction)
    {
      var rescuer = failingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : failingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }
  }
}