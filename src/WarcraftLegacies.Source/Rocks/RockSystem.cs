using System.Collections.Generic;

namespace WarcraftLegacies.Source.Rocks
{
  /// <summary>
  /// Manages <see cref="RockGroup"/>s by destroying them based on timer or manual removal.
  /// </summary>
  public static class RockSystem
  {
    private static readonly List<RockGroup> _rockGroups = new();

    /// <summary>
    /// Registers a <see cref="RockGroup"/> to the system and optionally
    /// destroys it after its expiry time.
    /// </summary>
    public static void Register(RockGroup rockGroup)
    {
      _rockGroups.Add(rockGroup);

      if (rockGroup.Expiry > 0) // Only use a timer if an expiry is set
      {
        var timer = CreateTimer();
        TimerStart(timer, rockGroup.Expiry, false, () =>
        {
          rockGroup.Destroy();
          _rockGroups.Remove(rockGroup);
        });
      }
    }

    /// <summary>
    /// Manually removes a registered <see cref="RockGroup"/> and destroys it.
    /// </summary>
    public static void Remove(RockGroup rockGroup)
    {
      if (_rockGroups.Contains(rockGroup))
      {
        rockGroup.Destroy(); // Destroy all rocks in the group
        _rockGroups.Remove(rockGroup); // Remove it from the system
      }
    }
  }
}