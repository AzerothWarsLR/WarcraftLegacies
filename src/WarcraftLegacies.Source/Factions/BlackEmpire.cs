using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions
{
  public class BlackEmpire : Faction
  {
    /// <inheritdoc />
    public BlackEmpire() : base("BlackEmpire", PLAYER_COLOR_TURQUOISE, "|C0000FFFF",
      @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
    {
      ControlPointDefenderUnitTypeId = UNIT_N0DV_CONTROL_POINT_DEFENDER_BLACK_EMPIRE_TOWER;
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
      ModObjectLimit(UNIT_N0AX_PIT_OF_TORMENT_YOGG_SPECIALIST, UNLIMITED);
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

      ModObjectLimit(UNIT_O01G_FACELESS_MARAUDER_YOGG, UNLIMITED);
      ModObjectLimit(UNIT_O04V_SOUL_HUNTER_YOGG, UNLIMITED);
      ModObjectLimit(UNIT_U029_STYGIAN_HULK_YOGG, 12);

      ModObjectLimit(UNIT_N077_SORCERER_YOGG, UNLIMITED);
      ModObjectLimit(UNIT_O04Y_FATEWEAVER_YOGG, UNLIMITED);
      ModObjectLimit(UNIT_U02F_FORGOTTEN_ONE_YOGG, 2);
      ModObjectLimit(UNIT_O04Z_FLYING_HORROR_YOGG, 12);
      ModObjectLimit(UNIT_N0AH_DEFORMED_CHIMERA_YOGG, 4);
      ModObjectLimit(UNIT_H09F_GLADIATOR_YOGG, UNLIMITED  );

     // All Nzoth Ships

      ModObjectLimit(FourCC("ushp"), UNLIMITED); //Undead Shipyard
      ModObjectLimit(FourCC("ubot"), UNLIMITED); //Undead Transport Ship
      ModObjectLimit(FourCC("h0AT"), UNLIMITED); //Scout
      ModObjectLimit(FourCC("h0AW"), UNLIMITED); //Frigate
      ModObjectLimit(FourCC("h0AM"), UNLIMITED); //Fireship
      ModObjectLimit(FourCC("h0AZ"), UNLIMITED); //Galley
      ModObjectLimit(FourCC("h0AQ"), UNLIMITED); //Boarding
      ModObjectLimit(FourCC("h0BB"), UNLIMITED); //Juggernaut
      ModObjectLimit(FourCC("h0B9"), 6); //Bombard
      
      // All Nzoth Heroes listed below - with total limits

      ModObjectLimit(UNIT_U00P_LIEUTENANT_OF_N_ZOTH, 1);
      ModObjectLimit(UNIT_U02B_N_RAQI_ABERRATION, 1);
      ModObjectLimit(UNIT_E01D_MOUTH_OF_N_ZOTH_YOGG, 1);

    }
  }
}