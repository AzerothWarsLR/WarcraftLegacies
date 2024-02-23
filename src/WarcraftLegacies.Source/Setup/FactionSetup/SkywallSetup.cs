using MacroTools;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class SkywallSetup
  {
    public static Faction? Skywall { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Skywall = new Faction("Elemental Lords", PLAYER_COLOR_PEACH, "|c00540081",
        @"ReplaceableTextures\CommandButtons\BTNFrostRevenant2.blp")
      {
        ControlPointDefenderUnitTypeId = Constants.UNIT_U02T_CONTROL_POINT_DEFENDER_NAZJATAR,
      };

      Skywall.ModObjectLimit(Constants.UNIT_N05Q_PILLAR_OF_WAVES_TOLVIR_T1, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N05W_MONUMENT_OF_THE_DEEP_TOLVIR_T2, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N06R_TEMPLE_OF_TIDES_TOLVIR_T3, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_H03I_CORAL_FORGE_TOLVIR_RESEARCH, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N08A_SPAWNING_GROUNDS_TOLVIR_BARRACKS, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N07N_ROYAL_TEMPLE_TOLVIR_MAGIC, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N08B_SHRINE_OF_AZSHARA_TOLVIR_SPECIALIST, Faction.UNLIMITED);
      //Skywall.ModObjectLimit(Constants.UNIT_N08V_PORTAL_OF_THE_DEEP_NZOTH_SIEGE, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N07J_DEEP_VAULT_TOLVIR_SHOP, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N078_ALTAR_OF_THE_QUEEN_TOLVIR_ALTAR, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N08L_TEMPLE_PROTECTOR_TOLVIR_TOWER, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N08N_IMPROVED_TEMPLE_PROTECTOR_TOLVIR_TOWER, Faction.UNLIMITED);

      // All Nzoth Units listed below - with total limits 

      Skywall.ModObjectLimit(Constants.UNIT_N0D7_DEEP_FORAGER_N_ZOTH_WORKER, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N0DT_TIDEMISTRESS_NZOTH, 6);

      Skywall.ModObjectLimit(Constants.UNIT_N0CA_NAGA_INCURSOR_NZOTH, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N0CE_HATCHLING_NZOTH, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N0CL_GARGANTUAN_SEA_TURTLE_NZOTH, 8);

      Skywall.ModObjectLimit(Constants.UNIT_N0CB_DEEPSEER_NZOTH, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_N0CD_BLOODKIN_NZOTH, Faction.UNLIMITED);
      Skywall.ModObjectLimit(Constants.UNIT_O060_RIPTIDE_DRAKE_NZOTH, 6);
      Skywall.ModObjectLimit(Constants.UNIT_U02J_TIDAL_TERROR_NZOTH, 4);
      Skywall.ModObjectLimit(Constants.UNIT_H01Q_IMMORTAL_GUARDIAN_NZOTH, 4);
      Skywall.ModObjectLimit(Constants.UNIT_N0CO_TRENCH_HYDRA_NZOTH, 2);

      Skywall.ModObjectLimit(FourCC("e020"), Faction.UNLIMITED); //Shipyard
      
      //Ships
      Skywall.ModObjectLimit(FourCC("etrs"), Faction.UNLIMITED); //Night Elf Transport Ship
      Skywall.ModObjectLimit(FourCC("h0AU"), Faction.UNLIMITED); // Scout
      Skywall.ModObjectLimit(FourCC("h0AV"), Faction.UNLIMITED); // Frigate
      Skywall.ModObjectLimit(FourCC("h0B1"), Faction.UNLIMITED); // Fireship
      Skywall.ModObjectLimit(FourCC("h057"), Faction.UNLIMITED); // Galley
      Skywall.ModObjectLimit(FourCC("h0B4"), Faction.UNLIMITED); // Boarding
      Skywall.ModObjectLimit(FourCC("h0BA"), Faction.UNLIMITED); // Juggernaut
      Skywall.ModObjectLimit(FourCC("h0B8"), 6); // Bombard


      // All Nzoth Heroes listed below - with total limits

      Skywall.ModObjectLimit(Constants.UNIT_U02K_LORD_OF_THE_FIRELANDS_RAGNAROS, 1);
      Skywall.ModObjectLimit(Constants.UNIT_E023_GRAND_VIZIER_TOLVIR, 1);
      Skywall.ModObjectLimit(Constants.UNIT_U01S_WINDLORD_TWILIGHT, 1);

      FactionManager.Register(Skywall);
    }
  }
}