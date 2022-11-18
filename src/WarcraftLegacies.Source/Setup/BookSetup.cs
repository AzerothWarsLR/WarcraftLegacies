using MacroTools.Frames.Books;
using MacroTools.Frames.Books.ArtifactSystem;
using MacroTools.Frames.Books.Powers;

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
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) 
        BookManager.Register(new PowerBook(player), player);
      BookManager.Register(new ArtifactBook());
    }
  }
}