using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;
using static WarcraftLegacies.Source.Factions.Quelthalas.SunfuryRelocation;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Turns Quel'thalas into the Sunfury, sworn to Kil'jaeden, and leaves its homeland to the Alliance.</summary>
public sealed class SunfuryPactTransformation
{
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

    PathBase.RemoveHero(AllLegends.Quel.Anasterian);
    PathBase.RemoveHero(AllLegends.Quel.Rommath);
    PathBase.RemoveHero(AllLegends.Quel.Sylvanas);
    PathBase.RemoveHero(AllLegends.Quel.Lorthemar);

    LeaveHomeland(whichPlayer);
    RelocateArmy(whichPlayer);
    BuildBase(whichPlayer);
    PathBase.SummonLegend(AllLegends.Sunfury.Kael, whichPlayer, new Point(BaseX, BaseY + 400));
  }
}
