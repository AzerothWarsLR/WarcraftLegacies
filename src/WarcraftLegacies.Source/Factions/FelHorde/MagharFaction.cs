using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.FelHorde;

/// <summary>The orcs of Outland after they cast off the demons' blood and join the Horde.</summary>
public sealed class MagharFaction : Faction
{
  private static readonly Dictionary<int, int> _magharEquivalents = new()
  {
    { UNIT_NCPN_FEL_PEON_FEL_WORKER, UNIT_O200_PEON_MAGHAR_WORKER },
    { UNIT_NCHG_FEL_GRUNT_FEL, UNIT_O201_GRUNT_MAGHAR },
    { UNIT_NCHR_FEL_RAIDER_FEL, UNIT_O202_RAIDER_MAGHAR },
    { UNIT_NCHW_FEL_WARLOCK_FEL, UNIT_O203_SHAMAN_MAGHAR },
    { UNIT_U00V_NECROLYTE_FEL, UNIT_O204_SPIRITCALLER_MAGHAR },
    { UNIT_OWAR_BONEBREAKER_FEL, UNIT_O205_BONEBREAKER_MAGHAR },
    { UNIT_N058_FEL_CROSSBOWMAN_FEL, UNIT_O206_CROSSBOWMAN_MAGHAR },
    { UNIT_O01O_DEMOLISHER_FEL, UNIT_O207_DEMOLISHER_MAGHAR },
    { UNIT_U018_EYE_OF_GRILLOK_FEL, UNIT_O208_SPIRIT_WOLF_MAGHAR },
    { UNIT_NBDK_OBSIDIAN_DRAKE_FEL, UNIT_O209_RED_DRAKE_MAGHAR },
    { UNIT_O01L_EXECUTIONER_FEL_ELITE, UNIT_O20A_EXECUTIONER_MAGHAR_ELITE },
    { UNIT_N086_FEL_DEATH_KNIGHT_FEL_ELITE_TIER, UNIT_O20B_ELDER_SHAMAN_MAGHAR },
    { UNIT_O02Y_GREAT_HALL_FEL_T1, UNIT_O20D_GREAT_HALL_MAGHAR_T1 },
    { UNIT_O02Z_STRONGHOLD_FEL_T2, UNIT_O20E_STRONGHOLD_MAGHAR_T2 },
    { UNIT_O030_FORTRESS_FEL_T3, UNIT_O20F_FORTRESS_MAGHAR_T3 },
    { UNIT_O02V_ALTAR_OF_DOMINATION_FEL_ALTAR, UNIT_O20G_ALTAR_OF_STORMS_MAGHAR_ALTAR },
    { UNIT_O02W_BARRACKS_FEL_BARRACKS, UNIT_O20H_BARRACKS_MAGHAR_BARRACKS },
    { UNIT_O031_WAR_MILL_FEL_RESEARCH, UNIT_O20I_WAR_MILL_MAGHAR_RESEARCH },
    { UNIT_O033_DARK_ENCLAVE_FEL_MAGIC, UNIT_O20J_SPIRIT_LODGE_MAGHAR_MAGIC },
    { UNIT_O02X_BEASTIARY_FEL_SPECIALIST, UNIT_O20K_BEASTIARY_MAGHAR_SPECIALIST },
    { UNIT_OCBW_FEL_BURROW_FEL_FARM, UNIT_O20L_BURROW_MAGHAR_FARM },
    { UNIT_O034_WATCH_TOWER_FEL_TOWER, UNIT_O20M_WATCH_TOWER_MAGHAR_TOWER },
    { UNIT_O035_IMPROVED_WATCH_TOWER_FEL_TOWER_2, UNIT_O20N_IMPROVED_WATCH_TOWER_MAGHAR_TOWER_2 },
    { UNIT_U00Q_TREASURY_FEL_SHOP, UNIT_O20O_TREASURY_MAGHAR_SHOP },
    { UNIT_O032_SHIPYARD_FEL_SHIPYARD, UNIT_O20P_SHIPYARD_MAGHAR_SHIPYARD }
  };

  private static readonly Dictionary<int, int> _towerEquivalents = new()
  {
    { UNIT_N0AM_FLAME_PILLAR_FEL_TOWER, UNIT_O20M_WATCH_TOWER_MAGHAR_TOWER },
    { UNIT_N0AN_IMPROVED_FLAME_PILLAR_FEL_TOWER_2, UNIT_O20N_IMPROVED_WATCH_TOWER_MAGHAR_TOWER_2 }
  };

  private static readonly HashSet<int> _leftBehind = new()
  {
    UNIT_NMAG_LORD_OF_OUTLAND_FEL,
    UNIT_N03D_WARCHIEF_OF_THE_FEL_HORDE_FEL,
    UNIT_U02D_DEATH_KNIGHT_LORD_FEL_HORDE,
    UNIT_N05T_KAZZAK_THE_SUPREME_FEL_DEMI,
    UNIT_ODKT_EREDAR_OCCULTIST_FEL,
    UNIT_NINA_INFERNAL_JUGGERNAUT_FEL,
    UNIT_N0AM_FLAME_PILLAR_FEL_TOWER,
    UNIT_N0AN_IMPROVED_FLAME_PILLAR_FEL_TOWER_2
  };

