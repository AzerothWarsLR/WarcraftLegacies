using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Setup;

public static class SulfuronSpireSetup
{
  /// <summary>
  /// Hides the preplaced Sulfuron Spire in Ashenvale Forest until a later event reveals it.
  /// </summary>
  public static void Setup()
  {
    AllPreplacedWidgets.Units.Get(UNIT_SWSS_SULFURON_SPIRE_SCOURGE_T3).IsVisible = false;
  }
}
