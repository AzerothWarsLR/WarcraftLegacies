using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
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
  private static Dictionary<int, int> LordaeronEquivalents => UnitEquivalents.Pair(
    QuelthalasObjectInfo.GetAllObjectLimits(), LordaeronObjectInfo.GetAllObjectLimits());

  private static Dictionary<int, int> DalaranEquivalents => UnitEquivalents.Pair(
    QuelthalasObjectInfo.GetAllObjectLimits(), DalaranObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>
    {
      { UNIT_N0A2_CONSORTIUM_QUELTHALAS_SIEGE, UNIT_H067_MANAFORGE_DALARAN_SPECIALIST }
    });

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
      equivalents = LordaeronEquivalents;
      return lordaeron.Player!;
    }

    if (FactionManager.TryGetFactionByType<DalaranFaction>(out var dalaran) && IsStillInGame(dalaran))
    {
      equivalents = DalaranEquivalents;
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
    PathBase.HandOverStructures(whichPlayer, heir, equivalents);
  }
}
