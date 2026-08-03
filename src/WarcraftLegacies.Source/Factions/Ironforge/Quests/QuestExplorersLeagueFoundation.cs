using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

public sealed class QuestExplorersLeagueFoundation : QuestData
{
  private readonly ObjectiveAnyUnitInRect _heroEnteringRegion;
  private readonly RegionModel _expeditionRegion;

  public QuestExplorersLeagueFoundation() : base("Explorer's League Foundation",
  "The Explorer's League has been established in Ironforge, and they have set out on their first expedition.",
  @"ReplaceableTextures\CommandButtons\BTNGatherGold.blp")
  {
    Knowledge = 5;
    _expeditionRegion = GetRandomRegion();
    AddObjective(new ObjectiveControlPoint(_expeditionRegion.ControlPointId));
    _heroEnteringRegion = new ObjectiveAnyUnitInRect(_expeditionRegion.Region, _expeditionRegion.Name, true);
    AddObjective(_heroEnteringRegion);
  }

  public override string RewardFlavour => Loc.Format(
    "{hero} has overseen the expedition at {region} and the archaeologists have taken the relics back to Ironforge to study.",
    ("{hero}", _heroEnteringRegion.CompletingUnitName), ("{region}", Loc.Get(_expeditionRegion.Name)));

  public static RegionModel GetRandomRegion()
  {
    var regions = new List<Rectangle>() {
      Regions.DrownedTemple,
      Regions.ZulGurub,
    };

    var chosenRegion = regions[GetRandomInt(0, regions.Count - 1)];

    if (chosenRegion == Regions.DrownedTemple)
    {
      return new RegionModel()
      {
        Region = chosenRegion,
        Name = "Sunken Temple",
        ControlPointId = UNIT_N00U_SWAMP_OF_SORROWS
      };
    }

    if (chosenRegion == Regions.ZulGurub)
    {
      return new RegionModel()
      {
        Region = chosenRegion,
        Name = "Zul'Gurub",
        ControlPointId = UNIT_N00W_ZUL_GURUB
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
  }
}
