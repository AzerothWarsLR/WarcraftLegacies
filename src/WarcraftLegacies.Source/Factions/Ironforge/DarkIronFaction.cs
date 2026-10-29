using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>The Dark Iron dwarves under Dagran Thaurissan, risen from the ashes of Ironforge.</summary>
public sealed class DarkIronFaction : Faction
{
  private static readonly Dictionary<int, int> _darkIronEquivalents = new()
  {
    { UNIT_H019_MASON_IRONFORGE_WORKER, UNIT_H0CT_DARK_IRON_MASON_DARKIRON_WORKER },
    { UNIT_H037_ENGINEER_IRONFORGE_ELITE, UNIT_H0EB_DARK_IRON_THANE_DARKIRON_ELITE },
    { UNIT_N00C_RUNE_PRIEST_IRONFORGE, UNIT_H0AB_SHADOWCASTER_DARKIRON },
    { UNIT_H01P_STEAM_TANK_IRONFORGE, UNIT_H0AA_MAGMA_TANK_DARKIRON },
    { UNIT_HGRY_GRYPHON_RIDER_IRONFORGE, UNIT_H0E6_FIRE_WYRM_DARKIRON },
    { UNIT_H018_WARRIOR_IRONFORGE, UNIT_H0E8_WARRIOR_DARKIRON },
    { UNIT_HRIF_RIFLEMAN_IRONFORGE, UNIT_H0E9_RIFLEMAN_DARKIRON },
    { UNIT_HMTM_MORTAR_TEAM_IRONFORGE, UNIT_H0EA_MORTAR_TEAM_DARKIRON },
    { UNIT_TP01_FLAME_TANK_IRONFORGE, UNIT_H0EC_FLAME_TANK_DARKIRON },
    { UNIT_TP02_ARTILLERY_TANK_IRONFORGE, UNIT_H0ED_WAR_TANK_DARKIRON },
    { UNIT_N02D_WAR_GOLEM_IRONFORGE, UNIT_H0EE_WAR_GOLEM_DARKIRON },
    { UNIT_N0CZ_DREADNAUGHT_IRONFORGE, UNIT_H0EF_EARTHBORER_DARKIRON },
    { UNIT_TP05_RUNE_SMITH_IRONFORGE, UNIT_H0EG_RUNE_SMITH_DARKIRON },
    { UNIT_H07E_MINING_COLONY_IRONFORGE_T1, UNIT_H0DR_DARK_IRON_HALL_DARKIRON_T1 },
    { UNIT_H07F_DWARF_HOLD_IRONFORGE_T2, UNIT_H0DS_DARK_IRON_KEEP_DARKIRON_T2 },
    { UNIT_H07G_GREAT_HOLD_IRONFORGE_T3, UNIT_H0DT_DARK_IRON_CASTLE_DARKIRON_T3 },
    { UNIT_H01S_TAVERN_IRONFORGE_FARM, UNIT_H0DU_DARK_IRON_TAVERN_DARKIRON_FARM },
    { UNIT_H07B_ALTAR_OF_FORTITUDE_IRONFORGE_ALTAR, UNIT_H0DV_ALTAR_OF_FLAME_DARKIRON_ALTAR },
    { UNIT_H07C_MUSTERING_HALL_IRONFORGE_BARRACKS, UNIT_H0DW_DARK_IRON_BARRACKS_DARKIRON_BARRACKS },
    { UNIT_H048_FORGEWORKS_IRONFORGE_RESEARCH, UNIT_H0DX_DARK_IRON_FORGE_DARKIRON_RESEARCH },
    { UNIT_H042_PINNACLE_IRONFORGE_MAGIC, UNIT_H0DY_SHADOWFORGE_SANCTUM_DARKIRON_MAGIC },
    { UNIT_HARM_WORKSHOP_IRONFORGE_SPECIALIST, UNIT_H0DZ_DARK_IRON_WORKSHOP_DARKIRON_SPECIALIST },
    { UNIT_HGRA_GRYPHON_AVIARY_IRONFORGE_AIR, UNIT_H0E0_MOLTEN_LAIR_DARKIRON_AIR },
    { UNIT_H07H_SCOUT_TOWER_IRONFORGE_TOWER, UNIT_H0E1_DARK_IRON_BUNKER_DARKIRON_TOWER },
    { UNIT_H07I_GUARD_TOWER_IRONFORGE_TOWER, UNIT_H0E2_GUARD_BUNKER_DARKIRON_TOWER },
    { UNIT_H07L_IMPROVED_GUARD_TOWER_IRONFORGE_TOWER, UNIT_H0E3_GUN_BUNKER_DARKIRON_TOWER },
    { UNIT_H07J_CANNON_TOWER_IRONFORGE_TOWER, UNIT_H0E4_CANNON_BUNKER_DARKIRON_TOWER },
    { UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, UNIT_H0E5_INFERNO_BUNKER_DARKIRON_TOWER }
  };

