using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MacroTools.Utils;

namespace MacroTools.Setup;

/// <summary>
/// Manages the execution of ordered setup methods.
/// </summary>
public static class SetupOrchestrator
{
  /// <summary>
  /// Setup systems with no dependencies.
  /// </summary>
  public static void RunPreSetup() => RunPhase("PreSetup");

  /// <summary>
  /// Setup systems that depend on systems setup via <see cref="RunPreSetup"/>.
  /// </summary>
  public static void RunMainSetup() => RunPhase("MainSetup");

  /// <summary>
  /// Setup systems that are dependent on systems setup via <see cref="RunPostSetup"/>.
  /// </summary>
  public static void RunPostSetup() => RunPhase("PostSetup");

  private static void RunPhase(string methodName)
  {
    try
    {
      var methods = DiscoverMethods(methodName);

      foreach (var method in methods)
      {
        method.Invoke(null, null);
      }
    }
    catch (Exception ex)
    {
      Logger.LogError($"An error occurred while running game setup phase {methodName}.");
      Logger.LogError(ex.ToString());
    }
  }

  private static List<MethodInfo> DiscoverMethods(string methodName)
  {
    var methods = Assembly.GetExecutingAssembly().GetExportedTypes()
      .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
      .Where(m => m.Name == methodName)
      .ToList();

    methods.Sort((a, b) =>
      string.Compare(
        $"{a.DeclaringType?.FullName}.{a.Name}",
        $"{b.DeclaringType?.FullName}.{b.Name}",
        StringComparison.Ordinal));

    return methods;
  }
}
