using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
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
        BlzPauseUnitEx(unit, false);
      }
      
      if (_feathermoon.Unit != null && GetUnitState(_feathermoon.Unit, UNIT_STATE_LIFE) > 0)
      {
        _feathermoon.Unit.SetLifePercent(100);
        BlzPauseUnitEx(_feathermoon.Unit, false);
      }
    }

    protected override void OnFail(Faction failingFaction)
    {
      var rescuer = failingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : failingFaction.Player;
      
      rescuer.RescueGroup(_rescueUnits);
      
      foreach (var unit in _rescueUnits)
      {
        BlzPauseUnitEx(unit, false);
      }

      if (_feathermoon.Unit != null && GetUnitState(_feathermoon.Unit, UNIT_STATE_LIFE) > 0)
      {
        _feathermoon.Unit.SetLifePercent(100);
        BlzPauseUnitEx(_feathermoon.Unit, false);
      }
    }
  }
}