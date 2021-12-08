using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames
{
  /// <summary>
  /// Displays all Artifacts in the game.
  /// The Menu is split up into multiples Pages that can be clicked through to.
  /// </summary>
  public static class ArtifactBook
  {
    private static bool _initialized;
    private static Button? _launcher;
    private static readonly LinkedList<ArtifactBookPage?> Pages = new();

    private static void AddArtifact(Artifact artifact)
    {
      if (LastPage!.CardCount >= LastPage.CardLimit)
      {
        var newPage = new ArtifactBookPage(1);
        LastPage.Next = newPage;
        newPage.Previous = LastPage;
        Pages.AddLast(newPage);
      }
      LastPage.AddArtifact(artifact);
    }
    
    private static void AddAllArtifacts()
    {
      foreach (var artifact in FactionSystem.GetAllArtifacts())
      {
        AddArtifact(artifact);
      }
    }
    
    private static void OpenFirstPage()
    {
      Pages.First!.Value!.Visible = !Pages.First.Value.Visible;
    }
    
    private static void LoadToc(string tocFilePath)
    {
      if (!BlzLoadTOCFile(tocFilePath))
      {
        throw new Exception($"Failed to load TOC {tocFilePath}");
      }
    }
    
    private static void CreateLauncher()
    {
      _launcher = new Button("ScriptDialogButton", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0))
      {
        Width = 0.2f,
        Height = 0.025f,
        Text = "Artifacts",
        OnClick = OpenFirstPage
      };
      _launcher.SetAbsPoint(FRAMEPOINT_CENTER, 0, 0.56f);
    }

    private static ArtifactBookPage? FirstPage => Pages.First?.Value;

    private static ArtifactBookPage? LastPage => Pages.Last?.Value;

    private static void OnArtifactCreated(object? sender, ArtifactEventArgs args)
    {
      AddArtifact(args.Artifact);
    }
    
    private static void RegisterEvents()
    {
      FactionSystem.ArtifactAdded += OnArtifactCreated;
    }
    
    public static void Initialize()
    {
      if (!_initialized)
      {
        _initialized = true;
        LoadToc(@"war3mapImported\ArtifactSystem.toc");
        LoadToc(@"ui\framedef\framedef.toc");
        Pages.AddFirst(new ArtifactBookPage(0));
        CreateLauncher();
        AddAllArtifacts();
        RegisterEvents();
      }
    }
  }
}