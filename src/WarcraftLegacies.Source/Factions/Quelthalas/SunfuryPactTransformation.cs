using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;
using static WarcraftLegacies.Source.Factions.Quelthalas.SunfuryRelocation;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Turns Quel'thalas into the Sunfury, sworn to Kil'jaeden, and leaves its homeland to the Alliance.</summary>
public sealed class SunfuryPactTransformation
{
  private static readonly Dictionary<int, int> _lordaeronEquivalents = new()
  {
    { UNIT_H033_STEADING_QUELTHALAS_T1, UNIT_HTOW_TOWN_HALL_LORDAERON_T1 },
    { UNIT_H03S_MANSION_QUELTHALAS_T2, UNIT_HKEE_KEEP_LORDAERON_T2 },
    { UNIT_H03T_PALACE_QUELTHALAS_T3, UNIT_HCAS_CASTLE_LORDAERON_T3 },
    { UNIT_H01H_ALTAR_OF_PROWESS_QUELTHALAS_ALTAR, UNIT_HALT_ALTAR_OF_KINGS_LORDAERON_ALTAR },
    { UNIT_H02Y_ARTISAN_S_HALL_QUELTHALAS_RESEARCH, UNIT_HBLA_BLACKSMITH_LORDAERON_RESEARCH },
    { UNIT_H034_ARCANE_SANCTUM_QUELTHALAS_MAGIC, UNIT_H035_ARCANE_STUDY_LORDAERON_MAGIC },
    { UNIT_H073_SCOUT_TOWER_QUELTHALAS_TOWER, UNIT_HWTW_SCOUT_TOWER_LORDAERON_TOWER },
    { UNIT_H074_ARCANE_TOWER_QUELTHALAS_TOWER, UNIT_HGTW_GUARD_TOWER_LORDAERON_TOWER },
    { UNIT_H075_IMPROVED_ARCANE_TOWER_QUELTHALAS_TOWER, UNIT_H006_IMPROVED_GUARD_TOWER_LORDAERON_TOWER },
    { UNIT_NEGT_SUN_TOWER, UNIT_HCTW_CANNON_TOWER_LORDAERON_TOWER },
    { UNIT_N003_IMPROVED_SUN_TOWER_QUELTHALAS_TOWER, UNIT_H007_IMPROVED_CANNON_TOWER_LORDAERON_TOWER },
    { UNIT_H04V_ARCANE_VAULT_QUELTHALAS_SHOP, UNIT_NMRK_MARKETPLACE_LORDAERON_SHOP },
    { UNIT_NHEB_CANTONMENT_QUELTHALAS_BARRACKS, UNIT_HBAR_BARRACKS_LORDAERON_BARRACKS },
    { UNIT_N0A2_CONSORTIUM_QUELTHALAS_SIEGE, UNIT_H094_SIEGE_WORKSHOP_LORDAERON_SIEGE },
    { UNIT_H03J_ACADEMY_QUELTHALAS_SPECIALIST, UNIT_H06C_HIGH_TOWER_LORDAERON_SPECIALIST },
    { UNIT_H077_SHIPYARD_QUELTHALAS_SHIPYARD, UNIT_HSHY_SHIPYARD_LORDAERON_SHIPYARD },
    { UNIT_NEFM_RESIDENCE_QUELTHALAS, UNIT_HHOU_FARM_LORDAERON_FARM }
  };

