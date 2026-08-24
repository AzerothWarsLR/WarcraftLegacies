using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Manages the single-player world director's active faction.</summary>
public static class WorldDirector
{
  private static readonly Dictionary<int, Faction> _activeFactions = new();

  /// <summary>Returns the registered factions that currently have a playable player slot.</summary>
  public static IReadOnlyList<Faction> GetAvailableFactions() => FactionManager.GetAllFactions()
    .Where(faction => faction.Player != null && faction.ScoreStatus != ScoreStatus.Defeated)
    .ToList();

  /// <summary>Possesses a faction without changing ownership, teams, or diplomacy.</summary>
  public static string Control(player director, string factionKey)
  {
    var factions = GetAvailableFactions();
    if (!TryResolveFaction(factionKey, factions, out var faction, out var error))
    {
      return error;
    }

    // Clear both directions so this cleanly exits the existing "faction control all" mode.
    // Shared-control flags are independent of passive alliance and shared-vision flags.
    foreach (var otherPlayer in Util.EnumeratePlayers())
    {
      if (otherPlayer == director)
      {
        continue;
      }

      director.SetPlayerAllianceStateFullControl(otherPlayer, false);
      otherPlayer.SetPlayerAllianceStateFullControl(director, false);
    }

    var factionPlayer = faction.Player;
    if (factionPlayer != null && factionPlayer != director)
    {
      factionPlayer.SetPlayerAllianceStateFullControl(director, true);
    }

    _activeFactions[director.Id] = faction;
    return GetStatus(director);
  }

  /// <summary>Moves through the live faction registry, wrapping at either end.</summary>
  public static string Cycle(player director, int direction)
  {
    var factions = GetAvailableFactions();
    if (factions.Count == 0)
    {
      return "There are no playable factions available.";
    }

    var currentIndex = _activeFactions.TryGetValue(director.Id, out var activeFaction)
      ? factions.ToList().IndexOf(activeFaction)
      : -1;
    var nextIndex = GetCycledIndex(currentIndex, factions.Count, direction);
    return Control(director, CommandTargets.GetFactionKey(factions[nextIndex]));
  }

  /// <summary>Lists occupied, undefeated factions in cycling order.</summary>
  public static string ListFactions()
  {
    var factions = GetAvailableFactions();
    if (factions.Count == 0)
    {
      return "There are no playable factions available.";
    }

    return "Playable factions:\n" + string.Join("\n", factions.Select((faction, index) =>
      $"{index + 1}. {faction.Name} [{CommandTargets.GetFactionKey(faction)}]"));
  }

  /// <summary>Reports the current manual-timeline and possession state.</summary>
  public static string GetStatus(player director)
  {
    var activeFaction = _activeFactions.TryGetValue(director.Id, out var faction) && faction.Player != null
      ? faction.Name
      : "None";
    return $"=== WORLD DIRECTOR ===\nActive Faction: {activeFaction}\nHistorical Turn: {GameTimeManager.Turn}\nTimeline: MANUAL";
  }

  internal static int GetCycledIndex(int currentIndex, int count, int direction)
  {
    if (count <= 0)
    {
      throw new ArgumentOutOfRangeException(nameof(count));
    }

    if (currentIndex < 0)
    {
      return direction < 0 ? count - 1 : 0;
    }

    return (currentIndex + (direction < 0 ? -1 : 1) + count) % count;
  }

  private static bool TryResolveFaction(string input, IReadOnlyList<Faction> factions, out Faction faction, out string error)
  {
    if (int.TryParse(input, out var number) && number >= 1 && number <= factions.Count)
    {
      faction = factions[number - 1];
      error = "";
      return true;
    }

    var exactMatches = factions.Where(candidate => GetNames(candidate)
      .Any(name => string.Equals(name, input, StringComparison.OrdinalIgnoreCase))).ToList();
    var matches = exactMatches.Count > 0
      ? exactMatches
      : factions.Where(candidate => GetNames(candidate)
        .Any(name => name.StartsWith(input, StringComparison.OrdinalIgnoreCase))).ToList();

    if (matches.Count == 1)
    {
      faction = matches[0];
      error = "";
      return true;
    }

    faction = null!;
    error = matches.Count > 1
      ? $"'{input}' is ambiguous: {string.Join(", ", matches.Select(CommandTargets.GetFactionKey))}."
      : $"There is no playable faction matching '{input}'. Try -factions to list valid keys.";
    return false;
  }

  private static IEnumerable<string> GetNames(Faction faction)
  {
    yield return CommandTargets.GetFactionKey(faction);
    yield return faction.Name;
    foreach (var nickname in faction.Nicknames)
    {
      yield return nickname;
    }
  }
}
