using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions
{
  public class Ahnqiraj : Faction
  {
    /// <inheritdoc />
    public Ahnqiraj() : base("Ahn'qiraj", PLAYER_COLOR_WHEAT, "|cffaaa050", @"ReplaceableTextures\CommandButtons\BTNCthunIcon.blp")
    {
      ControlPointDefenderUnitTypeId = Constants.UNIT_N0DW_CONTROL_POINT_DEFENDER_CTHUN_TOWER;
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
      ModObjectLimit(UNIT_U020_MONUMENT_C_THUN_T1, UNLIMITED);
      ModObjectLimit(UNIT_U021_RUINED_TEMPLE_C_THUN_T2, UNLIMITED);
      ModObjectLimit(UNIT_U022_NEXUS_C_THUN_T3, UNLIMITED);
      ModObjectLimit(UNIT_N071_PILLAR_OF_C_THUN_C_THUN_PILLARS, UNLIMITED);
      ModObjectLimit(UNIT_U01G_SPIRIT_HALL_C_THUN_RESEARCH, UNLIMITED);
      ModObjectLimit(UNIT_O00R_HATCHERY_C_THUN_BARRACK, UNLIMITED);
      ModObjectLimit(UNIT_O00D_PYRAMID_C_THUN_MAGIC, UNLIMITED);
      ModObjectLimit(UNIT_U01H_ANCIENT_CATACOMBS_C_THUN_SPECIALIST, UNLIMITED);
      ModObjectLimit(UNIT_U01I_CHAMBER_OF_WONDERS_C_THUN_SHOP, UNLIMITED);
      ModObjectLimit(UNIT_U01F_ALTAR_OF_THE_OLD_ONES_C_THUN_ALTAR, UNLIMITED);
      ModObjectLimit(UNIT_STZ5_LIGHTHOUSE_C_THUN_EMPTY, UNLIMITED);


      ModObjectLimit(UNIT_U019_DRONE_C_THUN_WORKER, UNLIMITED);
      ModObjectLimit(UNIT_O000_SILITHID_ROYALTY_C_THUN_ELITES, 6);

      ModObjectLimit(UNIT_N06I_SILITHID_WARRIOR_C_THUN_SILITHID_WARRIOR, UNLIMITED);
      ModObjectLimit(UNIT_O00L_SILITHID_REAVER_C_THUN_SILITHID_REAVER, UNLIMITED);
      ModObjectLimit(UNIT_U013_SILITHID_COLOSSUS_C_THUN_GIANT_SCARAB, UNLIMITED);

      ModObjectLimit(UNIT_N060_SILITHID_TUNNELER_C_THUN_SILITHID_TUNNELER, UNLIMITED);
      ModObjectLimit(UNIT_N05V_SHADOW_WEAVER_C_THUN_FACELESS_SHADOW_WEAVER, UNLIMITED);
      ModObjectLimit(UNIT_O001_TOL_VIR_STATUE_C_THUN_TOL_VIR_STATUE, 6);

      ModObjectLimit(UNIT_O02N_SILITHID_WASP_CTHUN, 24);
      ModObjectLimit(UNIT_H01N_VILE_CORRUPTER_C_THUN, 4);
      ModObjectLimit(UNIT_SL2O_OBSIDIAN_ERADICATOR_CTHUN, 12);

      ModObjectLimit(FourCC("ushp"), UNLIMITED); //Undead Shipyard
      ModObjectLimit(FourCC("ubot"), UNLIMITED); //Undead Transport Ship
      ModObjectLimit(FourCC("h0AT"), UNLIMITED); //Scout
      ModObjectLimit(FourCC("h0AW"), UNLIMITED); //Frigate
      ModObjectLimit(FourCC("h0AM"), UNLIMITED); //Fireship
      ModObjectLimit(FourCC("h0AZ"), UNLIMITED); //Galley
      ModObjectLimit(FourCC("h0AQ"), UNLIMITED); //Boarding
      ModObjectLimit(FourCC("h0BB"), UNLIMITED); //Juggernaut
      ModObjectLimit(FourCC("h0B9"), 6); //Bombard

      ModObjectLimit(UNIT_U02S_ANCIENT_SAND_WORM, 1);
      ModObjectLimit(UNIT_E005_THE_PROPHET, 1);
      ModObjectLimit(UNIT_U00Z_OBSIDIAN_DESTROYER, 1);

      ModObjectLimit(UPGRADE_RS01_TUNNELER_MASTER_TRAINING_CTHUN, UNLIMITED);
      ModObjectLimit(UPGRADE_RZ02_SHADOW_WEAVER_MASTER_TRAINING_CTHUN, UNLIMITED);
      ModObjectLimit(UPGRADE_RL11_TOL_VIR_STATUE_MASTER_TRAINING_CTHUN, UNLIMITED);
      ModObjectLimit(UPGRADE_RYW5_IMPROVED_SWARM_BEETLE_CTHUN_WARRIOR, UNLIMITED);
      ModObjectLimit(UPGRADE_RTL3_IMPROVED_SEED_OF_MADNESS_CTHUN_WARRIOR, UNLIMITED);

    }
  }
}