  private static readonly Dictionary<int, int> _dalaranEquivalents = new()
  {
    { UNIT_H033_STEADING_QUELTHALAS_T1, UNIT_H065_REFUGE_DALARAN_T1 },
    { UNIT_H03S_MANSION_QUELTHALAS_T2, UNIT_H066_CONCLAVE_DALARAN_T2 },
    { UNIT_H03T_PALACE_QUELTHALAS_T3, UNIT_H068_OBSERVATORY_DALARAN_T3 },
    { UNIT_H01H_ALTAR_OF_PROWESS_QUELTHALAS_ALTAR, UNIT_H044_ALTAR_OF_KNOWLEDGE_DALARAN_ALTAR },
    { UNIT_H02Y_ARTISAN_S_HALL_QUELTHALAS_RESEARCH, UNIT_H02N_LUMBER_MILL_DALARAN_RESEARCH },
    { UNIT_H034_ARCANE_SANCTUM_QUELTHALAS_MAGIC, UNIT_H036_ARCANE_SANCTUARY_DALARAN_MAGIC },
    { UNIT_H073_SCOUT_TOWER_QUELTHALAS_TOWER, UNIT_H078_SCOUT_TOWER_DALARAN_TOWER },
    { UNIT_H074_ARCANE_TOWER_QUELTHALAS_TOWER, UNIT_H079_ARCANE_TOWER_DALARAN_TOWER },
    { UNIT_H075_IMPROVED_ARCANE_TOWER_QUELTHALAS_TOWER, UNIT_H07A_IMPROVED_ARCANE_TOWER_DALARAN_TOWER },
    { UNIT_NEGT_SUN_TOWER, UNIT_NDGT_KIRIN_TOR_TOWER_DALARAN_TOWER },
    { UNIT_N003_IMPROVED_SUN_TOWER_QUELTHALAS_TOWER, UNIT_NDGT_KIRIN_TOR_TOWER_DALARAN_TOWER },
    { UNIT_H04V_ARCANE_VAULT_QUELTHALAS_SHOP, UNIT_HVLT_ARCANE_VAULT_DALARAN_SHOP },
    { UNIT_NHEB_CANTONMENT_QUELTHALAS_BARRACKS, UNIT_H069_MILITARY_QUARTER_DALARAN_BARRACKS },
    { UNIT_N0A2_CONSORTIUM_QUELTHALAS_SIEGE, UNIT_H067_MANAFORGE_DALARAN_SPECIALIST },
    { UNIT_H03J_ACADEMY_QUELTHALAS_SPECIALIST, UNIT_H067_MANAFORGE_DALARAN_SPECIALIST },
    { UNIT_H077_SHIPYARD_QUELTHALAS_SHIPYARD, UNIT_H076_SHIPYARD_DALARAN_SHIPYARD },
    { UNIT_NEFM_RESIDENCE_QUELTHALAS, UNIT_H063_ARCANE_WELL_DALARAN_FARM }
  };

  /// <summary>Turns <paramref name="quelthalas"/>'s player into the Sunfury.</summary>
  public void Execute(Faction quelthalas)
  {
    var whichPlayer = quelthalas.Player;
    if (whichPlayer == null)
    {
      return;
    }

    var sunfury = new SunfuryFaction(playercolor.Maroon);
    FactionTransition.AssignNewFaction(quelthalas, sunfury);
    sunfury.ModObjectLimit(UNIT_H098_SUNFURY_MASTERMIND_QUELTHALAS, -1);
    sunfury.ModObjectLimit(UNIT_U02V_HIGH_ASTROMANCER_SUNFURY, -1);
    sunfury.ModObjectLimit(UNIT_H0CR_MAGISTER_SUNFURY, 1);
    sunfury.ModObjectLimit(UNIT_H0CS_BETRAYER_OF_SILVERMOON_SUNFURY, 1);

    RemoveHero(AllLegends.Quel.Anasterian);
    RemoveHero(AllLegends.Quel.Rommath);
    RemoveHero(AllLegends.Quel.Sylvanas);
    RemoveHero(AllLegends.Quel.Lorthemar);

    LeaveStructures(whichPlayer);
    RelocateArmy(whichPlayer);
    BuildBase(whichPlayer);
    PathBase.SummonLegend(AllLegends.Sunfury.Kael, whichPlayer, new Point(BaseX, BaseY + 400));
  }

  /// <summary>Lordaeron if it's still in the game, otherwise Dalaran, otherwise nobody, with the buildings each turns Quel'thalas buildings into.</summary>
  private static player GetHomelandHeir(out Dictionary<int, int>? equivalents)
  {
    if (FactionManager.TryGetFactionByType<LordaeronFaction>(out var lordaeron) && IsStillInGame(lordaeron))
    {
      equivalents = _lordaeronEquivalents;
      return lordaeron.Player!;
    }

    if (FactionManager.TryGetFactionByType<DalaranFaction>(out var dalaran) && IsStillInGame(dalaran))
    {
      equivalents = _dalaranEquivalents;
      return dalaran.Player!;
    }

    equivalents = null;
    return player.NeutralPassive;
  }

  private static bool IsStillInGame(Faction faction) =>
    faction.Player != null && faction.ScoreStatus == ScoreStatus.Undefeated;

  private static void LeaveStructures(player whichPlayer)
  {
    var heir = GetHomelandHeir(out var equivalents);
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (!whichUnit.Alive || !whichUnit.IsUnitType(unittype.Structure))
      {
        continue;
      }

      var heirType = 0;
      if (equivalents != null && whichUnit.IsRemovable())
      {
        heirType = equivalents.GetValueOrDefault(whichUnit.UnitType);
      }

      if (heirType != 0)
      {
        Replace(whichUnit, heir, heirType, whichUnit.X, whichUnit.Y);
      }
      else
      {
        whichUnit.SetOwner(heir);
      }
    }
  }
}
