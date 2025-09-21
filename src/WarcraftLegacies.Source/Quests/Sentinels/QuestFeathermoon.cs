using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Sentinels;

public sealed class QuestFeathermoon : QuestData
{
  private List<unit> _rescueUnits;
  private readonly Capital _feathermoon;

  public QuestFeathermoon(Capital feathermoon, Rectangle rescueRect)
    : base(
      "Shores of Feathermoon",
      "Without aid from the primary Sentinel force, Feathermoon Stronghold will undoubtedly fall to the assault of the Old Gods. We will need to restore it.",
      @"ReplaceableTextures\CommandButtons\BTNBearDen.blp")
  {
    _feathermoon = feathermoon;

    AddObjective(new ObjectiveBuildUniqueBuildingsInRect(Regions.FeathermoonUnlock, "in Feathermoon", 3));
    AddObjective(new ObjectiveControlPoint(UNIT_N05U_FEATHERMOON));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R06M_QUEST_COMPLETED_SHORES_OF_FEATHERMOON;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  public override string RewardFlavour =>
    "The Sentinels have rebuilt Feathermoon Stronghold to its former glory. Maiev Shadowsong now joins their efforts.";

  protected override string RewardDescription =>
    $"Learn to train Maiev Shadowsong from the {GetObjectName(UNIT_E00R_ALTAR_OF_WATCHERS_SENTINEL_ALTAR)} and gain control of the survivors hiding in Feathermoon.";

  protected override void OnAdd(Faction whichFaction)
  {
    _rescueUnits = Regions.FeathermoonUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);

    foreach (var unit in _rescueUnits)
    {
      unit.SetPausedEx(false);
    }

    if (_feathermoon.Unit != null && _feathermoon.Unit.Alive)
    {
      _feathermoon.Unit.SetLifePercent(100);
      _feathermoon.Unit.Rescue(completingFaction.Player ?? player.NeutralAggressive);
    }
  }

  protected override void OnFail(Faction failingFaction)
  {
    var rescuer = failingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : failingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);

    foreach (var unit in _rescueUnits)
    {
      unit.SetPausedEx(false);
    }

    if (_feathermoon.Unit != null && _feathermoon.Unit.Alive)
    {
      _feathermoon.Unit.SetLifePercent(100);
      _feathermoon.Unit.Rescue(player.NeutralAggressive);
    }
  }
}
