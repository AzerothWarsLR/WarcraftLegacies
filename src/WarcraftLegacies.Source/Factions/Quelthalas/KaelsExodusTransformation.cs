using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Turns Quel'thalas into the Blood Elves, led by Kael'thas from a new base beside Tempest Keep.</summary>
public sealed class KaelsExodusTransformation
{
  private const float BaseX = 2752;
  private const float BaseY = -22912;

  private static readonly Dictionary<int, int> BloodElfEquivalents = new()
  {
    { UNIT_H033_STEADING_QUELTHALAS_T1, UNIT_H02P_HOLDING_SUNFURY_T1 },
    { UNIT_H03S_MANSION_QUELTHALAS_T2, UNIT_H0C4_COVENANT_SUNFURY_T2 },
    { UNIT_H03T_PALACE_QUELTHALAS_T3, UNIT_H0C5_SANCTUARY_SUNFURY_T3 },
    { UNIT_H01H_ALTAR_OF_PROWESS_QUELTHALAS_ALTAR, UNIT_H0C6_ALTAR_OF_BLOOD_SUNFURY_ALTAR },
    { UNIT_H02Y_ARTISAN_S_HALL_QUELTHALAS_RESEARCH, UNIT_H0C8_FORGE_SUNFURY_RESEARCH },
    { UNIT_H034_ARCANE_SANCTUM_QUELTHALAS_MAGIC, UNIT_H0CB_LYCEUM_ARCANUM_SUNFURY_MAGIC },
    { UNIT_H073_SCOUT_TOWER_QUELTHALAS_TOWER, UNIT_H0CD_SCOUT_TOWER_SUNFURY_TOWER },
    { UNIT_H074_ARCANE_TOWER_QUELTHALAS_TOWER, UNIT_N0E0_SKY_FURY_TOWER_SUNFURY_TOWER },
    { UNIT_H075_IMPROVED_ARCANE_TOWER_QUELTHALAS_TOWER, UNIT_N0E1_IMPROVED_SKY_FURY_TOWER_SUNFURY_TOWER },
    { UNIT_NEGT_SUN_TOWER, UNIT_N0E0_SKY_FURY_TOWER_SUNFURY_TOWER },
    { UNIT_N003_IMPROVED_SUN_TOWER_QUELTHALAS_TOWER, UNIT_N0E1_IMPROVED_SKY_FURY_TOWER_SUNFURY_TOWER },
    { UNIT_H04V_ARCANE_VAULT_QUELTHALAS_SHOP, UNIT_H0CC_SHAPER_S_HALL_SUNFURY_SHOP },
    { UNIT_NHEB_CANTONMENT_QUELTHALAS_BARRACKS, UNIT_H0C9_TRAINING_QUARTER_SUNFURY_BARRACKS },
    { UNIT_N0A2_CONSORTIUM_QUELTHALAS_SIEGE, UNIT_H0CI_ARTIFICER_S_COURT_SUNFURY_SIEGE },
    { UNIT_H03J_ACADEMY_QUELTHALAS_SPECIALIST, UNIT_H0CA_ANCIENT_POOL_SUNFURY_SPECIALIST },
    { UNIT_H077_SHIPYARD_QUELTHALAS_SHIPYARD, UNIT_TP04_SHIPYARD_SUNFURY_SHIPYARD },
    { UNIT_NBEE_ARCHITECT_QUELTHALAS_WORKER, UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER }
  };

  /// <summary>Turns <paramref name="quelthalas"/>'s player into the Blood Elves.</summary>
  public void Execute(Faction quelthalas)
  {
    var whichPlayer = quelthalas.Player;
    if (whichPlayer == null)
    {
      return;
    }

    var bloodElves = new SunfuryFaction();
    FactionTransition.AssignNewFaction(quelthalas, bloodElves);
    bloodElves.Name = Loc.Get("Blood Elves");
    bloodElves.ModObjectLimit(UNIT_H098_SUNFURY_MASTERMIND_QUELTHALAS, -1);
    bloodElves.ModObjectLimit(UNIT_H02E_REGENT_OF_QUEL_THALAS_QUELTHALAS_VASSAL, 1);

    RemoveHero(AllLegends.Quel.Anasterian);
    RemoveHero(AllLegends.Quel.Rommath);
    RemoveHero(AllLegends.Quel.Sylvanas);

    ConvertToBloodElves(whichPlayer);
    BuildBase(whichPlayer);
    PathBase.SummonLegend(AllLegends.Sunfury.Kael, whichPlayer, new Point(BaseX, BaseY + 400));
    PathBase.SummonLegend(AllLegends.Quel.Lorthemar, whichPlayer, new Point(BaseX + 200, BaseY + 400));
  }

  private static void ConvertToBloodElves(player whichPlayer)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (!whichUnit.Alive || !whichUnit.IsRemovable())
      {
        continue;
      }

      if (!BloodElfEquivalents.TryGetValue(whichUnit.UnitType, out var bloodElfType))
      {
        continue;
      }

      var x = whichUnit.X;
      var y = whichUnit.Y;
      var facing = whichUnit.Facing;
      var lifePercent = whichUnit.Life / whichUnit.MaxLife;
      whichUnit.Dispose();
      var replacement = unit.Create(whichPlayer, bloodElfType, x, y, facing);
      if (replacement != null)
      {
        replacement.Life = replacement.MaxLife * lifePercent;
      }
    }
  }

  private static void RemoveHero(LegendaryHero hero)
  {
    var heroUnit = hero.Unit;
    if (heroUnit == null)
    {
      return;
    }

    heroUnit.DropAllItems();
    hero.Unit = null;
    heroUnit.Dispose();
  }

  private static void BuildBase(player whichPlayer)
  {
    PathBase.CreateStructure(whichPlayer, UNIT_H02P_HOLDING_SUNFURY_T1, BaseX, BaseY);
    PathBase.CreateStructure(whichPlayer, UNIT_H0C9_TRAINING_QUARTER_SUNFURY_BARRACKS, BaseX + 512, BaseY + 192);
    PathBase.CreateStructure(whichPlayer, UNIT_H0C6_ALTAR_OF_BLOOD_SUNFURY_ALTAR, BaseX - 512, BaseY + 192);
    PathBase.CreateUnits(whichPlayer, UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER, 5, BaseX + 200, BaseY + 200);
    PathBase.CreateUnits(whichPlayer, UNIT_N09S_CENTURION_SUNFURY, 3, BaseX, BaseY + 500);
    PathBase.CreateUnits(whichPlayer, UNIT_H0CF_BOWMAN_SUNFURY, 3, BaseX + 200, BaseY + 500);

    PathBase.CreateStructure(whichPlayer, UNIT_N05X_TEMPEST_KEEP_QUELTHALAS_OTHER, 4480, -21696);
    PathBase.CreateStructure(whichPlayer, UNIT_H0CA_ANCIENT_POOL_SUNFURY_SPECIALIST, 4192, -21344);
    PathBase.CreateStructure(whichPlayer, UNIT_H0CI_ARTIFICER_S_COURT_SUNFURY_SIEGE, 4064, -22048);
  }
}
