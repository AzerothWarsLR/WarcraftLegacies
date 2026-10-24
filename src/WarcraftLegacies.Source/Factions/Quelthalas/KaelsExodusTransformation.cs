using MacroTools.Factions;
using MacroTools.Localization;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;
using static WarcraftLegacies.Source.Factions.Quelthalas.SunfuryRelocation;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Turns Quel'thalas into the Blood Elves, led by Kael'thas from a new base beside Tempest Keep.</summary>
public sealed class KaelsExodusTransformation
{
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

    PathBase.RemoveHero(AllLegends.Quel.Anasterian);
    PathBase.RemoveHero(AllLegends.Quel.Rommath);
    PathBase.RemoveHero(AllLegends.Quel.Sylvanas);

    ConvertToSunfury(whichPlayer);
    BuildBase(whichPlayer);
    PathBase.SummonLegend(AllLegends.Sunfury.Kael, whichPlayer, new Point(BaseX, BaseY + 400));
    PathBase.SummonLegend(AllLegends.Quel.Lorthemar, whichPlayer, new Point(BaseX + 200, BaseY + 400));
  }
}
