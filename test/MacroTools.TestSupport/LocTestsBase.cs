using MacroTools.Localization;

namespace MacroTools.TestSupport;

[Collection(nameof(LocCollection))]
public abstract class LocTestsBase : IDisposable
{
  protected LocTestsBase()
  {
    Loc.ResetTranslations();
  }

  public void Dispose()
  {
    Loc.ResetTranslations();
  }
}
