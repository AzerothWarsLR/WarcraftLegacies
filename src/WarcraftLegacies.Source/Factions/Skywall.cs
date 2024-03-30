using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class Skywall : Faction
  {
    /// <inheritdoc />
    public Skywall() : base("Elemental Lords", PLAYER_COLOR_PEACH, "|c00540081",
      @"ReplaceableTextures\CommandButtons\BTNFrostRevenant2.blp")
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
      ModObjectLimit(Constants.UNIT_N05Q_PILLAR_OF_WAVES_TOLVIR_T1, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N05W_MONUMENT_OF_THE_DEEP_TOLVIR_T2, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N06R_TEMPLE_OF_TIDES_TOLVIR_T3, UNLIMITED);
      ModObjectLimit(Constants.UNIT_H03I_CORAL_FORGE_TOLVIR_RESEARCH, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N08A_SPAWNING_GROUNDS_TOLVIR_BARRACKS, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N07N_ROYAL_TEMPLE_TOLVIR_MAGIC, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N08B_SHRINE_OF_AZSHARA_TOLVIR_SPECIALIST, UNLIMITED);
      //ModObjectLimit(Constants.UNIT_N08V_PORTAL_OF_THE_DEEP_NZOTH_SIEGE, Faction.UNLIMITED);
      ModObjectLimit(Constants.UNIT_N07J_DEEP_VAULT_TOLVIR_SHOP, UNLIMITED);
      ModObjectLimit(Constants.UNIT_N078_ALTAR_OF_THE_QUEEN_TOLVIR_ALTAR, UNLIMITED);
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

      ModObjectLimit(Constants.UNIT_U02K_LORD_OF_THE_FIRELANDS_RAGNAROS, 1);
      ModObjectLimit(Constants.UNIT_E023_GRAND_VIZIER_TOLVIR, 1);
      ModObjectLimit(Constants.UNIT_U01S_WINDLORD_TWILIGHT, 1);
    }
  }
}