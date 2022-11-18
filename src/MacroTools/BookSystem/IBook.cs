using MacroTools.Frames;
using static War3Api.Common;

namespace MacroTools.BookSystem
{
  public interface IBook
  {
    /// <summary>
    /// When set, the Book's Launcher button is moved directly below the provided parent with the same width and height.
    /// Useful for mimicking existing Blizzard buttons like the Quest or Allies menu.
    /// </summary>
    public framehandle LauncherParent { get; }
    
    /// <summary>
    /// Determines whether or not the book is visible.
    /// </summary>
    public bool Visible { get; set; }
    
    /// <summary>
    /// Fired when the exit button is clicked.
    /// </summary>
    public OnClickAction OnClickExitButton { set; }
    
    /// <summary>
    ///    The name of the Book's launcher Button.
    /// </summary>
    public string Title { get; init; }
  }
}