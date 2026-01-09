using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class ScourgeObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_UNPL_NECROPOLIS_SCOURGE_T1, Unlimited, TownHall);
    yield return new(UNIT_UNP1_HALLS_OF_THE_DEAD_SCOURGE_T2, Unlimited, TownHall);
    yield return new(UNIT_UNP2_BLACK_CITADEL_SCOURGE_T3, Unlimited, TownHall);
    yield return new(UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, Unlimited, Farm);
    yield return new(UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });
    yield return new(UNIT_UZG2_NERUBIAN_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });
    yield return new(UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, Unlimited, Altar);
    yield return new(UNIT_USEP_CRYPT_SCOURGE_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, Unlimited, Research);
    yield return new(UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, Unlimited, Magic);
    yield return new(UNIT_UBON_BONEYARD_SCOURGE_SIEGE, Unlimited, SiegeWorkshop);
    yield return new(UNIT_UTOM_TOMB_OF_RELICS_SCOURGE_SHOP, Unlimited, Shop);
    yield return new(UNIT_USHP_HAUNTED_HARBOR_SCOURGE_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_U002_IMPROVED_SPIRIT_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });
    yield return new(UNIT_U003_IMPROVED_NERUBIAN_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });

    //Units
    yield return new(UNIT_UACO_ACOLYTE_SCOURGE_WORKER, Unlimited, Worker);
    yield return new(UNIT_UGHO_GHOUL_SCOURGE, Unlimited, new List<UnitCategory> { Fighter, Worker });
    yield return new(UNIT_UABO_ABOMINATION_SCOURGE, Unlimited, Tank);
    yield return new(UNIT_UMTW_MEAT_WAGON_SCOURGE, 8, Siege);
    yield return new(UNIT_UCRY_CRYPT_FIEND_SCOURGE, Unlimited, Marksman);
    yield return new(UNIT_UGAR_GARGOYLE_SCOURGE, 12, new List<UnitCategory> { Flyer, AntiAir });
    yield return new(UNIT_H02G_VRYKUL_WARRIOR_SCOURGE, Unlimited, Fighter);
    yield return new(UNIT_H061_VRYKUL_BERSERK_SCOURGE, 12, Fighter);
    yield return new(UNIT_H00P_MAMMOTH_RIDER_SCOURGE, 4, Fighter);
    yield return new(UNIT_UBAN_BANSHEE_SCOURGE, Unlimited, Support);
    yield return new(UNIT_UNEC_NECROMANCER_SCOURGE, Unlimited, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_UOBS_OBSIDIAN_STATUE_SCOURGE, 4, Support);
    yield return new(UNIT_UFRO_FROST_WYRM_SCOURGE, 4, new List<UnitCategory> { Flyer, Destroyer });
    yield return new(UNIT_H00H_DEATH_KNIGHT_SCOURGE_ELITE, 0, new List<UnitCategory> { Elite, Tank, Summoner })
    {
      LimitTooltipOverride = 6
    };
    yield return new(UNIT_ZBLI_LICH_SCOURGE_ELITE, 0, new List<UnitCategory> { Elite, Destroyer, Support, Summoner })
    {
      LimitTooltipOverride = 6
    };
    yield return new(UNIT_UBSP_OBSIDIAN_DESTROYER_SCOURGE, 6, new List<UnitCategory> { Flyer, Destroyer, AntiMage });
    yield return new(UNIT_NFGL_PLAGUE_TITAN_SCOURGE, 2, new List<UnitCategory> { Tank, Summoner });

    //Ship
    yield return new(UNIT_UBOT_HAUNTED_TRANSPORT_SHIP_SCOURGE_LEGION, Unlimited);
    yield return new(UNIT_H0AT_SCOUT_SHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AW_FRIGATE_EVIL, Unlimited);
    yield return new(UNIT_H0AM_FIRESHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AZ_GALLEY_EVIL, Unlimited);
    yield return new(UNIT_H0AQ_BOARDING_VESSEL_EVIL, Unlimited);
    yield return new(UNIT_H0BB_JUGGERNAUT_EVIL, Unlimited);
    yield return new(UNIT_H0B9_BOMBARD_EVIL, 6);

    //Demi-Heroes
    yield return new(UNIT_UBDD_SAPPHIRON_SCOURGE_DEMI, 1, new List<UnitCategory> { Flyer, Destroyer });
    yield return new(UNIT_UANB_KING_OF_AZJOL_NERUB_SCOURGE, 1, new List<UnitCategory> { Tank, Summoner });
    yield return new(UNIT_U001_MASTER_OF_THE_CULT_OF_THE_DAMNED_SCOURGE_NECROMANCER, 1, new List<UnitCategory> { Destroyer, Support, Summoner });
    yield return new(UNIT_U00M_MASTER_OF_THE_CULT_OF_THE_DAMNED_SCOURGE_GHOST, 1, new List<UnitCategory> { Destroyer, Support, Summoner });
    yield return new(UNIT_U00A_SCOURGE_COMMANDER_SCOURGE, 1, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_UKTL_ARCHLICH_OF_THE_SCOURGE_SCOURGE_LICH, 1, new List<UnitCategory> { Destroyer, Support, Summoner });
    yield return new(UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE, 1, new List<UnitCategory> { Fighter, Support });

    //Upgrades
    yield return new(UPGRADE_RUBA_BANSHEE_ADEPT_TRAINING_SCOURGE_RESEARCH, Unlimited);
    yield return new(UPGRADE_RUEX_EXHUME_CORPSES_SCOURGE, Unlimited);
    yield return new(UPGRADE_RUFB_FREEZING_BREATH_SCOURGE, Unlimited);
    yield return new(UPGRADE_RUGF_GHOUL_FRENZY_SCOURGE, Unlimited);
    yield return new(UPGRADE_RUNE_NECROMANCER_ADEPT_TRAINING_SCOURGE, Unlimited);
    yield return new(UPGRADE_RUWB_WEB_RED_RESEARCH, Unlimited);
    yield return new(UPGRADE_R00Q_CHILLING_AURA_SCOURGE, 0);
    yield return new(UPGRADE_R01X_EPIDEMIC_SCOURGE, Unlimited);
    yield return new(UPGRADE_R01D_HOWL_OF_TERROR_SCOURGE, Unlimited);
    yield return new(UPGRADE_R06N_IMPROVED_ORB_OF_ANNIHILATION_SCOURGE, Unlimited);
    yield return new(UPGRADE_RUSL_SKELETAL_LONGEVITY, Unlimited);
    yield return new(UPGRADE_RUSM_SKELETAL_MASTERY, Unlimited);
    yield return new(UPGRADE_ZB74_LICHES_SCOURGE, Unlimited);
    yield return new(UPGRADE_ZB24_DEATH_KNIGHTS_SCOURGE, Unlimited);
  }
}
