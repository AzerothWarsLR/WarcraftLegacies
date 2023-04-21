using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Mechanics.Frostwolf;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class BlackEmpireSetup
  {
    public static Faction? BlackEmpire { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      BlackEmpire = new Faction(FactionNames.BlackEmpire, PLAYER_COLOR_TURQUOISE, "|C0000FFFF",
        "ReplaceableTextures\\CommandButtons\\BTNNzothIcon.blp")
      {
        ControlPointDefenderUnitTypeId = Constants.UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF,
      };

      BlackEmpire.ModObjectLimit(Constants.UNIT_N0C2_PILLAR_OF_WAVES_NZOTH_T1, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0C8_MONUMENT_OF_THE_DEEP_NZOTH_T2, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0C9_TEMPLE_OF_TIDES_NZOTH_T3, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0C1_CORAL_BED_NZOTH_FARM, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_H0A4_CORAL_FORGE_NZOTH_RESEARCH, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0C4_SPAWNING_GROUNDS_NZOTH_BARRACKS, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0C7_ROYAL_TEMPLE_NZOTH_MAGIC, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0C3_SHRINE_OF_AZSHARA_NZOTH_SPECIALIST, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N08V_PORTAL_OF_THE_DEEP_NZOTH_SPECIALIST, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0BZ_DEEP_VAULT_NZOTH_SHOP, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0C0_ALTAR_OF_THE_QUEEN_NZOTH_ALTAR, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N08L_TEMPLE_PROTECTOR_TOLVIR_TOWER, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N08N_IMPROVED_TEMPLE_PROTECTOR_TOLVIR_TOWER, Faction.UNLIMITED);

      /// All Nzoth Units listed below - with total limits 

      BlackEmpire.ModObjectLimit(Constants.UNIT_N0D7_DEEP_FORAGER_N_ZOTH_WORKER, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0DT_TIDEMISTRESS_NZOTH, 6);

      BlackEmpire.ModObjectLimit(Constants.UNIT_N0CA_NAGA_INCURSOR_NZOTH, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0CE_HATCHLING_NZOTH, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0CL_GARGANTUAN_SEA_TURTLE_NZOTH, 8);

      BlackEmpire.ModObjectLimit(Constants.UNIT_N0CB_DEEPSEER_NZOTH, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0CD_BLOODKIN_NZOTH, Faction.UNLIMITED);
      BlackEmpire.ModObjectLimit(Constants.UNIT_O060_RIPTIDE_DRAKE_NZOTH, 6);
      BlackEmpire.ModObjectLimit(Constants.UNIT_U02J_TIDAL_TERROR_NZOTH, 4);
      BlackEmpire.ModObjectLimit(Constants.UNIT_H01Q_IMMORTAL_GUARDIAN_NZOTH, 4);
      BlackEmpire.ModObjectLimit(Constants.UNIT_N0CO_TRENCH_HYDRA_NZOTH, 2);

      /// All Nzoth Ships

      BlackEmpire.ModObjectLimit(FourCC("ushp"), Faction.UNLIMITED); //Undead Shipyard
      BlackEmpire.ModObjectLimit(FourCC("ubot"), Faction.UNLIMITED); //Undead Transport Ship
      BlackEmpire.ModObjectLimit(FourCC("h0AT"), Faction.UNLIMITED); //Scout
      BlackEmpire.ModObjectLimit(FourCC("h0AW"), Faction.UNLIMITED); //Frigate
      BlackEmpire.ModObjectLimit(FourCC("h0AM"), Faction.UNLIMITED); //Fireship
      BlackEmpire.ModObjectLimit(FourCC("h0AZ"), Faction.UNLIMITED); //Galley
      BlackEmpire.ModObjectLimit(FourCC("h0AQ"), Faction.UNLIMITED); //Boarding
      BlackEmpire.ModObjectLimit(FourCC("h0BB"), Faction.UNLIMITED); //Juggernaut
      BlackEmpire.ModObjectLimit(FourCC("h0B9"), 6); //Bombard


      /// All Nzoth Heroes listed below - with total limits

      BlackEmpire.ModObjectLimit(Constants.UNIT_U00P_C_THRAX_ABERRATION, 1);
      BlackEmpire.ModObjectLimit(Constants.UNIT_H08U_EMPRESS_OF_NAZJATAR_NZOTH, 1);
      BlackEmpire.ModObjectLimit(Constants.UNIT_H0A5_SEA_WITCH_NZOTH, 1);
      //Nazjatar.ModObjectLimit(Constants.UNIT_N0CO_TRENCH_HYDRA_NZOTH, 1);

      BlackEmpire.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion

      FactionManager.Register(BlackEmpire);
    }
  }
}