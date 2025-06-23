using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Rocks;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Gilneas
{
  /// <summary>
  /// Take Durnholde control point and upgrade the main building to Tier 3 in order to unlock Gilneas City and the Greymane Wall.
  /// </summary>
  public sealed class QuestGilneasCity : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGilneasCity"/> class.
    /// </summary>
    public QuestGilneasCity(Rectangle rescueRect1) : base("Gilneas City",
      "Before the first war with the orcs southern Lordaeron was under our control, we must reclaim it.",
      @"ReplaceableTextures\CommandButtons\BTNGilneasCathedral.blp")
    {
      _rescueUnits = new List<unit>();
      _rescueUnits.AddRange(rescueRect1.PrepareUnitsForRescue(RescuePreparationMode.HideAll, RescuableFilter));

      AddObjective(new ObjectiveControlPoint(UNIT_N018_DURNHOLDE));
      AddObjective(new ObjectiveUpgrade(UNIT_H02C_CASTLE_GILNEAS_T3, UNIT_H01R_TOWN_HALL_GILNEAS_T1));
      AddObjective(new ObjectiveExpire(660, "Liberation of Gilneas"));
      AddObjective(new ObjectiveSelfExists());

      ResearchId = UPGRADE_R02R_QUEST_COMPLETED_LIBERATION_OF_GILNEAS;
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "Southern Lordaeron has been Secured, The Cursed Kingdom rallies to our cause!";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain control of the Greymane Wall and Gilneas City. Enable to train Genn Greymane and the Worgen units.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits)
        unit.Rescue(completingFaction.Player);
      completingFaction.Player?.PlayMusicThematic("war3mapImported\\GilneasTheme1.mp3");

      RockSystem.Register(new RockGroup(Regions.GilneasUnlock5, FourCC("LTrc"), 1));
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      if (completingFaction.Player == null)
        return;

      RockSystem.Register(new RockGroup(Regions.GilneasUnlock5, FourCC("LTrc"), 1));

      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    private static bool RescuableFilter(unit filterUnit) => filterUnit.GetTypeId() != UNIT_O05Q_GREYMANETOWER_GILNEAS_REAL_TOWER;
  }
}
