using MacroTools.BookSystem;
using MacroTools.BookSystem.ArtifactSystem;
using MacroTools.BookSystem.Powers;

namespace TestMap.Source.Setup
{
  /// <summary>
  /// Responsible for setting up all <see cref="ISpecialMenu"/>s.
  /// </summary>
  public static class BookSetup
  {
    /// <summary>
    /// Sets up all <see cref="ISpecialMenu"/>s.
    /// </summary>
    public static void Setup()
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) 
        SpecialMenuManager.Register(new PowerBook(player), player);
      SpecialMenuManager.Register(new ArtifactBook());
    }
  }
}