  private static readonly Dictionary<int, int> _researchEquivalents = new()
  {
    { UPGRADE_R00M_FEL_WARLOCK_ADEPT_TRAINING_FEL_HORDE, UPGRADE_R11I_SHAMAN_ADEPT_TRAINING_MAGHAR },
    { UPGRADE_R024_NECROLYTE_ADEPT_TRAINING_FEL_HORDE, UPGRADE_R11G_SPIRITCALLER_ADEPT_TRAINING_MAGHAR },
    { UPGRADE_R09W_FELSTEEL_REFINING_FEL_HORDE, UPGRADE_R11F_BLACKROCK_FORGING_MAGHAR },
    { UPGRADE_R03I_EREDAR_OCCULTIST_ADEPT_TRAINING_FEL_HORDE, UPGRADE_R11H_ELDER_SHAMAN_ADEPT_TRAINING_MAGHAR },
    { UPGRADE_R036_INCINERATE_FEL_HORDE, UPGRADE_R11J_INCINERATE_MAGHAR },
    { UPGRADE_R034_ENHANCED_BREATH_FEL_HORDE_DRAKES, UPGRADE_R11K_ENHANCED_BREATH_MAGHAR }
  };

  private static readonly HashSet<int> _researchesLeftBehind = new()
  {
    UPGRADE_R03O_BLOOD_RUNES_FEL_HORDE,
    UPGRADE_ROBF_DEMONIC_FLUX_FEL_HORDE,
    UPGRADE_R098_FEL_INFUSED_SKELETON_FEL_HORDE,
    UPGRADE_R035_IMPROVED_FIREBOLT_FEL_HORDE
  };

  private static readonly HashSet<int> _demonGates = new()
  {
    UNIT_N081_UNFOCUSED_DEMON_GATE_FEL_T0_RED,
    UNIT_N000_FEL_HOUND_DEMON_GATE_FEL_T1_HOUNDS,
    UNIT_N05F_VOIDWALKER_DEMON_GATE_FEL_T1_VOIDWALKER,
    UNIT_N05I_FEL_HOUND_PACK_DEMON_GATE_FEL_T2_HOUNDS_PACK,
    UNIT_N05R_FELGUARD_DEMON_GATE_FEL_T2_BLOODFIEND,
    UNIT_N06H_PIT_FIEND_DEMON_GATE_FEL_T2_PITFIEND,
    UNIT_N06G_NETHER_DRAKE_DEMON_GATE_FEL_T2_NETHER_DRAKE,
    UNIT_N07M_VOIDLORD_DEMON_GATE_FEL_T2_VOIDLORD,
    UNIT_N07O_TERRORGUARD_DEMON_GATE_FEL_T2_TERROR_GUARD,
    UNIT_N0AP_FOCAL_DEMON_GATE_FEL_SIEGE
  };

  private static readonly Dictionary<int, int> _allEquivalents =
    _magharEquivalents.Concat(_towerEquivalents).ToDictionary(x => x.Key, x => x.Value);

  /// <summary>Creates the Mag'har with whatever <paramref name="felHorde"/> can currently build, train and research.</summary>
  public MagharFaction(Faction felHorde)
    : base("Mag'har", playercolor.Wheat, @"ReplaceableTextures\CommandButtons\BTNGarroshHellscream.blp")
  {
    TraditionalTeam = TeamSetup.Horde;
    ControlPointDefenderUnitTypeId = UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF;
    CinematicMusic = "SadMystery";
    FoodMaximum = felHorde.FoodMaximum;
    Nicknames = new List<string>
    {
      "mh",
      "maghar"
    };

    ProcessObjectInfo(FelHordeObjectInfo.GetAllObjectInfos()
      .Where(x => !_leftBehind.Contains(x.ObjectTypeId) && !_demonGates.Contains(x.ObjectTypeId) && !_researchesLeftBehind.Contains(x.ObjectTypeId))
      .Select(ToMagharEquivalent));
    foreach (var (objectId, limit) in felHorde.GetAllObjectLimits())
    {
      if (!_leftBehind.Contains(objectId) && !_demonGates.Contains(objectId) && !_researchesLeftBehind.Contains(objectId))
      {
        SetObjectLimit(GetMagharEquivalent(objectId), limit);
      }
    }

    SetObjectLimit(UNIT_O20Q_CHIEFTAIN_OF_THE_MAG_HAR_MAGHAR, 1);
    SetObjectLimit(UNIT_O20S_SON_OF_BLACKHAND_MAGHAR, 1);
    SetObjectLimit(UNIT_O209_RED_DRAKE_MAGHAR, 4);
  }

  /// <summary>Every Fel Horde unit and building the Mag'har replace with one of their own.</summary>
  public static IReadOnlyDictionary<int, int> UnitEquivalents => _allEquivalents;

  /// <summary>Whether the Mag'har leave this Fel Horde unit or building behind.</summary>
  public static bool IsLeftBehind(int unitTypeId) => _leftBehind.Contains(unitTypeId);

  /// <summary>Whether this is one of the Fel Horde's Demon Gates, which the Mag'har abandon to the demons.</summary>
  public static bool IsDemonGate(int unitTypeId) => _demonGates.Contains(unitTypeId);

  private static int GetMagharEquivalent(int objectId)
  {
    if (_magharEquivalents.TryGetValue(objectId, out var unitEquivalent))
    {
      return unitEquivalent;
    }

    return _researchEquivalents.TryGetValue(objectId, out var researchEquivalent) ? researchEquivalent : objectId;
  }

  private static ObjectInfo ToMagharEquivalent(ObjectInfo objectInfo) =>
    new(GetMagharEquivalent(objectInfo.ObjectTypeId), objectInfo.Limit, objectInfo.Categories, objectInfo.LimitIncreaseHint);
}
