using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

public sealed class QuestExplorersLeagueKalimdorExpedition : QuestData
{
  private readonly ObjectiveAnyUnitReachRect _heroEnteringRegionNorth;
  private readonly ObjectiveAnyUnitReachRect _heroEnteringRegionSouth;
  private readonly RegionModel _expeditionRegionNorth;
  private readonly RegionModel _expeditionRegionSouth;
  private readonly int _goldReward = 500;


  public QuestExplorersLeagueKalimdorExpedition() : base("Explorer's League Kalimdor Expedition",
  "The Explorer's League have identified areas of interest in the foreign lands of Kalimdor. We should set forth on another expedition to uncover their secrets.",
  @"ReplaceableTextures\CommandButtons\BTNGatherGold.blp")
  {
    Knowledge = 30;
    _expeditionRegionNorth = GetRandomRegionNorth();
    AddObjective(new ObjectiveControlPoint(_expeditionRegionNorth.ControlPointId));
    _heroEnteringRegionNorth = new ObjectiveAnyUnitReachRect(_expeditionRegionNorth.Region, _expeditionRegionNorth.Name, true);
    AddObjective(_heroEnteringRegionNorth);
    _expeditionRegionSouth = GetRandomRegionSouth();
    AddObjective(new ObjectiveControlPoint(_expeditionRegionSouth.ControlPointId));
    _heroEnteringRegionSouth = new ObjectiveAnyUnitReachRect(_expeditionRegionSouth.Region, _expeditionRegionSouth.Name, true);
    AddObjective(_heroEnteringRegionSouth);
  }

  public override string RewardFlavour => _heroEnteringRegionNorth.CompletingUnitName == _heroEnteringRegionSouth.CompletingUnitName
        ? $"{_heroEnteringRegionNorth.CompletingUnitName} has overseen the expeditions at {_expeditionRegionNorth.Name} and {_expeditionRegionSouth.Name}. The archaeologists have taken the valuable relics back to Ironforge to study and sell."
        : $"{_heroEnteringRegionNorth.CompletingUnitName} has overseen the expedition at {_expeditionRegionNorth.Name}, while {_heroEnteringRegionSouth.CompletingUnitName} has overseen the expedition at {_expeditionRegionSouth.Name}. The archaeologists have taken the valuable relics back to Ironforge to study and sell.";

  protected override string RewardDescription => $"Gain {_goldReward} gold.";

  public static RegionModel GetRandomRegionNorth()
  {
    var regionsNorth = new List<Rectangle>() {
      Regions.AzsharaAmbient2,
      Regions.Stonetalon_Peak,
    };

    var chosenRegion = regionsNorth[GetRandomInt(0, regionsNorth.Count - 1)];
    chosenRegion = Regions.Stonetalon_Peak;

    if (chosenRegion == Regions.AzsharaAmbient2)
    {
      return new RegionModel()
      {
        Region = chosenRegion,
        Name = "Eldarath",
        ControlPointId = UNIT_N09R_ELDARATH
      };
    }

    if (chosenRegion == Regions.Stonetalon_Peak)
    {
      return new RegionModel()
      {
        Region = chosenRegion,
        Name = "Stonetalon Peak",
        ControlPointId = UNIT_N01U_STONETALON_PEAK
      };
    }

    return null;
  }

  public static RegionModel GetRandomRegionSouth()
  {
    var regionsSouth = new List<Rectangle>() {
      Regions.TheAthenaeum,
      Regions.Zulfarrak,
    };

    var chosenRegion = regionsSouth[GetRandomInt(0, regionsSouth.Count - 1)];

    if (chosenRegion == Regions.TheAthenaeum)
    {
      return new RegionModel()
      {
        Region = chosenRegion,
        Name = "Dire Maul",
        ControlPointId = UNIT_N06Q_DIRE_MAUL
      };
    }

    if (chosenRegion == Regions.Zulfarrak)
    {
      return new RegionModel()
      {
        Region = chosenRegion,
        Name = "Zul'Farrak",
        ControlPointId = UNIT_N092_ZUL_FARRAK
      };
    }

    return null;
  }

  public class RegionModel
  {
    public required Rectangle Region { get; init; }
    public required string Name { get; init; }
    public required int ControlPointId { get; init; }
  }

  protected override void OnComplete(Faction whichFaction)
  {
    if (whichFaction.Player != null)
    {
      whichFaction.Player.Gold += _goldReward;
    }
  }
}
