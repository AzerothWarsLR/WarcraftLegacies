namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// The cumulative experience required for a hero to be at a given level. Used to set preplaced heroes (e.g.
/// from Hard mode) to a specific level directly, rather than the level 1 they'd otherwise start at.
/// </summary>
public static class HeroLevelExperience
{
  private static readonly int[] _experienceByLevel =
  {
    0, 400, 1000, 1800, 2800, 4000, 5400, 7000, 8800, 10800,
    13000, 15400, 18000, 20800, 23800, 27000, 30400, 34000, 37800, 41800
  };

  /// <summary>
  /// The total experience needed for a hero to be at <paramref name="level"/> (1-20).
  /// </summary>
  public static int ForLevel(int level) => _experienceByLevel[level - 1];
}
