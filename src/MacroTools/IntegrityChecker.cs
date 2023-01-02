using MacroTools.ControlPointSystem;
using static War3Api.Common;

namespace MacroTools
{
  /// <summary>
  /// Performs basic checks during runtime to ensure that the map is configured correctly.
  /// </summary>
  public static class IntegrityChecker
  {
    /// <summary>
    /// Runs the <see cref="IntegrityChecker"/>.
    /// </summary>
    public static void Setup()
    {
      NoNeutralPassiveVulnerableControlPoints();
    }

    private static void NoNeutralPassiveVulnerableControlPoints()
    {
      foreach (var controlPoint in ControlPointManager.Instance.GetAllControlPoints())
        if (controlPoint.Owner == Player(PLAYER_NEUTRAL_PASSIVE) && !BlzIsUnitInvulnerable(controlPoint.Unit))
          Logger.LogWarning($"{controlPoint.Name} is owned by Neutral Passive and is not invulnerable.");
    }
  }
}