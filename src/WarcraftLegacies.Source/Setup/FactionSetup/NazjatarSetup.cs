using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Mechanics.Frostwolf;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class NazjatarSetup
  {
    public static Faction? Nazjatar { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Nazjatar = new Faction(FactionNames.Nazjatar, PLAYER_COLOR_PURPLE, "|c00540081",
        "ReplaceableTextures\\CommandButtons\\BTNNagaSummoner.blp")
      {
        ControlPointDefenderUnitTypeId = Constants.UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF,
      };

      Nazjatar.ModObjectLimit(Constants.UNIT_N0C2_PILLAR_OF_WAVES_NZOTH_T1, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0C8_MONUMENT_OF_THE_DEEP_NZOTH_T2, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0C9_TEMPLE_OF_TIDES_NZOTH_T3, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0C1_CORAL_BED_NZOTH_FARM, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_H0A4_CORAL_FORGE_NZOTH_RESEARCH, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0C4_SPAWNING_GROUNDS_NZOTH_BARRACKS, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0C7_ROYAL_TEMPLE_NZOTH_MAGIC, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0C3_SHRINE_OF_AZSHARA_NZOTH_SPECIALIST, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N08V_PORTAL_OF_THE_DEEP_NZOTH_SPECIALIST, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0BZ_DEEP_VAULT_NZOTH_SHOP, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0C0_ALTAR_OF_THE_QUEEN_NZOTH_ALTAR, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N08L_TEMPLE_PROTECTOR_TOLVIR_TOWER, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N08N_IMPROVED_TEMPLE_PROTECTOR_TOLVIR_TOWER, Faction.UNLIMITED);

      /// All Nzoth Units listed below - with total limits 

      Nazjatar.ModObjectLimit(Constants.UNIT_N0D7_DEEP_FORAGER_N_ZOTH_WORKER, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0DT_TIDEMISTRESS_NZOTH, 6);
      
      Nazjatar.ModObjectLimit(Constants.UNIT_N0CA_NAGA_INCURSOR_NZOTH, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0CE_HATCHLING_NZOTH, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0CL_GARGANTUAN_SEA_TURTLE_NZOTH, 8);

      Nazjatar.ModObjectLimit(Constants.UNIT_N0CB_DEEPSEER_NZOTH, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0CD_BLOODKIN_NZOTH, Faction.UNLIMITED);
      Nazjatar.ModObjectLimit(Constants.UNIT_O060_RIPTIDE_DRAKE_NZOTH, 6);
      Nazjatar.ModObjectLimit(Constants.UNIT_U02J_TIDAL_TERROR_NZOTH, 4);
      Nazjatar.ModObjectLimit(Constants.UNIT_H01Q_IMMORTAL_GUARDIAN_NZOTH, 4);
      Nazjatar.ModObjectLimit(Constants.UNIT_N0CO_TRENCH_HYDRA_NZOTH, 2);

      /// All Nzoth Ships

      Nazjatar.ModObjectLimit(FourCC("ushp"), Faction.UNLIMITED); //Undead Shipyard
      Nazjatar.ModObjectLimit(FourCC("ubot"), Faction.UNLIMITED); //Undead Transport Ship
      Nazjatar.ModObjectLimit(FourCC("h0AT"), Faction.UNLIMITED); //Scout
      Nazjatar.ModObjectLimit(FourCC("h0AW"), Faction.UNLIMITED); //Frigate
      Nazjatar.ModObjectLimit(FourCC("h0AM"), Faction.UNLIMITED); //Fireship
      Nazjatar.ModObjectLimit(FourCC("h0AZ"), Faction.UNLIMITED); //Galley
      Nazjatar.ModObjectLimit(FourCC("h0AQ"), Faction.UNLIMITED); //Boarding
      Nazjatar.ModObjectLimit(FourCC("h0BB"), Faction.UNLIMITED); //Juggernaut
      Nazjatar.ModObjectLimit(FourCC("h0B9"), 6); //Bombard


      /// All Nzoth Heroes listed below - with total limits

      Nazjatar.ModObjectLimit(Constants.UNIT_U00P_C_THRAX_ABERRATION, 1);
      Nazjatar.ModObjectLimit(Constants.UNIT_H08U_EMPRESS_OF_NAZJATAR_NZOTH, 1);
      Nazjatar.ModObjectLimit(Constants.UNIT_H0A5_SEA_WITCH_NZOTH, 1);
      //Nazjatar.ModObjectLimit(Constants.UNIT_N0CO_TRENCH_HYDRA_NZOTH, 1);

      Nazjatar.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion

      FactionManager.Register(Nazjatar);
    }
  }
}