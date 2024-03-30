using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class Nazjatar : Faction
  {
    /// <inheritdoc />
    public Nazjatar() : base("Nazjatar", PLAYER_COLOR_PURPLE, "|c00540081",
      @"ReplaceableTextures\CommandButtons\BTNNagaSummoner.blp")
    {
      ControlPointDefenderUnitTypeId = Constants.UNIT_U02T_CONTROL_POINT_DEFENDER_NAZJATAR;
    }

    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      SharedFactionConfigSetup.AddSharedFactionConfig(this);
    }

    private void RegisterObjectLimits()
    {
      ModObjectLimit(Constants.UNIT_N0C2_PILLAR_OF_WAVES_NZOTH_T1, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0C8_MONUMENT_OF_THE_DEEP_NZOTH_T2, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0C9_TEMPLE_OF_TIDES_NZOTH_T3, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0C1_CORAL_BED_NZOTH_FARM, UNLIMITED);
      ModObjectLimit(Constants.UNIT_H0A4_CORAL_FORGE_NZOTH_RESEARCH, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0C4_SPAWNING_GROUNDS_NZOTH_BARRACKS, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0C7_ROYAL_TEMPLE_NZOTH_MAGIC, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0C3_SHRINE_OF_AZSHARA_NZOTH_SPECIALIST, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N08V_PORTAL_OF_THE_DEEP_NZOTH_SIEGE, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0BZ_DEEP_VAULT_NZOTH_SHOP, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0C0_ALTAR_OF_THE_QUEEN_NZOTH_ALTAR, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N08L_TEMPLE_PROTECTOR_TOLVIR_TOWER, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N08N_IMPROVED_TEMPLE_PROTECTOR_TOLVIR_TOWER, UNLIMITED);

      // All Nzoth Units listed below - with total limits 

      ModObjectLimit(Constants.UNIT_N0D7_DEEP_FORAGER_N_ZOTH_WORKER, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0DT_TIDEMISTRESS_NZOTH, 6);

      ModObjectLimit(Constants.UNIT_N0CA_NAGA_INCURSOR_NZOTH, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0CE_HATCHLING_NZOTH, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0CL_GARGANTUAN_SEA_TURTLE_NZOTH, 8);

      ModObjectLimit(Constants.UNIT_N0CB_DEEPSEER_NZOTH, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N0CD_BLOODKIN_NZOTH, UNLIMITED);
      ModObjectLimit(Constants.UNIT_O060_RIPTIDE_DRAKE_NZOTH, 6);
      ModObjectLimit(Constants.UNIT_U02J_TIDAL_TERROR_NZOTH, 4);
      ModObjectLimit(Constants.UNIT_H01Q_IMMORTAL_GUARDIAN_NZOTH, 4);
      ModObjectLimit(Constants.UNIT_N0CO_TRENCH_HYDRA_NZOTH, 2);

      ModObjectLimit(FourCC("e020"), UNLIMITED); //Shipyard
      //Ships
      ModObjectLimit(FourCC("etrs"), UNLIMITED); //Night Elf Transport Ship
      ModObjectLimit(FourCC("h0AU"), UNLIMITED); // Scout
      ModObjectLimit(FourCC("h0AV"), UNLIMITED); // Frigate
      ModObjectLimit(FourCC("h0B1"), UNLIMITED); // Fireship
      ModObjectLimit(FourCC("h057"), UNLIMITED); // Galley
      ModObjectLimit(FourCC("h0B4"), UNLIMITED); // Boarding
      ModObjectLimit(FourCC("h0BA"), UNLIMITED); // Juggernaut
      ModObjectLimit(FourCC("h0B8"), 6); // Bombard


      // All Nzoth Heroes listed below - with total limits

      ModObjectLimit(Constants.UNIT_H08U_EMPRESS_OF_NAZJATAR_NZOTH, 1);
      ModObjectLimit(Constants.UNIT_H0A5_SEA_WITCH_NZOTH, 1);
      ModObjectLimit(Constants.UNIT_U02U_ABYSSAL_COMMANDER_NAZJATAR, 1);
    }
  }
}