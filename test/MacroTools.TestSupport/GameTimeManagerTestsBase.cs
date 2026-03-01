using MacroTools.GameTime;

namespace MacroTools.TestSupport;

[Collection(nameof(GameTimeManagerCollection))]
public abstract class GameTimeManagerTestsBase : IDisposable
{
  protected GameTimeManagerTestsBase()
  {
    GameTimeManager.Reset();
  }

  public void Dispose()
  {
    GameTimeManager.Reset();
  }
}

