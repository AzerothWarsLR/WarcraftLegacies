using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  /// <summary>
  /// Unlocks Feathermoon Stronghold upon securing the area and bringing a hero to it.
  /// </summary>
  public sealed class QuestFeathermoon : QuestData
  {
    /// <summary>
    /// Initializes a new instance of <see cref="QuestFeathermoon"/>.
    /// </summary>
    public QuestFeathermoon(Capital feathermoon) : base("Shores of Feathermoon",
      "Feathermoon Stronghold will undoublty fall to the assault of the Old gods, we will need to recapture it. ",
      @"ReplaceableTextures\CommandButtons\BTNBearDen.blp")
    {
      AddObjective(new ObjectiveControlCapital(feathermoon, false));
      AddObjective(new ObjectiveControlPoint(UNIT_N05U_FEATHERMOON_STRONGHOLD));
      ResearchId = UPGRADE_R06M_QUEST_COMPLETED_SHORES_OF_FEATHERMOON;
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "Feathermoon Stronghold has been recaptured and has joined the Sentinels in their war effort";

    /// <inheritdoc />
    protected override string RewardDescription => 
      $"Learn to train Naisha from the {GetObjectName(UNIT_E00R_ALTAR_OF_WATCHERS_SENTINEL_ALTAR)}";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;
    }
  }
}