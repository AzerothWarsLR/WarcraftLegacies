using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Forsaken;

/// <summary>The bases the Forsaken get: the Undercity beneath Capital City, and an outpost in Orgrimmar.</summary>
public sealed class ForsakenBases
{
  private const float NorthrendBaseRadius = 1200;

  private static readonly Dictionary<int, int> ForsakenEquivalents = new()
  {
    { UNIT_UNPL_NECROPOLIS_SCOURGE_T1, UNIT_H089_DARK_MANSION_FORSAKEN },
    { UNIT_UNP1_HALLS_OF_THE_DEAD_SCOURGE_T2, UNIT_H08A_GRIM_ESTATE_FORSAKEN },
    { UNIT_UNP2_BLACK_CITADEL_SCOURGE_T3, UNIT_H08B_HAUNTED_CASTLE_FORSAKEN },
    { UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, UNIT_H08C_GRAVE_FORSAKEN },
    { UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, UNIT_H08E_PLAGUE_TOWER_FORSAKEN },
    { UNIT_UZG2_NERUBIAN_TOWER_SCOURGE_TOWER, UNIT_H08E_PLAGUE_TOWER_FORSAKEN },
    { UNIT_U002_IMPROVED_SPIRIT_TOWER_SCOURGE_TOWER, UNIT_H08F_IMPROVED_PLAGUE_TOWER_FORSAKEN },
    { UNIT_U003_IMPROVED_NERUBIAN_TOWER_SCOURGE_TOWER, UNIT_H08F_IMPROVED_PLAGUE_TOWER_FORSAKEN },
    { UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, UNIT_U010_ALTAR_OF_THE_QUEEN_FORSAKEN },
    { UNIT_USEP_CRYPT_SCOURGE_BARRACKS, UNIT_U011_PLAGUETORIUM_FORSAKEN },
    { UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, UNIT_U01J_GRAVEYARD_FORSAKEN },
    { UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, UNIT_U014_LABORATORY_FORSAKEN },
    { UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, UNIT_U016_FORBIDDEN_ARCHIVE_FORSAKEN },
    { UNIT_UBON_BONEYARD_SCOURGE_SIEGE, UNIT_U01W_ROYAL_SEPULCRUM_FORSAKEN },
    { UNIT_UTOM_TOMB_OF_RELICS_SCOURGE_SHOP, UNIT_U017_FORSAKEN_DEN_FORSAKEN },
    { UNIT_USHP_HAUNTED_HARBOR_SCOURGE_SHIPYARD, UNIT_U01A_HAUNTED_HARBOR_FORSAKEN },
    { UNIT_UACO_ACOLYTE_SCOURGE_WORKER, UNIT_U01K_ACOLYTE_FORSAKEN_CULT_WORKER }
  };

  private readonly player _forsaken;
  private readonly string _palaceName = AllLegends.Lordaeron.CapitalPalace.Unit.Name;
  private bool _undercityClaimed;

  public ForsakenBases(player forsaken)
  {
    _forsaken = forsaken;
  }

  /// <summary>Swaps the Forsaken's Scourge buildings and acolytes for their own.</summary>
  public void ConvertScourgeBuildings()
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(_forsaken))
    {
      if (!whichUnit.Alive || !whichUnit.IsRemovable())
      {
        continue;
      }

      if (!ForsakenEquivalents.TryGetValue(whichUnit.UnitType, out var forsakenType))
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

  /// <summary>
  /// Gives the Forsaken the Undercity once Capital City is in friendly hands: straight away if it already is,
  /// otherwise as soon as their team takes it.
  /// </summary>
  /// <param name="teammatesCountNow">Whether a teammate holding Capital City right now is enough.</param>
  public void ClaimUndercity(bool teammatesCountNow)
  {
    TryClaimUndercity(teammatesCountNow);
    RefreshPalaceName();
    AllLegends.Lordaeron.CapitalPalace.ChangedOwner += _ =>
    {
      TryClaimUndercity(true);
      RefreshPalaceName();
    };
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
    PathBase.CreateStructure(_forsaken, UNIT_U011_PLAGUETORIUM_FORSAKEN, -8288, -608);
    PathBase.CreateStructure(_forsaken, UNIT_H08C_GRAVE_FORSAKEN, -9120, -800);
    PathBase.CreateStructure(_forsaken, UNIT_H08C_GRAVE_FORSAKEN, -8864, -864);
    PathBase.CreateStructure(_forsaken, UNIT_H08E_PLAGUE_TOWER_FORSAKEN, -8992, -1056);

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

  private static player GetScourgePlayer() =>
    FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge) && scourge.Player != null
      ? scourge.Player
      : player.NeutralAggressive;

  private void TryClaimUndercity(bool teammatesCount)
  {
    var palace = AllLegends.Lordaeron.CapitalPalace.Unit;
    if (_undercityClaimed || !palace.Alive || !(_forsaken.GetPlayerData().Faction is ForsakenFaction))
    {
      return;
    }

    var holder = palace.Owner;
    if (holder != _forsaken && !(teammatesCount && TeamChanges.AreTeammates(holder, _forsaken)))
    {
      return;
    }

    _undercityClaimed = true;
    if (holder != _forsaken)
    {
      palace.SetOwner(_forsaken);
    }

    PathBase.CreateStructure(_forsaken, UNIT_H08S_UNDERCITY_FORSAKEN, 8384, 9216);
    PathBase.CreateStructure(_forsaken, UNIT_H08C_GRAVE_FORSAKEN, 8704, 9216);
    PathBase.CreateStructure(_forsaken, UNIT_H08C_GRAVE_FORSAKEN, 9472, 9216);
    PathBase.CreateStructure(_forsaken, UNIT_U011_PLAGUETORIUM_FORSAKEN, 9792, 9216);
    PathBase.CreateStructure(_forsaken, UNIT_U01J_GRAVEYARD_FORSAKEN, 9760, 7808);

    var message = Loc.Get("The Forsaken descend into the catacombs beneath Capital City, and make the Undercity their home.");
    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffffcc00{Loc.Get("THE UNDERCITY")}|r\n{message}");
    }
  }
}
