using System.Collections.Generic;
using MacroTools.Factions;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Tracks whether Roleplay mode is active, and gives every <see cref="IHasRoleplayPaths"/> faction its paths when it is.
/// </summary>
public static class RoleplaySetting
{
  private static readonly HashSet<Faction> _factionsWithPaths = new();

  public static bool IsActive { get; private set; }

  public static void Apply()
  {
    if (IsActive)
    {
      return;
    }

    IsActive = true;
    foreach (var faction in FactionManager.GetAllFactions())
    {
      AddRoleplayPaths(faction);
    }

    FactionManager.FactionRegistered += AddRoleplayPaths;
  }

  private static void AddRoleplayPaths(Faction faction)
  {
    if (faction is IHasRoleplayPaths hasRoleplayPaths && _factionsWithPaths.Add(faction))
    {
      hasRoleplayPaths.AddRoleplayPaths();
    }
  }
}
