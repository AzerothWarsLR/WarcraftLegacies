namespace WarcraftLegacies.Source.GameLogic;

public static class HeroLevelExperience
{
  private static readonly int[] _experienceByLevel =
  {
    0, 400, 1000, 1800, 2800, 4000, 5400, 7000, 8800, 10800,
    13000, 15400, 18000, 20800, 23800, 27000, 30400, 34000, 37800, 41800
  };

  public static int ForLevel(int level) => _experienceByLevel[level - 1];

  /// <summary>Raises the hero by a number of levels, which can be partial, keeping its progress towards the next one.</summary>
  public static void GrantLevels(unit hero, float levels)
  {
    var level = hero.HeroLevel;
    var maxLevel = _experienceByLevel.Length;
    if (level >= maxLevel)
    {
      return;
    }

    var levelStart = ForLevel(level);
    var position = level + (float)(hero.Experience - levelStart) / (ForLevel(level + 1) - levelStart) + levels;
    var newLevel = (int)position;
    var newExperience = newLevel >= maxLevel
      ? ForLevel(maxLevel)
      : ForLevel(newLevel) + (int)((position - newLevel) * (ForLevel(newLevel + 1) - ForLevel(newLevel)));
    hero.SetExperience(newExperience, true);
  }
}
