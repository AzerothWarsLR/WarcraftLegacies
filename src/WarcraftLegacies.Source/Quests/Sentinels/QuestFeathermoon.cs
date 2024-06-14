using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  /// <summary>
  /// Unlocks Feathermoon Stronghold upon securing the area and bringing a hero to it.
  /// </summary>
  public sealed class QuestFeathermoon : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of <see cref="QuestFeathermoon"/>.
    /// </summary>
    public QuestFeathermoon(Rectangle rescueRect) : base("Shores of Feathermoon",
      "Feathermoon Stronghold stood guard for ten thousand years, it is time to relieve the guards from their duty.",
      @"ReplaceableTextures\CommandButtons\BTNBearDen.blp")
    {
      AddObjective(new ObjectiveAnyUnitInRect(rescueRect, "Feathermoon Stronghold", true));
      AddObjective(new ObjectiveHostilesInAreaAreDead(new List<Rectangle> { Regions.FeathermoonCreeps }, "around Feathermoon Stronghold"));
      AddObjective(new ObjectiveExpire(480, Title));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = UPGRADE_R06M_QUEST_COMPLETED_SHORES_OF_FEATHERMOON;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
      
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "Feathermoon Stronghold has been relieved and has joined the Sentinels in their war effort";

    /// <inheritdoc />
    protected override string RewardDescription => 
      $"Gain control of all units in Feathermoon Stronghold, learn to train {GetObjectName(UNIT_EBAL_GLAIVE_THROWER_SENTINELS)}s from the {GetObjectName(UNIT_E00L_WAR_ACADEMY_SENTINEL_BARRACKS)}, and learn to train Tyrande from the {GetObjectName(UNIT_E00R_ALTAR_OF_WATCHERS_SENTINEL_ALTAR)}";

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
      completingFaction.Player?
        .RescueGroup(_rescueUnits)
        .PlayMusicThematic("war3mapImported\\SentinelTheme.mp3");
    }
  }
}