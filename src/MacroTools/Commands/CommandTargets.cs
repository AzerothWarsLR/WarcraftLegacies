using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Quests;

namespace MacroTools.Commands;

/// <summary>
/// Resolves chat-typed command parameters into the game-state objects a command needs to act on.
/// </summary>
public static class CommandTargets
{
  private const string FactionSuffix = "Faction";
  private const string QuestPrefix = "Quest";

  /// <summary>
  /// Resolves a <see cref="Faction"/> either by its 1-based position in <see cref="FactionManager.GetAllFactions"/>
  /// or by its C# class name.
  /// </summary>
  public static bool TryResolveFaction(string key, [NotNullWhen(true)] out Faction? faction, out string error)
  {
    if (TryResolveByIndexOrKey(key, FactionManager.GetAllFactions(), GetFactionKey, out faction))
    {
      error = "";
      return true;
    }

    error = $"There is no faction with key '{key}'. Try -faction list to list valid keys.";
    return false;
  }

  /// <summary>
  /// Returns the key used to target a <see cref="Faction"/> in chat commands.
  /// </summary>
  public static string GetFactionKey(Faction faction)
  {
    var typeName = faction.GetType().Name;
    return typeName.EndsWith(FactionSuffix, StringComparison.Ordinal)
      ? typeName.Substring(0, typeName.Length - FactionSuffix.Length)
      : typeName;
  }

  /// <summary>
  /// Resolves a <see cref="QuestData"/> belonging to the given <see cref="Faction"/> either by its 1-based
  /// position in <see cref="Faction.GetAllQuests"/> or by its C# class name.
  /// </summary>
  public static bool TryResolveQuest(Faction faction, string key, [NotNullWhen(true)] out QuestData? quest, out string error)
  {
    if (TryResolveByIndexOrKey(key, faction.GetAllQuests(), GetQuestKey, out quest))
    {
      error = "";
      return true;
    }

    error = $"{faction.Name} has no quest with key '{key}'. Try -quest list {faction.Name} to list valid keys.";
    return false;
  }

  /// <summary>
  /// Returns the key used to target a <see cref="QuestData"/> in chat commands.
  /// </summary>
  public static string GetQuestKey(QuestData quest)
  {
    var typeName = quest.GetType().Name;
    return typeName.StartsWith(QuestPrefix, StringComparison.Ordinal)
      ? typeName.Substring(QuestPrefix.Length)
      : typeName;
  }

  /// <summary>
  /// Resolves a <see cref="Power"/> belonging to the given <see cref="Faction"/> either by its 1-based
  /// position in <see cref="Faction.GetAllPowers"/> or by its C# class name.
  /// </summary>
  public static bool TryResolvePower(Faction faction, string key, [NotNullWhen(true)] out Power? power, out string error)
  {
    if (TryResolveByIndexOrKey(key, faction.GetAllPowers().ToList(), GetPowerKey, out power))
    {
      error = "";
      return true;
    }

    error = $"{faction.Name} has no power with key '{key}'. Try -power list {faction.Name} to list valid keys.";
    return false;
  }

  /// <summary>
  /// Returns the key used to target a <see cref="Power"/> in chat commands.
  /// </summary>
  public static string GetPowerKey(Power power) => power.GetType().Name;

  /// <summary>
  /// Resolves a <see cref="Team"/> by name.
  /// </summary>
  public static bool TryResolveTeam(string name, [NotNullWhen(true)] out Team? team, out string error)
  {
    if (FactionManager.TryGetTeamByName(name, out team))
    {
      error = "";
      return true;
    }

    error = $"There is no team named {name}.";
    return false;
  }

  // Lets players target an item by its position in a "list" verb's output, not just by its name key.
  private static bool TryResolveByIndexOrKey<T>(string key, IReadOnlyList<T> items, Func<T, string> getKey, [NotNullWhen(true)] out T? result)
    where T : class
  {
    result = TryResolveIndex(key, items.Count, out var index)
      ? items[index - 1]
      : items.FirstOrDefault(item => string.Equals(getKey(item), key, StringComparison.OrdinalIgnoreCase));
    return result != null;
  }

  private static bool TryResolveIndex(string key, int count, out int index) =>
    int.TryParse(key, out index) && index >= 1 && index <= count;
}
