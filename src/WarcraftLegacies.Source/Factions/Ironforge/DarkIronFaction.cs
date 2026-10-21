using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>The Dark Iron dwarves under Dagran Thaurissan, risen from the ashes of Ironforge.</summary>
public sealed class DarkIronFaction : Faction
{
  private static readonly Dictionary<int, int> _darkIronEquivalents = new()
  {
    { UNIT_H019_MASON_IRONFORGE_WORKER, UNIT_H0CT_DARK_IRON_MASON_DARKIRON_WORKER },
    { UNIT_H037_ENGINEER_IRONFORGE_ELITE, UNIT_N0F0_SHADOWFORGE_GATEBREAKER_DARKIRON_ELITE },
    { UNIT_N00C_RUNE_PRIEST_IRONFORGE, UNIT_H0AB_SHADOWCASTER_DARKIRON },
    { UNIT_H01P_STEAM_TANK_IRONFORGE, UNIT_H0AA_MAGMA_TANK_DARKIRON },
    { UNIT_H07C_MUSTERING_HALL_IRONFORGE_BARRACKS, UNIT_O067_DUNGEON_CREEP_BARRACKS },
    { UNIT_H048_FORGEWORKS_IRONFORGE_RESEARCH, UNIT_O068_QUARRY_CREEP_RESEARCH },
    { UNIT_H042_PINNACLE_IRONFORGE_MAGIC, UNIT_O069_DARK_CONCLAVE_CREEP_MAGIC }
  };

  private static readonly HashSet<int> _leftBehind = new()
  {
    UNIT_H00S_KING_OF_KHAZ_MODAN_IRONFORGE,
    UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_IRONFORGE,
    UNIT_H028_THANE_OF_AERIE_PEAK_IRONFORGE
  };

  /// <summary>Creates the Dark Iron with whatever <paramref name="ironforge"/> can currently build, train and research.</summary>
  public DarkIronFaction(Faction ironforge)
    : base("Dark Iron", playercolor.Peanut, @"ReplaceableTextures\CommandButtons\BTNRPGDarkIron.blp")
  {
    TraditionalTeam = TeamSetup.Legion;
    ControlPointDefenderUnitTypeId = ironforge.ControlPointDefenderUnitTypeId;
    CinematicMusic = "DarkAgents";
    FoodMaximum = ironforge.FoodMaximum;
    Nicknames = new List<string>
    {
      "di",
      "darkiron"
    };

    var ironforgeObjectInfo = IronforgeObjectInfo.GetAllObjectLimits()
      .Where(x => !_leftBehind.Contains(x.ObjectTypeId))
      .ToList();
    ProcessObjectInfo(ironforgeObjectInfo.Select(ToDarkIronEquivalent));
    foreach (var objectInfo in ironforgeObjectInfo)
    {
      SetObjectLimit(GetDarkIronEquivalent(objectInfo.ObjectTypeId), ironforge.GetObjectLimit(objectInfo.ObjectTypeId));
    }

    foreach (var (objectId, limit) in ironforge.GetAllObjectLimits())
    {
      if (!_leftBehind.Contains(objectId))
      {
        SetObjectLimit(GetDarkIronEquivalent(objectId), limit);
      }
    }

    SetObjectLimit(UNIT_H03G_EMPEROR_OF_BLACKROCK_IRONFORGE, 1);
    SetObjectLimit(UNIT_H0CU_QUEEN_OF_THE_DARK_IRON_DARKIRON, 1);
    SetObjectLimit(UNIT_H0CV_GENERAL_OF_THE_DARK_IRON_DARKIRON, 1);
  }

  /// <summary>The Dark Iron version of an Ironforge unit, or the unit itself if they share it.</summary>
  public static int GetDarkIronEquivalent(int objectId) =>
    _darkIronEquivalents.GetValueOrDefault(objectId, objectId);

  /// <summary>Every Ironforge unit and building the Dark Iron replace with one of their own.</summary>
  public static IReadOnlyDictionary<int, int> UnitEquivalents => _darkIronEquivalents;

  private static ObjectInfo ToDarkIronEquivalent(ObjectInfo objectInfo) =>
    new(GetDarkIronEquivalent(objectInfo.ObjectTypeId), objectInfo.Limit, objectInfo.Categories,
      objectInfo.LimitIncreaseHint);
}
