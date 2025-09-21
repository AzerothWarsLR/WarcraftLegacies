namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Responsible for managing basic game settings.
/// </summary>
public static class MapFlagSetup
{
  /// <summary>
  /// Forces observers to be enabled.
  /// </summary>
  public static void Setup()
  {
    SetMapFlag(mapflag.Observers, true);
    SetMapFlag(mapflag.ObserversOnDeath, true);
    SetMapFlag(mapflag.LockResourceTrading, true);
    SetMapFlag(mapflag.LockAllianceChanges, true);
  }
}
