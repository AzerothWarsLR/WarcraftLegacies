using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Shared;
using MacroTools.Utils;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Forsaken;

/// <summary>The bases the Forsaken get: the Undercity beneath Capital City, and an outpost in Orgrimmar.</summary>
public sealed class ForsakenBases
{
  private const float NorthrendBaseRadius = 1200;
  private const float Facing = 90;
  private const float StructureSize = 256;

  private static Dictionary<int, int> ForsakenEquivalents => UnitEquivalents.Pair(
    ScourgeObjectInfo.GetAllObjectLimits(), ForsakenObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>
    {
      { UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, UNIT_H08E_DREAD_TOWER_FORSAKEN },
      { UNIT_UZG2_NERUBIAN_TOWER_SCOURGE_TOWER, UNIT_H08E_DREAD_TOWER_FORSAKEN },
      { UNIT_U002_IMPROVED_SPIRIT_TOWER_SCOURGE_TOWER, UNIT_H08F_IMPROVED_DREAD_TOWER_FORSAKEN },
      { UNIT_U003_IMPROVED_NERUBIAN_TOWER_SCOURGE_TOWER, UNIT_H08F_IMPROVED_DREAD_TOWER_FORSAKEN },
      { UNIT_UBON_BONEYARD_SCOURGE_SIEGE, UNIT_U01W_ROYAL_SEPULCRUM_FORSAKEN }
    });

  private readonly player _forsaken;
  private readonly string _palaceName = AllLegends.Lordaeron.CapitalPalace.Unit.Name;

  public ForsakenBases(player forsaken)
  {
    _forsaken = forsaken;
  }

  /// <summary>Swaps the Forsaken's Scourge buildings and acolytes for their own.</summary>
  public void ConvertScourgeBuildings()
  {
    var forsakenEquivalents = ForsakenEquivalents;
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(_forsaken))
    {
      if (!whichUnit.Alive || !whichUnit.IsRemovable() || !IsBuildingOrWorker(whichUnit))
      {
        continue;
      }

      if (!forsakenEquivalents.TryGetValue(whichUnit.UnitType, out var forsakenType))
      {
        continue;
      }

      var x = whichUnit.X;
      var y = whichUnit.Y;
      var facing = whichUnit.Facing;
      var lifePercent = whichUnit.Life / whichUnit.MaxLife;
      whichUnit.Dispose();
      var replacement = unit.Create(_forsaken, forsakenType, x, y, facing);
      replacement.Life = replacement.MaxLife * lifePercent;
    }
  }

  /// <summary>Names the Capital Palace "Undercity" whenever the Forsaken hold it.</summary>
  public void TrackPalaceName()
  {
    RefreshPalaceName();
    AllLegends.Lordaeron.CapitalPalace.ChangedOwner += _ => RefreshPalaceName();
  }

  private void RefreshPalaceName()
  {
    var palace = AllLegends.Lordaeron.CapitalPalace.Unit;
    palace.Name = palace.Owner == _forsaken ? Loc.Get("Undercity") : _palaceName;
  }

  /// <summary>Moves the Forsaken out of Northrend and into an outpost inside Orgrimmar.</summary>
  public void MoveToOrgrimmar()
  {
    PathBase.CreateStructure(_forsaken, UNIT_H08B_HAUNTED_CASTLE_FORSAKEN, -8736, -480);
    PathBase.CreateStructure(_forsaken, UNIT_U011_WAR_QUARTER_FORSAKEN, -8288, -608);
    PathBase.CreateStructure(_forsaken, UNIT_H08C_GRAVE_FORSAKEN, -9120, -800);
    PathBase.CreateStructure(_forsaken, UNIT_H08C_GRAVE_FORSAKEN, -8864, -864);
    PathBase.CreateStructure(_forsaken, UNIT_H08E_DREAD_TOWER_FORSAKEN, -8992, -1056);

    var center = BansheesHostTransformation.NorthrendBase.Center;
    var northrendBase = new Rectangle(center.X - NorthrendBaseRadius, center.Y - NorthrendBaseRadius,
      center.X + NorthrendBaseRadius, center.Y + NorthrendBaseRadius);
    foreach (var whichUnit in GlobalGroup.EnumUnitsInRect(northrendBase))
    {
      if (whichUnit.Owner != _forsaken)
      {
        continue;
      }

      if (whichUnit.IsControlPoint())
      {
        whichUnit.SetOwner(GetScourgePlayer());
      }
      else if (!whichUnit.IsUnitType(unittype.Structure))
      {
        whichUnit.SetPosition(-8600, -150);
      }
      else if (whichUnit.IsRemovable())
      {
        whichUnit.SafelyRemove();
      }
    }
  }

  private static bool IsBuildingOrWorker(unit whichUnit) =>
    whichUnit.IsUnitType(unittype.Structure) || whichUnit.IsUnitType(unittype.Peon);

  private static player GetScourgePlayer() =>
    FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge) && scourge.Player != null
      ? scourge.Player
      : player.NeutralAggressive;

  /// <summary>Builds the Undercity inside the Capital Palace's walls, guarded by towers that protect the palace.</summary>
  public void BuildUndercity()
  {
    CapitalPalaceRuins.Claim(_forsaken, UNIT_H08C_GRAVE_FORSAKEN);
    CreateStructureForced(_forsaken, UNIT_U011_WAR_QUARTER_FORSAKEN, 8288, 8800, Facing, StructureSize);
    CreateStructureForced(_forsaken, UNIT_U010_ALTAR_OF_THE_QUEEN_FORSAKEN, 9888, 8672, Facing, StructureSize);
    CreateStructureForced(_forsaken, UNIT_U016_FORBIDDEN_ARCHIVE_FORSAKEN, 9888, 8352, Facing, StructureSize);
    CreateProtector(8704, 8832);
    CreateProtector(9472, 8832);
    CreateProtector(8640, 9472);
    CreateProtector(9536, 9472);
  }

  private void CreateProtector(float x, float y)
  {
    CapitalPalaceRuins.ClearTowerSpot(x, y);
    var tower = CreateStructureForced(_forsaken, UNIT_H08F_IMPROVED_DREAD_TOWER_FORSAKEN, x, y, Facing, StructureSize);
    if (tower != null)
    {
      AllLegends.Lordaeron.CapitalPalace.AddProtector(tower);
    }
  }
}
