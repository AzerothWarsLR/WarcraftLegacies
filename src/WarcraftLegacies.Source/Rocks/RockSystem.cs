using System.Collections.Generic;


namespace WarcraftLegacies.Source.Rocks
{
  /// <summary>
  /// Manages <see cref="RockGroup"/>s by making them invulnerable when registered, and destroying them when their expiry time passes.
  /// </summary>
  public static class RockSystem
  {
    private static List<RockGroup> _rockGroups = new();

    public static void Register(RockGroup rockGroup)
    {
      _rockGroups.Add(rockGroup);
      var timer = CreateTimer();

      TimerStart(timer, rockGroup.Expiry, false, () =>
      {
        rockGroup.Destroy();
        _rockGroups.Remove(rockGroup);
      });
    }
  }
}