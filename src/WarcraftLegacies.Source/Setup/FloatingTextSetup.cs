namespace WarcraftLegacies.Source.Setup;

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
    timer timer = timer.Create();
    timer.Start(delay, false, () =>
    {
      var eastToWest = texttag.Create();
      eastToWest.SetText("To the west of Kalimdor", fontSize);
      eastToWest.SetPosition(Regions.East_of_Azeroth.Center.X, Regions.East_of_Azeroth.Center.Y, 0);
      eastToWest.SetColor(255, 255, 255, 0);

      var westToEast = texttag.Create();
      westToEast.SetText("To the east of Azeroth", fontSize);
      westToEast.SetPosition(Regions.West_of_Kalimdor.Center.X, Regions.West_of_Kalimdor.Center.Y, 0);
      westToEast.SetColor(255, 255, 255, 0);

      var legionNorth = texttag.Create();
      legionNorth.SetText("To Northrend", fontSize);
      legionNorth.SetPosition(22939, -29345, 0);
      legionNorth.SetColor(255, 255, 255, 0);

      var legionAlterac = texttag.Create();
      legionAlterac.SetText("To Alterac", fontSize);
      legionAlterac.SetPosition(23536, -29975, 0);
      legionAlterac.SetColor(255, 255, 255, 0);

      @event.ExpiredTimer.Dispose();
    });
  }
}
