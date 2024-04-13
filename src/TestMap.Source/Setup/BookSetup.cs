using MacroTools.BookSystem;
using MacroTools.BookSystem.ArtifactSystem;
using MacroTools.BookSystem.Core;
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
        SpecialMenuManager.Register(PowerBook.Create(player), player);
      //BookManager.Register(new ArtifactBook());
    }
  }
}