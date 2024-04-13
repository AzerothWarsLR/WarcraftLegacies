using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Frames;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.BookSystem
{
  /// <summary>
  /// A collection of <see cref="Page"/>s that players can flip through to read information.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class Book<T> : Frame, ISpecialMenu where T : Page, new()
  {
    /// <summary>
    /// How many pages the Book can have.
    /// </summary>
    public int MaximumPageCount { get; }

    /// <summary>
    /// All <see cref="Page"/>s contained in the Book.
    /// </summary>
    private readonly T[] _pages;

    private readonly TextFrame _title;
    private int _activePageIndex;

    /// <summary>
    /// Creates a new Book.>.
    /// </summary>
    /// <param name="width">How wide the Book should be.</param>
    /// <param name="height">How tall the Book should be.</param>
    /// <param name="bottomButtonXOffset">How far the Previous and Next buttons should be from the left side of the Book.</param>
    /// <param name="bottomButtonYOffset">How far the Previous and Next buttons should be from the bottom side of the Book.</param>
    /// <param name="maximumPageCount">How many pages the Book can have. Can't be changed once set.</param>
    protected Book(float width, float height, float bottomButtonXOffset, float bottomButtonYOffset, int maximumPageCount) : base(
      "ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
    {
      MaximumPageCount = maximumPageCount;
      _pages = CreatePages(maximumPageCount);

      Width = width;
      Height = height;
      Visible = false;

      ExitButton = new Button("ScriptDialogButton", this, 0)
      {
        Width = 0.03f,
        Height = 0.03f,
        Text = "x",
        OnClick = Exit
      };
      ExitButton.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOPRIGHT, -0.015f, -0.015f);
      AddFrame(ExitButton);

      MoveNextButton = new Button("ScriptDialogButton", this, 0)
      {
        Width = 0.09f,
        Height = 0.037f,
        Text = "Next",
        OnClick = MoveNext,
        Visible = true
      };
      MoveNextButton.SetPoint(FRAMEPOINT_BOTTOMRIGHT, this, FRAMEPOINT_BOTTOMRIGHT, -bottomButtonXOffset,
        bottomButtonYOffset);
      AddFrame(MoveNextButton);

      MovePreviousButton = new Button("ScriptDialogButton", this, 0)
      {
        Width = 0.09f,
        Height = 0.037f,
        Text = "Previous",
        OnClick = MovePrevious,
        Visible = true
      };
      MovePreviousButton.SetPoint(FRAMEPOINT_BOTTOMLEFT, this, FRAMEPOINT_BOTTOMLEFT, bottomButtonXOffset,
        bottomButtonYOffset);
      AddFrame(MovePreviousButton);

      _title = new TextFrame("ArtifactMenuTitle", this, 0)
      {
        Text = "Artifacts"
      };
      _title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOP, 0, -0.025f);
      AddFrame(_title);
      
      CreateTrigger()
        .RegisterSharedKeyEvent(OSKEY_ESCAPE, BlzGetTriggerPlayerMetaKey(), false)
        .AddAction(() =>
      {
        if (GetTriggerPlayer() != GetLocalPlayer())
          return;
        Exit(GetLocalPlayer());
      });
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public Button LauncherButton { get; set; }
    
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string Title
    {
      protected init => _title.Text = value;
      get => _title.Text;
    }

    /// <inheritdoc />
    public framehandle LauncherParent { get; protected init; }
    
    /// <summary>
    /// Used to close the book.
    /// </summary>
    private Button ExitButton { get; }

    /// <summary>
    /// Used to navigate to the next page.
    /// </summary>
    private Button MoveNextButton { get; }

    /// <summary>
    /// Used to navigate to the previous page.
    /// </summary>
    private Button MovePreviousButton { get; }

    /// <summary>
    /// Determines the book's center.
    /// </summary>
    protected Point Position
    {
      init => SetAbsPoint(FRAMEPOINT_CENTER, value.X, value.Y);
    }

    private int ActivePageIndex
    {
      get => _activePageIndex;
      set
      {
        if (value >= _pages.Length || value < 0)
          return;
        _pages[_activePageIndex].Visible = false;
        _activePageIndex = value;
        _pages[_activePageIndex].Visible = true;
        RefreshNavigationButtonVisiblity();
      }
    }

    /// <summary>
    /// Open the book.
    /// </summary>
    /// <param name="triggerPlayer"></param>
    public void Open(player triggerPlayer)
    {
      try
      {
        if (triggerPlayer != GetLocalPlayer())
          return;
        Visible = true;
        LauncherButton.Visible = false;
        foreach (var page in _pages)
        {
          page.Visible = false;
        }

        _pages.First().Visible = true;
        _activePageIndex = 0;
        RefreshNavigationButtonVisiblity();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to open {nameof(Book<T>)}: {ex}");
      }
    }

    /// <summary>
    /// Returns the earliest non-empty <see cref="Page"/>.
    /// </summary>
    /// <returns></returns>
    protected T GetNextAvailablePage()
    {
      foreach (var page in _pages)
        if (page.HasRoom())
          return page;

      throw new InvalidOperationException($"{Title} has no available pages.");
    }
    
    private T[] CreatePages(int maximumPageCount)
    {
      var pages = new T[maximumPageCount];
      for (var i = 0; i < maximumPageCount; i++) 
        pages[i] = CreatePage(i + 1);

      pages.First().Visible = true;

      return pages;
    }
    
    /// <summary>
    ///    Adds a new Page to the end of the Book.
    /// </summary>
    private T CreatePage(int pageNumber)
    { 
      var newPage = new T
      {
        Width = Width,
        Height = Height,
        PageNumber = pageNumber,
        Parent = this,
        Visible = false
      };
      newPage.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0);
      
      RefreshNavigationButtonVisiblity();
      return newPage;
    }
    
    /// <summary>
    /// Close the book.
    /// </summary>
    /// <param name="triggerPlayer"></param>
    private void Exit(player triggerPlayer)
    {
      if (triggerPlayer != GetLocalPlayer() || !Visible || LauncherButton.Visible)
        return;
      Visible = false;
      LauncherButton.Visible = true;
    }

    /// <summary>
    /// Move to the next page.
    /// </summary>
    /// <param name="triggerPlayer"></param>
    private void MoveNext(player triggerPlayer)
    {
      try
      {
        if (GetLocalPlayer() == triggerPlayer)
          ActivePageIndex++;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    /// <summary>
    /// Move to the previous page.
    /// </summary>
    /// <param name="triggerPlayer"></param>
    private void MovePrevious(player triggerPlayer)
    {
      try
      {
        if (GetLocalPlayer() == triggerPlayer)
          ActivePageIndex--;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    /// <summary>
    ///    Makes the Previous button visible if there are any pages to navigate back to,
    ///    and makes the Next button visible if there are any pages to navigate forward to.
    /// </summary>
    private void RefreshNavigationButtonVisiblity()
    {
      var pageCount = _pages.Length;
      MoveNextButton.Visible = pageCount > ActivePageIndex + 1;
      MovePreviousButton.Visible = ActivePageIndex > 0;
    }
  }
}