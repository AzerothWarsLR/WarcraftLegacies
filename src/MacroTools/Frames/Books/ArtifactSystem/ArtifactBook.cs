using System;
using System.Collections.Generic;
using System.Linq;
using WarcraftLegacies.MacroTools.ArtifactSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Frames.Books.ArtifactSystem
{
  /// <summary>
  ///   Displays all Artifacts in the game.
  /// </summary>
  public sealed class ArtifactBook : Book<ArtifactPage>
  {
    private const float BOTTOM_BUTTON_Y_OFFSET = 0.015f;
    private const float BOTTOM_BUTTON_X_OFFSET = 0.02f;
    private const float BOOK_WIDTH = 0.7f;
    private const float BOOK_HEIGHT = 0.37f;

    private static ArtifactBook? _instance;
    private static bool _initialized;
    private readonly Dictionary<Artifact, ArtifactPage> _pagesByArtifact = new();

    private ArtifactBook(float width, float height, float bottomButtonXOffset, float bottomButtonYOffset) : base(width,
      height, bottomButtonXOffset, bottomButtonYOffset)
    {
      ArtifactManager.ArtifactRegistered += ArtifactCreated;
      var firstPage = AddPage();
      firstPage.Visible = true;
      AddAllArtifacts();
      BookTitle = "Artifacts";
      LauncherParent = BlzGetFrameByName("UpperButtonBarQuestsButton", 0);
      Position = new Point(0.4f, 0.38f);
    }

    private void AddArtifact(Artifact artifact)
    {
      var lastPage = Pages.Last();
      if (lastPage.CardCount >= lastPage.CardLimit)
      {
        AddPage();
        lastPage = Pages.Last();
      }

      lastPage.AddArtifact(artifact);
      _pagesByArtifact.Add(artifact, lastPage);
      artifact.Disposed += OnArtifactDisposed;
    }

    private void OnArtifactDisposed(object? sender, Artifact artifact)
    {
      _pagesByArtifact[artifact].RemoveArtifact(artifact);
      _pagesByArtifact.Remove(artifact);
    }

    private void AddAllArtifacts()
    {
      foreach (var artifact in ArtifactManager.GetAllArtifacts())
        AddArtifact(artifact);
    }

    private static void LoadToc(string tocFilePath)
    {
      if (!BlzLoadTOCFile(tocFilePath)) throw new Exception($"Failed to load TOC {tocFilePath}");
    }

    private void ArtifactCreated(object? sender, Artifact artifact)
    {
      AddArtifact(artifact);
    }

    public static void Initialize()
    {
      if (!_initialized)
      {
        LoadToc(@"ArtifactSystem.toc");
        LoadToc(@"ui\framedef\framedef.toc");
        _instance = new ArtifactBook(BOOK_WIDTH, BOOK_HEIGHT, BOTTOM_BUTTON_X_OFFSET, BOTTOM_BUTTON_Y_OFFSET);
        _initialized = true;
      }
    }

    protected override void DisposeEvents()
    {
      ArtifactManager.ArtifactRegistered -= ArtifactCreated;
      foreach (var artifact in _pagesByArtifact.Keys)
      {
        artifact.Disposed -= OnArtifactDisposed;
      }
    }
  }
}