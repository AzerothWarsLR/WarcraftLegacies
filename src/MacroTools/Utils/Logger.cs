using System;

namespace MacroTools.Utils;

/// <summary>
/// Responsible for logging formatted warnings and errors.
/// </summary>
public static class Logger
{
  /// <summary>
  /// Logs a warning visible to all players.
  /// </summary>
  public static void LogWarning(string message) => Console.WriteLine($"|cff960000SYSTEM WARNING: |r{message}");

  /// <summary>
  /// Logs an error visible to all players.
  /// </summary>
  public static void LogError(string message) => Console.WriteLine($"|cff960000SYSTEM ERROR: |r{message}");
}
