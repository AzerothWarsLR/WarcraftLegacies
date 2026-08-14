namespace WarcraftLegacies.Source.GameLogic;

public static class HeroLevelExperience
{
  private static readonly int[] _experienceByLevel =
  {
    0, 400, 1000, 1800, 2800, 4000, 5400, 7000, 8800, 10800,
    13000, 15400, 18000, 20800, 23800, 27000, 30400, 34000, 37800, 41800
  };

  public static int ForLevel(int level) => _experienceByLevel[level - 1];
}
