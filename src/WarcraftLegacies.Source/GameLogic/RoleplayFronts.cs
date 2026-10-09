using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.BansheesHost;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Druids;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.Forsaken;
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
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>Who fights whom in Roleplay mode, across the North, South and Kalimdor fronts.</summary>
public static class RoleplayFronts
{
  private static readonly List<Func<Team, Team, bool>> ExtraRivalries = new();

  /// <summary>Makes teams that pass <paramref name="rivalry"/> rivals too, like a pact formed against the Legion.</summary>
  public static void AddTeamRivalry(Func<Team, Team, bool> rivalry) => ExtraRivalries.Add(rivalry);

  /// <summary>Whether <paramref name="teamA"/> and <paramref name="teamB"/> fight each other.</summary>
  public static bool AreRivals(Team teamA, Team teamB)
  {
    foreach (var rivalry in ExtraRivalries)
    {
      if (rivalry(teamA, teamB))
      {
        return true;
      }
    }

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
    OpposeOn(factionA, factionB, AttacksKalimdor, DefendsKalimdor) ||
    OpposeOn(factionA, factionB, IsForsaken, ServesTheLichKing);

  private static bool OpposeOn(Faction factionA, Faction factionB, Func<Faction, bool> attacks, Func<Faction, bool> defends) =>
    (attacks(factionA) && defends(factionB)) || (defends(factionA) && attacks(factionB));

  private static bool AttacksNorth(Faction faction) =>
    faction is ScourgeFaction || faction is LegionFaction || faction is FallenPrinceFaction || faction is BansheesHostFaction ||
    (faction is ForsakenFaction && !IsOnTeam(faction, TeamSetup.Horde));

  private static bool DefendsNorth(Faction faction) =>
    faction is LordaeronFaction || faction is DalaranFaction || faction is QuelthalasFaction ||
    faction is ScarletCrusadeFaction || faction is GilneasFaction ||
    (faction is TheramoreFaction && !IsOnKalimdorTeam(faction));

  private static bool IsForsaken(Faction faction) => faction is ForsakenFaction && IsOnTeam(faction, TeamSetup.Horde);

  private static bool ServesTheLichKing(Faction faction) =>
    faction is ScourgeFaction || faction is FallenPrinceFaction || faction is BansheesHostFaction;

  private static bool AttacksSouth(Faction faction) => faction is FelHordeFaction || faction is LegionFaction;

  private static bool DefendsSouth(Faction faction) =>
    faction is StormwindFaction || faction is IronforgeFaction || faction is KultirasFaction;

  private static bool AttacksKalimdor(Faction faction) =>
    faction is OrcishHordeFaction || faction is TaurenTribesFaction || (faction is TheramoreFaction && IsOnTeam(faction, TeamSetup.Horde));

  private static bool DefendsKalimdor(Faction faction) =>
    faction is SentinelsFaction || faction is DruidsFaction || (faction is TheramoreFaction && IsOnTeam(faction, TeamSetup.NightElves));

  /// <summary>Whether Theramore has joined the Horde or the Night Elves.</summary>
  private static bool IsOnKalimdorTeam(Faction faction) =>
    IsOnTeam(faction, TeamSetup.Horde) || IsOnTeam(faction, TeamSetup.NightElves);

  private static bool IsOnTeam(Faction faction, Team team)
  {
    var factionPlayer = faction.Player;
    return factionPlayer != null && factionPlayer.GetPlayerData().Team == team;
  }
}
