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
    /// The name of the Book's launcher Button.
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// A button for exiting of the book
    /// </summary>
    public Button ExitButton { get; init; }

    /// <summary>
    /// A button for launching of the book
    /// </summary>
    public Button LauncherButton { get; set; }

    /// <summary>
    /// A button for moving to the next page of the book
    /// </summary>
    public Button MoveNextButton { get; init; }

    /// <summary>
    /// A button for moving to the previous page of the book
    /// </summary>
    public Button MovePreviousButton { get; init; }

    /// <summary>
    ///  Opens the book
    /// </summary>
    /// <param name="triggerPlayer">the player that wants to open the book</param>
    public void Open(player triggerPlayer);

    /// <summary>
    ///  Exits the book
    /// </summary>
    /// <param name="triggerPlayer">the player that wants to close the book</param>
    public void Exit(player triggerPlayer);

    /// <summary>
    ///  Moves to the next page of the book
    /// </summary>
    /// <param name="triggerPlayer">the player that wants move to the next page of the book</param>
    public void MoveNext(player triggerPlayer);

    /// <summary>
    ///  Moves to the previous page of the book
    /// </summary>
    /// <param name="triggerPlayer">the player that wants to move the previous page of the book</param>
    public void MovePrevious(player triggerPlayer);
  }
}