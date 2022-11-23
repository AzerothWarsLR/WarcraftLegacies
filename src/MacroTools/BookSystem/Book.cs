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

    private readonly TextFrame _title;
    private int _activePageIndex;

    /// <summary>
    /// Creates a new Book.>.
    /// </summary>
    /// <param name="width">How wide the Book should be.</param>
    /// <param name="height">How tall the Book should be.</param>
    /// <param name="bottomButtonXOffset">How far the Previous and Next buttons should be from the left side of the Book.</param>
    /// <param name="bottomButtonYOffset">How far the Previous and Next buttons should be from the bottom side of the Book.</param>
    protected Book(float width, float height, float bottomButtonXOffset, float bottomButtonYOffset) : base(
      "ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
    {
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
    public Button ExitButton { get; init; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public Button LauncherButton { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public Button MoveNextButton { get; init; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public Button MovePreviousButton { get; init; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string Title
    {
      init => _title.Text = value;
      get => _title.Text;
    }

    /// <inheritdoc />
    public framehandle LauncherParent { get; protected init; }

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
    /// <inheritdoc/>
    /// </summary>
    /// <param name="triggerPlayer"></param>
    public void Exit(player triggerPlayer)
    {
      if (triggerPlayer != GetLocalPlayer() || !Visible || LauncherButton.Visible)
        return;
      Visible = false;
      LauncherButton.Visible = true;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="triggerPlayer"></param>
    public void MoveNext(player triggerPlayer)
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
    /// <inheritdoc/>
    /// </summary>
    /// <param name="triggerPlayer"></param>
    public void MovePrevious(player triggerPlayer)
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
    /// <inheritdoc/>
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
      MoveNextButton.Visible = pageCount > ActivePageIndex + 1;
      MovePreviousButton.Visible = ActivePageIndex > 0;
    }
  }
}