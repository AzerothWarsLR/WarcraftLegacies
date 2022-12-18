using System;

namespace MacroTools
{
  /// <summary>
  /// Responsible for logging warnings.
  /// </summary>
  public static class WarningLogger
  {
    /// <summary>
    /// Logs a warning visible to all players.
    /// </summary>
    public static void Log(string warning) => Console.WriteLine($"|cff960000DEBUG WARNING: |r{warning}");
  }
}