  private static readonly Dictionary<int, int> _researchEquivalents = new()
  {
    { UPGRADE_TP28_FLAMETHROWER_IRONFORGE, UPGRADE_R10K_FLAMETHROWER_DARKIRON },
    { UPGRADE_TP29_ARTILLERY_IRONFORGE, UPGRADE_R10L_ARTILLERY_DARKIRON },
    { UPGRADE_TP38_IMPROVED_CHASSIS_IRONFORGE, UPGRADE_R10P_SEISMIC_DRILLS_DARKIRON },
    { UPGRADE_R00V_RUNE_PRIEST_ADEPT_TRAINING_IRONFORGE, UPGRADE_R10Q_SHADOWCASTER_ADEPT_TRAINING_DARKIRON },
    { UPGRADE_R00F_MITHRIL_PLATED_ARMOR_IRONFORGE, UPGRADE_R10R_MITHRIL_PLATED_ARMOR_DARKIRON },
    { UPGRADE_R00T_OVERCLOCK_IRONFORGE_STEAM_TANK, UPGRADE_R10S_OVERCLOCK_DARKIRON },
    { UPGRADE_R00Z_ARMOR_PENETRATION_ROUNDS_IRONFORGE, UPGRADE_R10T_ARMOR_PENETRATION_ROUNDS_DARKIRON },
    { UPGRADE_R010_IMPROVED_SPELL_RESISTANCE_IRONFORGE, UPGRADE_R10U_IMPROVED_SPELL_RESISTANCE_DARKIRON },
    { UPGRADE_RHFL_FLARE_IRONFORGE, UPGRADE_R10V_FLARE_DARKIRON },
    { UPGRADE_RHFS_FRAGMENTATION_SHARDS_YELLOW_RESEARCH, UPGRADE_R10W_FRAGMENTATION_SHARDS_DARKIRON },
    { UPGRADE_RHRI_LONG_RIFLES_IRONFORGE, UPGRADE_R10X_LONG_RIFLES_DARKIRON },
    { UPGRADE_TP41_POTENT_STORMBREW_IRONFORGE, UPGRADE_R10Y_POTENT_STORMBREW_DARKIRON },
    { UPGRADE_TP42_RUNE_SMITH_ADEPT_TRAINING_IRONFORGE, UPGRADE_R10Z_RUNE_SMITH_ADEPT_TRAINING_DARKIRON }
  };

  private const int FireWyrmLimit = 2;

  private static readonly HashSet<int> _leftBehind = new()
  {
    UNIT_H00S_KING_OF_KHAZ_MODAN_IRONFORGE,
    UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_IRONFORGE,
    UNIT_H028_THANE_OF_AERIE_PEAK_IRONFORGE,
    UNIT_H01L_THANE_IRONFORGE,
    UPGRADE_R02K_GRYPHON_SUPERIOR_BREED_KHAZ_MODAN,
    UPGRADE_RHHB_STORM_HAMMERS_KHAZ_MODAN
  };

  /// <summary>Creates the Dark Iron with whatever <paramref name="ironforge"/> can currently build, train and research.</summary>
  public DarkIronFaction(Faction ironforge)
    : base("Dark Iron", playercolor.Peanut, @"ReplaceableTextures\CommandButtons\BTNRPGDarkIron.blp")
  {
    TraditionalTeam = TeamSetup.Legion;
    ControlPointDefenderUnitTypeId = UNIT_H0E7_CONTROL_POINT_DEFENDER_DARKIRON;
    CinematicMusic = "DarkAgents";
    FoodMaximum = ironforge.FoodMaximum;
    IntroText = () => Loc.Format(
      "You are now playing as the {faction}.\n\nMoira Thaurissan, Magni's own daughter, sits on the throne of Ironforge with Dagran at her side. The Bronzebeards who would not kneel have been driven from the halls.\n\nAll of Khaz Modan now answers to the Dark Iron. Hold it against those who call you usurpers.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Dark Iron")}|r"));
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
    SetObjectLimit(UNIT_H0E6_FIRE_WYRM_DARKIRON, FireWyrmLimit);
    SetObjectLimit(UPGRADE_RELD_MAGMA_FIRE_DARKIRON, 1);
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    AddQuest(new QuestThaurissansVengeance(AllLegends.Stormwind.StormwindKeep));
    AddQuest(new QuestDrownedFleet(AllLegends.Kultiras.LegendBoralus));
    AddQuest(new QuestWarOfTheThreeHammers(AllPreplacedWidgets.Units.Get(UNIT_H01U_AERIE_PEAK_IRONFORGE)));
    AddQuest(new QuestShatterTheVioletCitadel(AllLegends.Dalaran.Dalaran));
    var blackAnvil = AddQuest(new QuestBlackAnvil(AllLegends.Ironforge.Dagran));
    AddQuest(new QuestFirelordUnbound(AllLegends.Ironforge.Dagran, AllLegends.Ironforge.Ragnaros, blackAnvil));
  }

  /// <summary>The Dark Iron version of an Ironforge unit, or the unit itself if they share it.</summary>
  public static int GetDarkIronEquivalent(int objectId) =>
    _researchEquivalents.GetValueOrDefault(objectId, _darkIronEquivalents.GetValueOrDefault(objectId, objectId));

  /// <summary>Every Ironforge unit and building the Dark Iron replace with one of their own.</summary>
  public static IReadOnlyDictionary<int, int> UnitEquivalents => _darkIronEquivalents;

  /// <summary>Every Ironforge research the Dark Iron replace with one of their own.</summary>
  public static IReadOnlyDictionary<int, int> ResearchEquivalents => _researchEquivalents;

  private static ObjectInfo ToDarkIronEquivalent(ObjectInfo objectInfo)
  {
    var objectTypeId = GetDarkIronEquivalent(objectInfo.ObjectTypeId);
    var limit = objectTypeId == UNIT_H0E6_FIRE_WYRM_DARKIRON ? FireWyrmLimit : objectInfo.Limit;
    return new ObjectInfo(objectTypeId, limit, objectInfo.Categories, objectInfo.LimitIncreaseHint);
  }
}
