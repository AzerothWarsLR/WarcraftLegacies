using WarcraftLegacies.Source.GameLogic.ThandolSpan;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Initializes game state as it relates to destructables.
/// </summary>
public static class DestructibleSetup
{
  public static void Setup()
  {
    ThandolSpanBridge.Setup();
  }
}
