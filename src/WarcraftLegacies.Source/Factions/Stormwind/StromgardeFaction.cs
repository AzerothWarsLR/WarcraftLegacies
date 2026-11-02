using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Stormwind;

/// <summary>The kingdom of Stromgarde under the Trollbanes, who carry on after Stormwind is lost.</summary>
public sealed class StromgardeFaction : Faction
{
  private static readonly Dictionary<int, int> _stromgardeEquivalents = new()
  {
    { UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER, UNIT_H0G5_PEASANT_STROMGARDE_WORKER },
    { UNIT_H00A_SPEARMAN_STORMWIND, UNIT_H0G6_HIGHLAND_SPEARMAN_STROMGARDE },
    { UNIT_H02O_BLADESMAN_STORMWIND, UNIT_H0G7_STROMGARDE_SWORDSMAN_STROMGARDE },
    { UNIT_H04C_VANGUARD_STORMWIND, UNIT_H0G8_STROMGARDE_DEFENDER_STROMGARDE },
    { UNIT_H05N_MARKSMAN_STORMWIND, UNIT_H0G9_TROLL_HUNTER_STROMGARDE },
    { UNIT_H01B_OUTRIDER_STORMWIND, UNIT_H0GA_HIGHLAND_LANCER_STROMGARDE },
    { UNIT_H054_STORMWIND_KNIGHT_STORMWIND, UNIT_H0GB_KNIGHT_OF_STROMGARDE_STROMGARDE },
    { UNIT_H00J_CLERGYMAN_STORMWIND, UNIT_H0GC_PRIEST_STROMGARDE },
    { UNIT_N093_CHAPLAIN_STORMWIND, UNIT_N0Z9_BATTLEMAGE_STROMGARDE },
    { UNIT_N05L_CONJURER_STORMWIND_ELITE, UNIT_N0ZA_MAGUS_OF_STROMGARDE_STROMGARDE_ELITE },
    { UNIT_H05F_STORMWIND_CHAMPION_STORMWIND_ELITE, UNIT_H0GD_CHAMPION_OF_ARATHOR_STROMGARDE_ELITE },
    { UNIT_H03K_MARSHAL_STORMWIND, UNIT_H0GE_MARSHAL_STROMGARDE },
    { UNIT_H03U_REAR_MARSHAL_STORMWIND_DEFENSIVE, UNIT_H0GF_REAR_MARSHAL_STROMGARDE },
    { UNIT_O06K_SIEGE_TOWER_STORMWIND, UNIT_O20Y_MANGONEL_STROMGARDE },
    { UNIT_N06N_GUNSHIP_STORMWIND, UNIT_H0GG_GRYPHON_RIDER_STROMGARDE },
    { UNIT_H06K_TOWN_HALL_STORMWIND_T1, UNIT_H0FM_TOWN_HALL_STROMGARDE },
    { UNIT_H06M_KEEP_STORMWIND_T2, UNIT_H0FN_KEEP_STROMGARDE },
    { UNIT_H06N_CASTLE_STORMWIND_T3, UNIT_H0FO_CASTLE_STROMGARDE },
    { UNIT_H072_HOMESTEAD_STORMWIND_FARM, UNIT_H0FP_HOMESTEAD_STROMGARDE },
    { UNIT_H06T_ALTAR_OF_KINGS_STORMWIND_ALTAR, UNIT_H0FQ_ALTAR_OF_KINGS_STROMGARDE },
    { UNIT_H06E_BARRACKS_STORMWIND_BARRACKS, UNIT_H0FR_BARRACKS_STROMGARDE },
    { UNIT_H06F_BLACKSMITH_STORMWIND_RESEARCH, UNIT_H0FS_BLACKSMITH_STROMGARDE },
    { UNIT_H06A_SMITHY_STORMWIND_SPECIALIST, UNIT_H0FT_ARMORY_STROMGARDE },
    { UNIT_HARS_ARCANE_SANCTUM_STORMWIND_MAGIC, UNIT_H0FU_WIZARD_SANCTUM_STROMGARDE },
    { UNIT_H06D_ROYAL_HARBOUR_STORMWIND_SHIPYARD, UNIT_H0FV_SHIPYARD_STROMGARDE },
    { UNIT_N07T_AUCTION_HOUSE_STORMWIND_SHOP, UNIT_N0Z8_TRADE_HOUSE_STROMGARDE },
    { UNIT_H06V_SCOUT_TOWER_STORMWIND_TOWER, UNIT_H0FX_SCOUT_TOWER_STROMGARDE },
    { UNIT_H06W_GUARD_TOWER_STORMWIND_TOWER, UNIT_H0FY_GUARD_TOWER_STROMGARDE },
    { UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND_TOWER, UNIT_H0FZ_IMPROVED_GUARD_TOWER_STROMGARDE },
    { UNIT_H06X_CANNON_TOWER_STORMWIND_TOWER, UNIT_H0G0_CANNON_TOWER_STROMGARDE },
    { UNIT_H071_IMPROVED_CANNON_TOWER_STORMWIND_TOWER, UNIT_H0G1_IMPROVED_CANNON_TOWER_STROMGARDE },
    { UNIT_H06Y_ARCANE_TOWER_STORMWIND_TOWER, UNIT_H0G2_ARCANE_TOWER_STROMGARDE },
    { UNIT_H06Z_IMPROVED_ARCANE_TOWER_STORMWIND_TOWER, UNIT_H0G3_IMPROVED_ARCANE_TOWER_STROMGARDE }
  };

