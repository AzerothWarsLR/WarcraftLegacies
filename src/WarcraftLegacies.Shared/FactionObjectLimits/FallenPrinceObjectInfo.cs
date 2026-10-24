using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

/// <summary>The Fallen Prince's roster: the Scourge's buildings, raised from Lordaeron's own dead.</summary>
public static class FallenPrinceObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_UNPL_NECROPOLIS_SCOURGE_T1, Unlimited, TownHall);
    yield return new(UNIT_UNP1_HALLS_OF_THE_DEAD_SCOURGE_T2, Unlimited, Keep);
    yield return new(UNIT_UNP2_BLACK_CITADEL_SCOURGE_T3, Unlimited, Castle);
    yield return new(UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, Unlimited, Farm);
    yield return new(UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });
    yield return new(UNIT_UZG2_NERUBIAN_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });
    yield return new(UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, Unlimited, Altar);
    yield return new(UNIT_USEP_CRYPT_SCOURGE_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, Unlimited, Research);
    yield return new(UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, Unlimited, SiegeWorkshop);
    yield return new(UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, Unlimited, Magic);
    yield return new(UNIT_UTOM_TOMB_OF_RELICS_SCOURGE_SHOP, Unlimited, Shop);
    yield return new(UNIT_USHP_HAUNTED_HARBOR_SCOURGE_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_UBON_BONEYARD_SCOURGE_SIEGE, Unlimited, FlyingBuilding);
    yield return new(UNIT_U002_IMPROVED_SPIRIT_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });
    yield return new(UNIT_U003_IMPROVED_NERUBIAN_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });

    yield return new(UNIT_UACO_ACOLYTE_SCOURGE_WORKER, Unlimited, Builder);
    yield return new(UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, Unlimited, Tank);
    yield return new(UNIT_U103_RISEN_ARCHER_FALLENPRINCE, Unlimited, Marksman);
    yield return new(UNIT_N009_REVENANT_SCOURGE, Unlimited, Tank);
    yield return new(UNIT_UMTW_MEAT_WAGON_SCOURGE, 6, Siege);
    yield return new(UNIT_UGAR_GARGOYLE_SCOURGE, 10, new List<UnitCategory> { Flyer, AntiAir });
    yield return new(UNIT_UNEC_NECROMANCER_SCOURGE, Unlimited, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_U107_FALLEN_PRIEST_FALLENPRINCE, Unlimited, Support);
    yield return new(UNIT_UOBS_OBSIDIAN_STATUE_SCOURGE, 2, Support);
    yield return new(UNIT_H00H_DEATH_KNIGHT_SCOURGE_ELITE, 4, new List<UnitCategory> { Elite, Tank, Summoner });
    yield return new(UNIT_UBSP_OBSIDIAN_DESTROYER_SCOURGE, 4, new List<UnitCategory> { Flyer, Destroyer, AntiMage });

    yield return new(UNIT_UBOT_HAUNTED_TRANSPORT_SHIP_SCOURGE_LEGION, Unlimited);
    yield return new(UNIT_H0AT_SCOUT_SHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AW_FRIGATE_EVIL, Unlimited);
    yield return new(UNIT_H0AM_FIRESHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AZ_GALLEY_EVIL, Unlimited);
    yield return new(UNIT_H0AQ_BOARDING_VESSEL_EVIL, Unlimited);
    yield return new(UNIT_H0BB_JUGGERNAUT_EVIL, Unlimited);
    yield return new(UNIT_H0B9_BOMBARD_EVIL, 6);

    yield return new(UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE, 1, new List<UnitCategory> { Fighter, Support });
    yield return new(UNIT_U03A_DEATHBRINGER_FALLENPRINCE, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_U020_DEATHGUARD_SCOURGE, 1, new List<UnitCategory> { Fighter, Support });

    yield return new(UPGRADE_RUEX_EXHUME_CORPSES_SCOURGE, Unlimited);
    yield return new(UPGRADE_RUNE_NECROMANCER_ADEPT_TRAINING_SCOURGE, Unlimited);
    yield return new(UPGRADE_R01D_HOWL_OF_TERROR_SCOURGE, Unlimited);
    yield return new(UPGRADE_RUSL_SKELETAL_LONGEVITY, Unlimited);
    yield return new(UPGRADE_RUSM_SKELETAL_MASTERY, Unlimited);
    yield return new(UPGRADE_R102_RISEN_VETERANS_FALLENPRINCE, Unlimited);
    yield return new(UPGRADE_R103_BONE_SNARES_FALLENPRINCE, Unlimited);
    yield return new(UPGRADE_R106_FALLEN_PRIEST_ADEPT_TRAINING_FALLENPRINCE, Unlimited);
    yield return new(UPGRADE_ZB24_DEATH_KNIGHTS_SCOURGE, 1);
  }
}
