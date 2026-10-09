using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Turns Quel'thalas into the Blood Elves, led by Kael'thas from a new base beside Tempest Keep.</summary>
public sealed class KaelsExodusTransformation
{
  private const float BaseX = 2752;
  private const float BaseY = -22912;

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

    BuildBase(whichPlayer);
    PathBase.SummonLegend(AllLegends.Sunfury.Kael, whichPlayer, new Point(BaseX, BaseY + 400));
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
    PathBase.CreateStructure(whichPlayer, UNIT_H0C7_ARBORETUM_SUNFURY_FARM, BaseX - 256, BaseY - 384);
    PathBase.CreateStructure(whichPlayer, UNIT_H0C7_ARBORETUM_SUNFURY_FARM, BaseX + 256, BaseY - 384);
    PathBase.CreateUnits(whichPlayer, UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER, 5, BaseX + 200, BaseY + 200);
    PathBase.CreateUnits(whichPlayer, UNIT_N09S_CENTURION_SUNFURY, 3, BaseX, BaseY + 500);
    PathBase.CreateUnits(whichPlayer, UNIT_H0CF_BOWMAN_SUNFURY, 3, BaseX + 200, BaseY + 500);
  }
}
