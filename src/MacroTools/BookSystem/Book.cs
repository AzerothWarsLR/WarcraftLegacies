using System;
using System.Collections.Generic;
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
  public abstract class Book<T> : Frame, IBook where T : Page, new()
  {
    /// <summary>
    /// All <see cref="Page"/>s contained in the Book.
    /// </summary>
    protected readonly List<T> Pages = new();

    private readonly Button _nextButton;
    private readonly Button _previousButton;
    private readonly Button _exitButton;
    private readonly Button _launcherButton;
    private readonly TextFrame _title;
    private int _activePageIndex;

    /// <summary>
    /// Creates a new Book.>.
    /// </summary>
    /// <param name="width">How wide the Book should be.</param>
    /// <param name="height">How tall the Book should be.</param>
    /// <param name="bottomButtonXOffset">How far the Previous and Next buttons should be from the left side of the Book.</param>
    /// <param name="bottomButtonYOffset">How far the Previous and Next buttons should be from the bottom side of the Book.</param>
    /// <param name="title"> The name of the Book's launcher Button.</param>
    /// <param name="position">the book's center.</param>
    /// <param name="launcherParent">framehandle used by the launcher button to position itself</param>
    /// <param name="launcherButtonVisible"></param>
    protected Book(float width, float height, float bottomButtonXOffset, float bottomButtonYOffset, string title, Point position, framehandle launcherParent, bool launcherButtonVisible) : base(
      "ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
    {
      Width = width;
      Height = height;
     
      Position = position;
      LauncherParent = launcherParent;
      Visible = false;
      _launcherButton = new Button("ScriptDialogButton", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
      {
        Width = launcherParent.GetWidth(),
        Height = launcherParent.GetHeight(),
        Text = title,
        OnClick = OnClickLauncherButton,
        Visible = launcherButtonVisible
      };
      _launcherButton.SetPoint(FRAMEPOINT_TOP, LauncherParent, FRAMEPOINT_BOTTOM, 0, 0);

    
      _exitButton = new Button("ScriptDialogButton", this, 0)
      {
        Width = 0.03f,
        Height = 0.03f,
        Text = "x",
        OnClick = OnClickExitButton     
      };
      _exitButton.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOPRIGHT, -0.015f, -0.015f);
     
      AddFrame(_exitButton);

      _nextButton = new Button("ScriptDialogButton", this, 0)
      {
        Width = 0.09f,
        Height = 0.037f,
        Text = "Next",
        OnClick = OnClickNextButton,
        Visible = true
      };
      _nextButton.SetPoint(FRAMEPOINT_BOTTOMRIGHT, this, FRAMEPOINT_BOTTOMRIGHT, -bottomButtonXOffset,
        bottomButtonYOffset);
      AddFrame(_nextButton);

      _previousButton = new Button("ScriptDialogButton", this, 0)
      {
        Width = 0.09f,
        Height = 0.037f,
        Text = "Previous",
        OnClick = OnClickPreviousButton,
        Visible = true
      };
      _previousButton.SetPoint(FRAMEPOINT_BOTTOMLEFT, this, FRAMEPOINT_BOTTOMLEFT, bottomButtonXOffset,
        bottomButtonYOffset);
      AddFrame(_previousButton);

      _title = new TextFrame("BookMenuTitle", this, 0)
      {
        Text = title
      };
      _title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOP, 0, -0.025f);
      AddFrame(_title);
    }

    /// <inheritdoc />
    public framehandle LauncherParent { get; private init; }

    /// <summary>
    /// Determines the book's center.
    /// </summary>
    private Point Position
    {
      init => SetAbsPoint(FRAMEPOINT_CENTER, value.X, value.Y);
    }

    private int ActivePageIndex
    {
      get => _activePageIndex;
      set
      {
        var pageCount = Pages.Count;
        if (value >= pageCount)
          throw new ArgumentOutOfRangeException(nameof(value),
            $"ActivePageIndex must be lower than page count {pageCount}.");
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "ActivePageIndex cannot be negative.");
        Pages[_activePageIndex].Visible = false;
        _activePageIndex = value;
        Pages[_activePageIndex].Visible = true;
        RefreshNavigationButtonVisiblity();
      }
    }

    private void OnClickExitButton(player whichPlayer)
    {
      try
      {
        if (whichPlayer != GetLocalPlayer())
          return;
        Visible = false;
        _launcherButton.Visible = true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void OnClickNextButton(player whichPlayer)
    {
      try
      {
        if (GetLocalPlayer() == whichPlayer)
          ActivePageIndex++;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void OnClickPreviousButton(player whichPlayer)
    {
      try
      {
        if (GetLocalPlayer() == whichPlayer)
          ActivePageIndex--;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void OnClickLauncherButton(player whichPlayer)
    {
      try
      {
        if (whichPlayer != GetLocalPlayer())
          return;
        Visible = true;
         _launcherButton.Visible = false;
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
        Console.WriteLine($"Failed to open {nameof(Book<T>)}: {ex}");
      }
    }

    /// <summary>
    ///    Adds a new Page to the end of the Book.
    /// </summary>
    protected T AddPage()
    {
      var newPage = new T
      {
        Width = Width,
        Height = Height,
        PageNumber = Pages.Count + 1,
        Parent = this
      };
      newPage.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0);

      Pages.Add(newPage);
      RefreshNavigationButtonVisiblity();
      return newPage;
    }

    /// <summary>
    ///    Makes the Previous button visible if there are any pages to navigate back to,
    ///    and makes the Next button visible if there are any pages to navigate forward to.
    /// </summary>
    private void RefreshNavigationButtonVisiblity()
    {
      var pageCount = Pages.Count;

      _nextButton.Visible = pageCount > ActivePageIndex + 1;
      _previousButton.Visible = ActivePageIndex > 0;
    }
  }
}