using MacroTools.UserInterface.Books.Artifacts;
using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Books.Paths;
using MacroTools.UserInterface.Books.Powers;
using MacroTools.UserInterface.Books.WorldEvents;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Setup;

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
    foreach (var player in Util.EnumeratePlayers())
    {
      SpecialMenuManager.Register(PowerBook.Create(player), player);

      var pathBook = PathBook.Create(player);
      SpecialMenuManager.Register(pathBook, player);
      pathBook.RefreshLauncher();
    }

    SpecialMenuManager.Register(new ArtifactBook());

    var eventBook = new EventBook();
    SpecialMenuManager.Register(eventBook);
    eventBook.RefreshLauncher();
  }
}
