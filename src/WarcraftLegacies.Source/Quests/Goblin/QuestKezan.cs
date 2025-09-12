using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Goblin
{
  /// <summary>
  /// The Goblins can acquire Kezan.
  /// </summary>
  public sealed class QuestKezan : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestKezan"/>.
    /// </summary>
    public QuestKezan() : base("Offshore Investment",
      "The island of Kezan would be an ideal seat of power for the Bilgewater trade empire, but first we must secure a foothold on Kalimdor.",
      @"ReplaceableTextures\CommandButtons\BTNIronHordeMerchant.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N092_ZUL_FARRAK));
      AddObjective(new ObjectiveControlPoint(UNIT_N0BK_LOST_CITY_OF_THE_TOL_VIR));
      AddObjective(new ObjectiveControlPoint(UNIT_N025_UN_GORO_CRATER));
      AddObjective(new ObjectiveUpgrade(UNIT_O03N_FORTRESS_GOBLIN_T3, UNIT_O03L_GREAT_HALL_GOBLIN_T1));
      AddObjective(new ObjectiveSelfExists());
      
      ResearchId = UPGRADE_R09Z_QUEST_COMPLETED_OFFSHORE_INVESTMENT;
      _rescueUnits = Regions.KezanUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures,
        filterUnit => GetUnitTypeId(filterUnit) != FourCC("ngme"));
    }

    /// <inheritdoc />
    public override string RewardFlavour => "With trade now able to flow into and out of Kalimdor, the goblins of Kezan are now all but forced to join the Bilgewater cartel.";

    /// <inheritdoc />
    protected override string RewardDescription => "Gain control of Kezan, and learn to train Gallywix at the Altar of Industry";

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
      completingFaction.Player
        .RescueGroup(_rescueUnits)
        .PlayMusicThematic("war3mapImported\\GoblinTheme.mp3");
    }
  }
}