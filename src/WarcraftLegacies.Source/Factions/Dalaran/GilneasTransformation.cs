using System.Collections.Generic;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Gilneas;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran;

/// <summary>Turns Dalaran into Gilneas, keeping what it holds in Gilneas and leaving the rest of its land to its allies.</summary>
public sealed class GilneasTransformation
{
  private static readonly Dictionary<int, int> _gilneasEquivalents = new()
  {
    { UNIT_H065_REFUGE_DALARAN_T1, UNIT_H01R_TOWN_HALL_GILNEAS_T1 },
    { UNIT_H066_CONCLAVE_DALARAN_T2, UNIT_H023_KEEP_GILNEAS_T2 },
    { UNIT_H068_OBSERVATORY_DALARAN_T3, UNIT_H02C_CASTLE_GILNEAS_T3 },
    { UNIT_H063_ARCANE_WELL_DALARAN_FARM, UNIT_H02F_HOUSEHOLD_GILNEAS_FARM },
    { UNIT_H00I_WINDMILL_LORDAERON_OTHER, UNIT_H02F_HOUSEHOLD_GILNEAS_FARM },
    { UNIT_H044_ALTAR_OF_KNOWLEDGE_DALARAN_ALTAR, UNIT_H02X_ALTAR_OF_KINGS_GILNEAS_ALTAR },
    { UNIT_H069_MILITARY_QUARTER_DALARAN_BARRACKS, UNIT_H03Q_CITY_WATCH_GILNEAS_BARRACKS },
    { UNIT_H02N_LUMBER_MILL_DALARAN_RESEARCH, UNIT_H03O_BLACKSMITH_GILNEAS_RESEARCH },
    { UNIT_H036_ARCANE_SANCTUARY_DALARAN_MAGIC, UNIT_H03D_TEMPLE_OF_THE_CURSED_GILNEAS_MAGIC },
    { UNIT_HVLT_ARCANE_VAULT_DALARAN_SHOP, UNIT_N008_TRADE_HOUSE_GILNEAS_SHOP },
    { UNIT_H076_SHIPYARD_DALARAN_SHIPYARD, UNIT_H03H_SHIPYARD_GILNEAS_SHIPYARD },
    { UNIT_H067_MANAFORGE_DALARAN_SPECIALIST, UNIT_H03E_WORGEN_MANOR_GILNEAS_SPECIALIST },
    { UNIT_H078_SCOUT_TOWER_DALARAN_TOWER, UNIT_H039_SCOUT_TOWER_GILNEAS_TOWER },
    { UNIT_H079_ARCANE_TOWER_DALARAN_TOWER, UNIT_H03A_GUARD_TOWER_GILNEAS_TOWER },
    { UNIT_H07A_IMPROVED_ARCANE_TOWER_DALARAN_TOWER, UNIT_H052_IMPROVED_GUARD_TOWER_GILNEAS_TOWER },
    { UNIT_NDGT_KIRIN_TOR_TOWER_DALARAN_TOWER, UNIT_H03B_CANNON_TOWER_GILNEAS_TOWER },
    { UNIT_N004_IMPROVED_KIRIN_TOR_TOWER_DALARAN_TOWER, UNIT_H04N_IMPROVED_CANNON_TOWER_GILNEAS_TOWER }
  };

  private static readonly Dictionary<int, int> _armyEquivalents = new()
  {
    { UNIT_H022_FARMER_DALARAN_WORKER, UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER },
    { UNIT_NHYM_HYDROMANCER_DALARAN, UNIT_H04M_CLERIC_GILNEAS },
    { UNIT_H032_BATTLEMAGE_DALARAN, UNIT_H04E_PROTECTOR_GILNEAS },
    { UNIT_H02D_GEOMANCER_DALARAN, UNIT_N06K_DRUID_OF_THE_SCYTHE_GILNEAS },
    { UNIT_H01I_ARCANIST_DALARAN, UNIT_H04X_HARVEST_WITCH_GILNEAS },
    { UNIT_N007_KIRIN_TOR_DALARAN_ELITE, UNIT_O01V_GREYGUARD_GILNEAS },
    { UNIT_N096_EARTH_GOLEM_DALARAN, UNIT_N06L_ARMORED_WOLF_GILNEAS },
    { UNIT_N0AK_INITIATE_MAGE_DALARAN, UNIT_H03L_SHOTGUNNER_GILNEAS },
    { UNIT_O02U_CRYSTAL_ARTILLERY_DALARAN, UNIT_O04U_CYCLONE_CANNON_GILNEAS }
  };

  /// <summary>Turns <paramref name="dalaran"/>'s player into Gilneas.</summary>
  public void Execute(Faction dalaran)
  {
    var whichPlayer = dalaran.Player;
    if (whichPlayer == null)
    {
      return;
    }

    DalaranHomeland.ClaimHeldLands(dalaran);
    FactionTransition.AssignNewFaction(dalaran, new GilneasFaction(playercolor.Coal) { FormedMidGame = true });
    PathBase.RemoveHero(AllLegends.Dalaran.Antonidas);
    PathBase.RemoveHero(AllLegends.Dalaran.Jaina);
    PathBase.RemoveHero(AllLegends.Dalaran.Aegwynn);
    PathBase.RemoveHero(AllLegends.Dalaran.Medivh);

    var heir = DalaranHomeland.GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.Gilneas);
    DalaranHomeland.MakeBookKeeper(heir);
    PathBase.ConvertStructures(whichPlayer, _gilneasEquivalents, Regions.Gilneas);

    var castle = AllLegends.Gilneas.GilneasCastle.Unit;
    PathBase.RelocateArmy(whichPlayer, _armyEquivalents, castle.X, castle.Y - 700);
    PathBase.SummonLegend(AllLegends.Gilneas.Genn, whichPlayer, new Point(castle.X, castle.Y - 400));
  }
}
