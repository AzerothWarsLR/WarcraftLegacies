using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames.Books
{
  public abstract class Book<T> : Frame where T : Page, new()
  {
    private readonly Button _launcher;
    private readonly Button _nextButton;

    protected readonly List<T> Pages = new();
    private readonly Button _previousButton;

    private int _activePageIndex;

    protected Book(float width, float height, float bottomButtonXOffset, float bottomButtonYOffset) : base(
      "ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0),
      0, 0)
    {
      Width = width;
      Height = height;
      Visible = false;

      SetAbsPoint(FRAMEPOINT_CENTER, 0.4f, 0.38f);

      //Launcher button
      _launcher = new Button("ScriptDialogButton", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0))
      {
        Width = 0.2f,
        Height = 0.025f,
        Text = "Artifacts",
        OnClick = OpenFirstPage
      };
      _launcher.SetAbsPoint(FRAMEPOINT_CENTER, 0, 0.56f);

      //Exit button
      var exitButton = new Button("ScriptDialogButton", this, 0, 0)
      {
        Width = 0.09f,
        Height = 0.037f,
        Text = "Exit",
        OnClick = OnClickExitButton
      };
      exitButton.SetPoint(FRAMEPOINT_BOTTOM, this, FRAMEPOINT_BOTTOM, 0, bottomButtonYOffset);
      AddFrame(exitButton);

      //Next button
      _nextButton = new Button("ScriptDialogButton", this, 0, 0)
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

      //Previous button
      _previousButton = new Button("ScriptDialogButton", this, 0, 0)
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
    
    private void OnClickNextButton(player whichPlayer)
    {
      try
      {
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
        ActivePageIndex--;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void OnClickExitButton(player triggerPlayer)
    {
      Visible = false;
      _launcher.Visible = true;
    }

    private void OpenFirstPage(player whichPlayer)
    {
      if (whichPlayer == GetLocalPlayer())
      {
        Visible = true;
        _launcher.Visible = false;
      }
    }

    /// <summary>
    /// Adds a new Page to the end of the Book.
    /// </summary>
    protected T AddPage()
    {
      var newPage = new T
      {
        Width = Width,
        Height = Height,
        Parent = this,
        PageNumber = Pages.Count + 1
      };
      Pages.Add(newPage);
      RefreshNavigationButtonVisiblity();
      return newPage;
    }
    
    /// <summary>
    ///   Makes the Previous button visible if there are any pages to navigate back to,
    ///   and makes the Next button visible if there are any pages to navigate forward to.
    /// </summary>
    private void RefreshNavigationButtonVisiblity()
    {
      var pageCount = Pages.Count;

      _nextButton.Visible = pageCount > ActivePageIndex + 1;
      _previousButton.Visible = ActivePageIndex > 0;
    }
  }
}