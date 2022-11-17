using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.ArtifactSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Frames.Books.ArtifactSystem
{
  /// <summary>
  ///   Displays all Artifacts in the game.
  /// </summary>
  public sealed class ArtifactBook : Book<ArtifactPage>
  {
    private const float BottomButtonYOffset = 0.015f;
    private const float BottomButtonXOffset = 0.02f;
    private const float BookWidth = 0.65f;
    private const float BookHeight = 0.37f;

    private static ArtifactBook? _instance;
    private static bool _initialized;
    private readonly Dictionary<Artifact, ArtifactPage> _pagesByArtifact = new();

    private ArtifactBook(float width, float height, float bottomButtonXOffset, float bottomButtonYOffset) : base(width,
      height, bottomButtonXOffset, bottomButtonYOffset)
    {
      ArtifactManager.ArtifactRegistered += ArtifactCreated;
      AddPagesAndArtifacts();
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
      ReRender();
    }

    private void ReRender()
    {
      foreach (var page in Pages)
      {
        page.Visible = false; //This avoid a crash to desktop when rerendering a Book that a player has open.
        page.Dispose();
      }

      _pagesByArtifact.Clear();
      Pages.Clear();
      AddPagesAndArtifacts();
    }

    private void AddPagesAndArtifacts()
    {
      var firstPage = AddPage();
      firstPage.Visible = true;
      AddAllArtifacts();
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
        _instance = new ArtifactBook(BookWidth, BookHeight, BottomButtonXOffset, BottomButtonYOffset);
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