using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions
{
  public class BlackEmpire : Faction
  {
    /// <inheritdoc />
    public BlackEmpire() : base("BlackEmpire", PLAYER_COLOR_MAROON, "|C0000FFFF",
      @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
    {
      ControlPointDefenderUnitTypeId = UNIT_N0DV_CONTROL_POINT_DEFENDER_BLACK_EMPIRE_TOWER;
      TraditionalTeam = TeamSetup.OldGods;
    }
    
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      SharedFactionConfigSetup.AddSharedFactionConfig(this);
    }

    private void RegisterObjectLimits()
    {
      ModObjectLimit(UNIT_N0AR_TWISTING_HALLS_YOGG_T1, UNLIMITED);
      ModObjectLimit(UNIT_N0AS_WHISPERING_LABYRINTH_YOGG_T2, UNLIMITED);
      ModObjectLimit(UNIT_N0AT_CATHEDRAL_OF_MADNESS_YOGG_T3, UNLIMITED);
      ModObjectLimit(UNIT_N0AU_PULSATING_PORTAL_YOGG_FARM, UNLIMITED);
      ModObjectLimit(UNIT_H06U_SIPHONING_CRYSTAL_YOGG_RESEARCH, UNLIMITED);
      ModObjectLimit(UNIT_N0AW_INCUBATION_POOL_YOGG_BARRACKS, UNLIMITED);
      ModObjectLimit(UNIT_N0B3_SHADOW_LAIR_YOGG_MAGIC, UNLIMITED);
      ModObjectLimit(UNIT_N0AX_MUTATION_CIRCLE_YOGG_SPECIALIST, UNLIMITED);
      ModObjectLimit(UNIT_LS08_PIT_OF_TORMENT_NIGHTMARE_SPECIALIST, UNLIMITED);
      ModObjectLimit(UNIT_N0B2_OMINOUS_VAULT_YOGG_SHOP, UNLIMITED);
      ModObjectLimit(UNIT_N0AV_ALTAR_OF_MADNESS_YOGG_ALTAR, UNLIMITED);
      ModObjectLimit(UNIT_H09E_MADNESS_POOL_YOGG_TOWER, UNLIMITED);
      ModObjectLimit(UNIT_N0AY_ACID_SPITTER_YOGG_TOWER, UNLIMITED);
      ModObjectLimit(UNIT_N0B0_IMPROVED_ACID_SPITTER_YOGG_TOWER, UNLIMITED);
      ModObjectLimit(UNIT_N0AZ_SLEEPLESS_WATCHER_YOGG_TOWER, UNLIMITED);
      ModObjectLimit(UNIT_N0B1_IMPROVED_SLEEPLESS_WATCHER_YOGG_TOWER, UNLIMITED);

      // All Nzoth Units listed below - with total limits 

      ModObjectLimit(UNIT_N0B5_SCAVENGER_YOGG_WORKER, UNLIMITED);
      ModObjectLimit(UNIT_N0B4_REAPER_YOGG, 6);

      ModObjectLimit(UNIT_O01G_BRUTE_YOGG, UNLIMITED);
      ModObjectLimit(UNIT_O04V_LURKER_YOGG, UNLIMITED);
      ModObjectLimit(UNIT_H09F_DEEP_FIEND_YOGG, 12);

      ModObjectLimit(UNIT_N077_MINDLASHER_YOGG, UNLIMITED);
      ModObjectLimit(UNIT_O04Y_FATEWEAVER_YOGG, UNLIMITED);
      ModObjectLimit(UNIT_BHN1_HERALD_YOGG, 6);

      ModObjectLimit(UNIT_U02F_FORGOTTEN_ONE_YOGG, 2);
      ModObjectLimit(UNIT_SHZ5_AQIR_BLACK_EMPIRE, 6);

      ModObjectLimit(UNIT_O04Z_FLYING_HORROR_YOGG, 12);
      ModObjectLimit(UNIT_N0AH_DEFORMED_CHIMERA_YOGG, 4);
      ModObjectLimit(UNIT_U029_STYGIAN_HULK_YOGG, 12);


      // All Nzoth Ships

      ModObjectLimit(UNIT_USHP_HAUNTED_HARBOR_SCOURGE_SHIPYARD, UNLIMITED);
      ModObjectLimit(UNIT_H0AT_SCOUT_SHIP_UNDEAD, UNLIMITED);
      ModObjectLimit(UNIT_H0AW_FRIGATE_UNDEAD, UNLIMITED);
      ModObjectLimit(UNIT_UBOT_HAUNTED_TRANSPORT_SHIP_SCOURGE_LEGION, UNLIMITED);
      ModObjectLimit(UNIT_H0AM_FIRESHIP_UNDEAD, UNLIMITED);
      ModObjectLimit(UNIT_H0AZ_GALLEY_UNDEAD, UNLIMITED);
      ModObjectLimit(UNIT_H0AQ_BOARDING_VESSEL_UNDEAD, UNLIMITED);
      ModObjectLimit(UNIT_H0BB_JUGGERNAUT_UNDEAD, UNLIMITED);
      ModObjectLimit(UNIT_H0B9_BOMBARD_UNDEAD, 6);
      
      // All Nzoth Heroes listed below - with total limits

      ModObjectLimit(UNIT_U00P_LIEUTENANT_OF_N_ZOTH, 1);
      ModObjectLimit(UNIT_U02B_N_RAQI_ABERRATION, 1);
      ModObjectLimit(UNIT_E01D_MOUTH_OF_N_ZOTH_YOGG, 1);


      //Upgrades

      ModObjectLimit(UPGRADE_RBEF_FATEWEAVER_MASTER_TRAINING_BLACKEMPIRE, UNLIMITED);
      ModObjectLimit(UPGRADE_RBEM_MINDLASHER_MASTER_TRAINING_BLACKEMPIRE, UNLIMITED);
      ModObjectLimit(UPGRADE_RBEH_HERALD_MASTER_TRAINING_BLACKEMPIRE, UNLIMITED);

    }
  }
}