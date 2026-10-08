using System;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.BansheesHost;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Druids;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.Gilneas;
using WarcraftLegacies.Source.Factions.Ironforge;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.OrcishHorde;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.ScarletCrusade;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Sentinels;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Factions.TaurenTribes;
using WarcraftLegacies.Source.Factions.Theramore;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Who fights whom in Roleplay mode. Each front has attackers and defenders, and a faction is a rival of the factions on
/// the other side of any front it fights on:
/// <list type="bullet">
/// <item>North: the Scourge and the Legion against the North Alliance.</item>
/// <item>South: the Fel Horde and the Legion against the South Alliance.</item>
/// <item>Kalimdor: the Horde against the Night Elves.</item>
/// </list>
/// The Illidari are a wildcard and fight on no front. Factions made by paths fight where their story puts them.
/// </summary>
public static class RoleplayFronts
{
  /// <summary>Whether any faction on <paramref name="teamA"/> fights any faction on <paramref name="teamB"/>.</summary>
  public static bool AreRivals(Team teamA, Team teamB)
  {
    foreach (var factionA in teamA.GetAllFactions())
    {
      foreach (var factionB in teamB.GetAllFactions())
      {
        if (AreFactionRivals(factionA, factionB))
        {
          return true;
        }
      }
    }

    return false;
  }

  /// <summary>Whether <paramref name="factionA"/> and <paramref name="factionB"/> are on opposite sides of a front.</summary>
  public static bool AreFactionRivals(Faction factionA, Faction factionB) =>
    OpposeOn(factionA, factionB, AttacksNorth, DefendsNorth) ||
    OpposeOn(factionA, factionB, AttacksSouth, DefendsSouth) ||
    OpposeOn(factionA, factionB, AttacksKalimdor, DefendsKalimdor);

  private static bool OpposeOn(Faction factionA, Faction factionB, Func<Faction, bool> attacks, Func<Faction, bool> defends) =>
    (attacks(factionA) && defends(factionB)) || (defends(factionA) && attacks(factionB));

  private static bool AttacksNorth(Faction faction) =>
    faction is ScourgeFaction || faction is LegionFaction || faction is FallenPrinceFaction || faction is BansheesHostFaction;

  private static bool DefendsNorth(Faction faction) =>
    faction is LordaeronFaction || faction is DalaranFaction || faction is QuelthalasFaction ||
    faction is ScarletCrusadeFaction || faction is GilneasFaction || faction is TheramoreFaction;

  private static bool AttacksSouth(Faction faction) => faction is FelHordeFaction || faction is LegionFaction;

  private static bool DefendsSouth(Faction faction) =>
    faction is StormwindFaction || faction is IronforgeFaction || faction is KultirasFaction;

  private static bool AttacksKalimdor(Faction faction) => faction is OrcishHordeFaction || faction is TaurenTribesFaction;

  private static bool DefendsKalimdor(Faction faction) => faction is SentinelsFaction || faction is DruidsFaction;
}
