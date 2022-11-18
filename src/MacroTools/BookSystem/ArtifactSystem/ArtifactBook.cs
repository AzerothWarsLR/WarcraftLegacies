using System.Collections.Generic;
using System.Linq;
using MacroTools.ArtifactSystem;
using MacroTools.BookSystem.Artifacts;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.BookSystem.ArtifactSystem
{
  /// <summary>
  ///   Displays all Artifacts in the game.
  /// </summary>
  public sealed class ArtifactBook : Book<ArtifactPage>
  {
    private readonly Dictionary<Artifact, ArtifactPage> _pagesByArtifact = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="ArtifactBook"/> class.
    /// </summary>
    public ArtifactBook() : base(0.65f, 0.37f, 0.015f, 0.02f)
    {
      ArtifactManager.ArtifactRegistered += ArtifactCreated;
      AddPagesAndArtifacts();
      Title = "Artifacts";
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
    
    private void ArtifactCreated(object? sender, Artifact artifact)
    {
      AddArtifact(artifact);
    }

    /// <inheritdoc/>
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