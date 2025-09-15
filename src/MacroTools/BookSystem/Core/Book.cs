using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Frames;
using WCSharp.Shared.Data;

namespace MacroTools.BookSystem.Core
{
  /// <summary>
  /// A collection of Pages that players can flip through to read information.
  /// </summary>
  public abstract class Book<TItem, TPage, TCard, TPageFactory, TCardFactory> : Frame, ISpecialMenu
    where TCard : Card<TItem>
    where TCardFactory : ICardFactory<TCard>, new()
    where TPage : Page<TItem, TCard, TCardFactory>
    where TPageFactory : IPageFactory<TPage>, new()
  {
    /// <summary>
    /// All Pages contained in the Book.
    /// </summary>
    protected IReadOnlyList<TPage> Pages { get; }

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
      Width = width;
      Height = height;
      Visible = false;
      
      Pages = CreatePages(maximumPageCount);

      ExitButton = new Button("ScriptDialogButton", this, 0)
      {
        Width = 0.03f,
        Height = 0.03f,
        Text = "×",
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
      
      var trigger = CreateTrigger();
      trigger.RegisterSharedKeyEvent(OSKEY_ESCAPE, BlzGetTriggerPlayerMetaKey(), false);
      TriggerAddAction(trigger, () =>
      {
        if (GetTriggerPlayer() != GetLocalPlayer())
          return;
        Exit(GetLocalPlayer());
      });
      
      RefreshNavigationButtonVisiblity();
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
        if (value >= Pages.Count || value < 0)
          return;
        
        Pages[_activePageIndex].Visible = false;
        _activePageIndex = value;
        Pages[_activePageIndex].Visible = true;
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
        foreach (var page in Pages)
        {
          page.Visible = false;
        }

        Pages.First().Visible = true;
        _activePageIndex = 0;
        RefreshNavigationButtonVisiblity();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to open {nameof(Book<TItem, TPage, TCard, TPageFactory, TCardFactory>)}: {ex}");
      }
    }

    /// <summary>
    /// Returns the earliest non-empty Page.
    /// </summary>
    /// <returns></returns>
    protected TPage GetFirstAvailablePage()
    {
      foreach (var page in Pages)
        if (page.HasUnoccupiedCards())
          return page;

      throw new InvalidOperationException($"{Title} has no available pages.");
    }

    /// <summary>
    ///    Makes the Previous button visible if there are any pages to navigate back to,
    ///    and makes the Next button visible if there are any pages to navigate forward to.
    /// </summary>
    protected void RefreshNavigationButtonVisiblity()
    {
      var pageCount = Pages.Count(x => x.HasOccupiedCards());
      MoveNextButton.Visible = pageCount > ActivePageIndex + 1;
      MovePreviousButton.Visible = ActivePageIndex > 0;
    }

    /// <summary>
    /// Populates all Pages in this book.
    /// </summary>
    protected abstract void PopulatePages();

    /// <summary>
    /// Clears all pages in this book, then rerenders them.
    /// </summary>
    protected void ReRender()
    {
      foreach (var page in Pages)
        page.Clear();
      
      PopulatePages();
    }
    
    private TPage[] CreatePages(int maximumPageCount)
    {
      var pages = new TPage[maximumPageCount];
      var pageFactory = new TPageFactory();
      for (var i = 0; i < maximumPageCount; i++)
      {
        pages[i] = pageFactory.Create(Width, Height, i + 1, this);
        pages[i].Visible = i == 0;
      }

      return pages;
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
  }
}