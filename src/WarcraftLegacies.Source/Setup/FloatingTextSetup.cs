namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Responsible for setting up all floating text on the map.
  /// </summary>
  public static class FloatingTextSetup
  {
    /// <summary>
    /// After a delay, creates floating text indicating what the water waygates at the west and east side of the map do.
    /// </summary>
    /// <param name="delay">How long to wait before spawning the text. Must be greater than 0 or the text won't spawn.</param>
    /// <param name="fontSize">How large the floating text should be.</param>
    public static void Setup(float delay, int fontSize)
    {
      var timer = CreateTimer();
      TimerStart(timer, delay, false, () =>
      {
        var eastToWest = CreateTextTag();
        SetTextTagText(eastToWest, "To the west of Kalimdor", fontSize);
        SetTextTagPos(eastToWest, Regions.East_of_Azeroth.Center.X, Regions.East_of_Azeroth.Center.Y, 0);
        SetTextTagColor(eastToWest, 255, 255, 255, 0);

        var westToEast = CreateTextTag();
        SetTextTagText(westToEast, "To the east of Azeroth", fontSize);
        SetTextTagPos(westToEast, Regions.West_of_Kalimdor.Center.X, Regions.West_of_Kalimdor.Center.Y, 0);
        SetTextTagColor(westToEast, 255, 255, 255, 0);

        var legionNorth = CreateTextTag();
        SetTextTagText(legionNorth, "To Northrend", fontSize);
        SetTextTagPos(legionNorth, 22939, -29345, 0);
        SetTextTagColor(legionNorth, 255, 255, 255, 0);

        var legionAlterac = CreateTextTag();
        SetTextTagText(legionAlterac, "To Alterac", fontSize);
        SetTextTagPos(legionAlterac, 23536, -29975, 0);
        SetTextTagColor(legionAlterac, 255, 255, 255, 0);

        DestroyTimer(GetExpiredTimer());
      });
    }
  }
}