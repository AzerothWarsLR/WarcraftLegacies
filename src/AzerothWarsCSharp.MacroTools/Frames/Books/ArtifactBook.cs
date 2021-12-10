using System;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames.Books
{
  /// <summary>
  ///   Displays all Artifacts in the game.
  /// </summary>
  public sealed class ArtifactBook : Book<ArtifactPage>
  {
    private const float BottomButtonYOffset = 0.015f;
    private const float BottomButtonXOffset = 0.02f;
    private const float BookWidth = 0.7f;
    private const float BookHeight = 0.37f;

    // ReSharper disable once NotAccessedField.Local
    private static ArtifactBook? _instance;
    private static bool _initialized;

    private ArtifactBook(float width, float height, float bottomButtonXOffset, float bottomButtonYOffset) : base(width,
      height, bottomButtonXOffset, bottomButtonYOffset)
    {
      FactionSystem.ArtifactAdded += OnArtifactCreated;
      var firstPage = AddPage();
      firstPage.Visible = true;
      AddAllArtifacts();
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
    }

    private void AddAllArtifacts()
    {
      foreach (var artifact in FactionSystem.GetAllArtifacts()) AddArtifact(artifact);
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
        _instance = new ArtifactBook(BookWidth, BookHeight, BottomButtonXOffset, BottomButtonYOffset);
        _initialized = true;
      }
    }

    protected override void DisposeEvents()
    {
      FactionSystem.ArtifactAdded -= OnArtifactCreated;
    }
  }
}