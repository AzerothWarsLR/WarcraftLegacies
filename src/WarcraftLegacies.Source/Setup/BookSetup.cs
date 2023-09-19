using MacroTools.BookSystem;
using MacroTools.BookSystem.ArtifactSystem;
using MacroTools.BookSystem.Powers;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Responsible for setting up all <see cref="IBook"/>s.
  /// </summary>
  public static class BookSetup
  {
    /// <summary>
    /// Sets up all <see cref="IBook"/>s.
    /// </summary>
    public static void Setup()
    {
      foreach (var player in Util.EnumeratePlayers()) 
        BookManager.Register(new PowerBook(player), player);
      BookManager.Register(new ArtifactBook());
    }
  }
}