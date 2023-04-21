using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Mechanics.Frostwolf;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class TwilightHammerSetup
  {
    public static Faction? TwilightHammer { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      TwilightHammer = new Faction(FactionNames.TwilightHammer, PLAYER_COLOR_LAVENDER, "|cff9680b4",
        "ReplaceableTextures\\CommandButtons\\BTNChogall.blp")
      {
        ControlPointDefenderUnitTypeId = Constants.UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF,
      };

      TwilightHammer.ModObjectLimit(Constants.UNIT_N0C2_PILLAR_OF_WAVES_NZOTH_T1, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0C8_MONUMENT_OF_THE_DEEP_NZOTH_T2, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0C9_TEMPLE_OF_TIDES_NZOTH_T3, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0C1_CORAL_BED_NZOTH_FARM, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_H0A4_CORAL_FORGE_NZOTH_RESEARCH, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0C4_SPAWNING_GROUNDS_NZOTH_BARRACKS, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0C7_ROYAL_TEMPLE_NZOTH_MAGIC, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0C3_SHRINE_OF_AZSHARA_NZOTH_SPECIALIST, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N08V_PORTAL_OF_THE_DEEP_NZOTH_SPECIALIST, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0BZ_DEEP_VAULT_NZOTH_SHOP, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0C0_ALTAR_OF_THE_QUEEN_NZOTH_ALTAR, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N08L_TEMPLE_PROTECTOR_TOLVIR_TOWER, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N08N_IMPROVED_TEMPLE_PROTECTOR_TOLVIR_TOWER, Faction.UNLIMITED);

      // All Nzoth Units listed below - with total limits 

      TwilightHammer.ModObjectLimit(Constants.UNIT_N0D7_DEEP_FORAGER_N_ZOTH_WORKER, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0DT_TIDEMISTRESS_NZOTH, 6);

      TwilightHammer.ModObjectLimit(Constants.UNIT_N0CA_NAGA_INCURSOR_NZOTH, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0CE_HATCHLING_NZOTH, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0CL_GARGANTUAN_SEA_TURTLE_NZOTH, 8);

      TwilightHammer.ModObjectLimit(Constants.UNIT_N0CB_DEEPSEER_NZOTH, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0CD_BLOODKIN_NZOTH, Faction.UNLIMITED);
      TwilightHammer.ModObjectLimit(Constants.UNIT_O060_RIPTIDE_DRAKE_NZOTH, 6);
      TwilightHammer.ModObjectLimit(Constants.UNIT_U02J_TIDAL_TERROR_NZOTH, 4);
      TwilightHammer.ModObjectLimit(Constants.UNIT_H01Q_IMMORTAL_GUARDIAN_NZOTH, 4);
      TwilightHammer.ModObjectLimit(Constants.UNIT_N0CO_TRENCH_HYDRA_NZOTH, 2);

      // All Nzoth Ships

      TwilightHammer.ModObjectLimit(FourCC("ushp"), Faction.UNLIMITED); //Undead Shipyard
      TwilightHammer.ModObjectLimit(FourCC("ubot"), Faction.UNLIMITED); //Undead Transport Ship
      TwilightHammer.ModObjectLimit(FourCC("h0AT"), Faction.UNLIMITED); //Scout
      TwilightHammer.ModObjectLimit(FourCC("h0AW"), Faction.UNLIMITED); //Frigate
      TwilightHammer.ModObjectLimit(FourCC("h0AM"), Faction.UNLIMITED); //Fireship
      TwilightHammer.ModObjectLimit(FourCC("h0AZ"), Faction.UNLIMITED); //Galley
      TwilightHammer.ModObjectLimit(FourCC("h0AQ"), Faction.UNLIMITED); //Boarding
      TwilightHammer.ModObjectLimit(FourCC("h0BB"), Faction.UNLIMITED); //Juggernaut
      TwilightHammer.ModObjectLimit(FourCC("h0B9"), 6); //Bombard


      // All Nzoth Heroes listed below - with total limits

      TwilightHammer.ModObjectLimit(Constants.UNIT_U00P_C_THRAX_ABERRATION, 1);
      TwilightHammer.ModObjectLimit(Constants.UNIT_H08U_EMPRESS_OF_NAZJATAR_NZOTH, 1);
      TwilightHammer.ModObjectLimit(Constants.UNIT_H0A5_SEA_WITCH_NZOTH, 1);
      //Nazjatar.ModObjectLimit(Constants.UNIT_N0CO_TRENCH_HYDRA_NZOTH, 1);

      TwilightHammer.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion

      FactionManager.Register(TwilightHammer);
    }
  }
}