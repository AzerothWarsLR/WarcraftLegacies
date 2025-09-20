using MacroTools.BookSystem.ArtifactSystem;
using MacroTools.BookSystem.Core;
using MacroTools.BookSystem.Powers;
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
    }

    SpecialMenuManager.Register(new ArtifactBook());
  }
}
