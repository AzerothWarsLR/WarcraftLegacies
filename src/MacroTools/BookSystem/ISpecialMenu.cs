using MacroTools.Frames;
using static War3Api.Common;

namespace MacroTools.BookSystem
{
  public interface ISpecialMenu
  {
    /// <summary>
    /// When set, the menu's Launcher button is moved directly below the provided parent with the same width and height.
    /// Useful for mimicking existing Blizzard buttons like the Quest or Allies menu.
    /// </summary>
    public framehandle LauncherParent { get; }

    /// <summary>
    /// The name of the Book's launcher Button.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// A button for launching of the book
    /// </summary>
    public Button LauncherButton { get; set; }

    /// <summary>
    ///  Opens the book
    /// </summary>
    /// <param name="triggerPlayer">the player that wants to open the book</param>
    public void Open(player triggerPlayer);
  }
}