  private static readonly Dictionary<int, int> _researchEquivalents = new()
  {
    { UPGRADE_R030_CODE_OF_CHIVALRY_ARATHOR_T3, UPGRADE_R11Q_CODE_OF_CHIVALRY_STROMGARDE },
    { UPGRADE_R031_EXPEDITION_SURVIVORS_ARATHOR_T3, UPGRADE_R11R_EXPEDITION_SURVIVORS_STROMGARDE },
    { UPGRADE_R02Z_REFLECTIVE_PLATING_ARATHOR_T2, UPGRADE_R11S_REFLECTIVE_PLATING_STROMGARDE },
    { UPGRADE_R005_CLERGYMAN_ADEPT_TRAINING_ARATHOR, UPGRADE_R11T_PRIEST_ADEPT_TRAINING_STROMGARDE },
    { UPGRADE_R02E_LIGHT_S_PRAISE_ADEPT_TRAINING_ARATHOR_LORDAERON, UPGRADE_R11U_BATTLEMAGE_ADEPT_TRAINING_STROMGARDE },
    { UPGRADE_R03V_MAGES_OF_STROMGARDE_ARATHOR_T2, UPGRADE_R11W_MAGES_OF_STROMGARDE_STROMGARDE }
  };

  private static readonly HashSet<int> _leftBehind = new()
  {
    UNIT_H00R_KING_OF_STORMWIND_STORMWIND,
    UNIT_H017_HIGHLORD_OF_THE_ALLIANCE_STORMWIND,
    UNIT_H05Y_LORD_WIZARD_STORMWIND,
    UNIT_H060_CARRIER_FLAGSHIP_STORMWIND
  };

  /// <summary>Stromgarde units that capitals shared with other factions can train.</summary>
  public static readonly int[] CapitalUnits =
  {
    UNIT_H0G5_PEASANT_STROMGARDE_WORKER,
    UNIT_H0GD_CHAMPION_OF_ARATHOR_STROMGARDE_ELITE
  };

  /// <summary>Creates Stromgarde with whatever <paramref name="stormwind"/> can currently build, train and research.</summary>
  public StromgardeFaction(Faction stormwind)
    : base("Stromgarde", playercolor.LightGray, @"ReplaceableTextures\CommandButtons\BTNTheCaptain.blp")
  {
    TraditionalTeam = TeamSetup.NorthAlliance;
    ControlPointDefenderUnitTypeId = UNIT_H0G4_CONTROL_POINT_DEFENDER_STROMGARDE;
    CinematicMusic = stormwind.CinematicMusic;
    FoodMaximum = stormwind.FoodMaximum;
    Nicknames = new List<string>
    {
      "sg",
      "strom",
      "stromgarde"
    };

    ProcessObjectInfo(StormwindObjectInfo.GetAllObjectLimits()
      .Where(x => !_leftBehind.Contains(x.ObjectTypeId))
      .Select(ToStromgardeEquivalent));
    foreach (var (objectId, limit) in stormwind.GetAllObjectLimits())
    {
      if (!_leftBehind.Contains(objectId) && !CapitalUnits.Contains(objectId))
      {
        SetObjectLimit(GetStromgardeEquivalent(objectId), limit);
      }
    }

    SetObjectLimit(UNIT_O20Y_MANGONEL_STROMGARDE, 6);
    SetObjectLimit(UNIT_E03I_SCORPION_STROMGARDE, 8);
    SetObjectLimit(UPGRADE_R11U_BATTLEMAGE_ADEPT_TRAINING_STROMGARDE, 1);
    SetObjectLimit(UPGRADE_R11V_MAGUS_ADEPT_TRAINING_STROMGARDE, 2);
    SetObjectLimit(UNIT_H0CY_KING_OF_STROMGARDE_STROMGARDE, 1);
    SetObjectLimit(UNIT_H0CZ_COMMANDER_OF_THE_STROMGARDE_MILITIA_STROMGARDE, 1);
  }

  /// <summary>Every Stormwind unit and building Stromgarde replaces with one of its own.</summary>
  public static IReadOnlyDictionary<int, int> UnitEquivalents => _stromgardeEquivalents;

  /// <summary>Every Stormwind research Stromgarde replaces with one of its own.</summary>
  public static IReadOnlyDictionary<int, int> ResearchEquivalents => _researchEquivalents;

  /// <summary>The Stromgarde version of a Stormwind object, or the object itself if they share it.</summary>
  public static int GetStromgardeEquivalent(int objectId)
  {
    if (_stromgardeEquivalents.TryGetValue(objectId, out var equivalent))
    {
      return equivalent;
    }

    if (_researchEquivalents.TryGetValue(objectId, out var research))
    {
      return research;
    }

    return objectId;
  }

  /// <summary>The object <paramref name="faction"/> uses in place of a Stormwind one.</summary>
  public static int EquivalentFor(Faction? faction, int stormwindObjectId) =>
    faction is StromgardeFaction ? GetStromgardeEquivalent(stormwindObjectId) : stormwindObjectId;

  private static ObjectInfo ToStromgardeEquivalent(ObjectInfo objectInfo) =>
    new(GetStromgardeEquivalent(objectInfo.ObjectTypeId), objectInfo.Limit, objectInfo.Categories, objectInfo.LimitIncreaseHint);
}
