namespace WarcraftLegacies.Source.GameLogic;

/// <summary>Tells day from night using the in-game time of day.</summary>
public static class DayNight
{
  private const float Dawn = 6;
  private const float Dusk = 18;

  /// <summary>Whether it is currently night.</summary>
  public static bool IsNight()
  {
    var timeOfDay = GetFloatGameState(GAME_STATE_TIME_OF_DAY);
    return timeOfDay >= Dusk || timeOfDay < Dawn;
  }
}
