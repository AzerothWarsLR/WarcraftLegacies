using System;
using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames
{
  /// <summary>
  ///   Displays all Artifacts in the game.
  /// </summary>
  public class ArtifactBook : Frame
  {
    private const float BottomButtonYOffset = 0.015f;
    private const float BottomButtonXOffset = 0.02f;
    private const float BookWidth = 0.7f;
    private const float BookHeight = 0.37f;
    
    // ReSharper disable once NotAccessedField.Local
    private static ArtifactBook? _instance;
    private static bool _initialized;
    private readonly List<ArtifactBookPage?> _pages = new();
    
    private readonly Button _launcher;
    private readonly Button _nextButton;
    private readonly Button _previousButton;

    private int _activePageIndex = 0;
    private int ActivePageIndex
    {
      get => _activePageIndex;
      set
      {
        var pageCount = _pages.Count;
        if (value >= pageCount)
        {
          throw new ArgumentOutOfRangeException(nameof(value), $"ActivePageIndex must be lower than page count {pageCount}.");
        }
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException(nameof(value), "ActivePageIndex cannot be negative.");
        }
        _pages[_activePageIndex].Visible = false;
        _activePageIndex = value;
        _pages[_activePageIndex].Visible = true;
        RefreshNavigationButtonVisiblity();
      }
    }

    /// <summary>
    /// Makes the Previous button visible if there are any pages to navigate back to,
    /// and makes the Next button visible if there are any pages to navigate forward to.
    /// </summary>
    private void RefreshNavigationButtonVisiblity()
    {
      var pageCount = _pages.Count;
      
      _nextButton.Visible = pageCount > ActivePageIndex+1;
      _previousButton.Visible = ActivePageIndex > 0;
    }
    
    private ArtifactBook() : base("ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0),
      0, 0)
    { 
      Width = BookWidth;
      Height = BookHeight;
      Visible = false;
      SetAbsPoint(FRAMEPOINT_CENTER, 0.4f, 0.38f);
      FactionSystem.ArtifactAdded += OnArtifactCreated;
      
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
      exitButton.SetPoint(FRAMEPOINT_BOTTOM, this, FRAMEPOINT_BOTTOM, 0, BottomButtonYOffset);
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
      _nextButton.SetPoint(FRAMEPOINT_BOTTOMRIGHT, this, FRAMEPOINT_BOTTOMRIGHT, -BottomButtonXOffset,
        BottomButtonYOffset);
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
      _previousButton.SetPoint(FRAMEPOINT_BOTTOMLEFT, this, FRAMEPOINT_BOTTOMLEFT, BottomButtonXOffset,
        BottomButtonYOffset);
      AddFrame(_previousButton);
      AddAllArtifacts();
    }

    private ArtifactBookPage? LastPage => _pages.Count == 0 ? null : _pages.Last();

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
    
    private void AddArtifact(Artifact artifact)
    {
      if (LastPage == null || LastPage!.CardCount >= LastPage.CardLimit)
      {
        AddPage();
      }
      if (_pages.Count == 1)
      {
        LastPage!.Visible = true;
      }
      LastPage?.AddArtifact(artifact);
    }

    private void AddPage()
    {
      var newPage = new ArtifactBookPage(_pages.Count, this);
      _pages.Add(newPage);
      RefreshNavigationButtonVisiblity();
    }

    private void AddAllArtifacts()
    {
      foreach (var artifact in FactionSystem.GetAllArtifacts()) AddArtifact(artifact);
    }

    private void OpenFirstPage(player whichPlayer)
    {
      if (whichPlayer == GetLocalPlayer())
      {
        Visible = true;
        _launcher.Visible = false;
      }
    }

    private static void LoadToc(string tocFilePath)
    {
      if (!BlzLoadTOCFile(tocFilePath)) throw new Exception($"Failed to load TOC {tocFilePath}");
    }

    private void OnArtifactCreated(object? sender, ArtifactEventArgs args)
    {
      AddArtifact(args.Artifact);
    }

    public static void Initialize()
    {
      if (!_initialized)
      {
        LoadToc(@"war3mapImported\ArtifactSystem.toc");
        LoadToc(@"ui\framedef\framedef.toc");
        _instance = new ArtifactBook();
        _initialized = true;
      }
    }

    public new void Dispose()
    {
      BlzDestroyFrame(_handle);
      Disposed?.Invoke(this, new FrameEventArgs(this));
      FactionSystem.ArtifactAdded -= OnArtifactCreated;
    }
  }
}