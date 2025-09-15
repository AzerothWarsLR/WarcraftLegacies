using MacroTools.ArtifactSystem;
using MacroTools.BookSystem.Core;
using MacroTools.Extensions;
using WCSharp.Shared.Data;

namespace MacroTools.BookSystem.ArtifactSystem
{
  /// <summary>
  ///   Displays all Artifacts in the game.
  /// </summary>
  public sealed class ArtifactBook : Book<Artifact, ArtifactPage, ArtifactCard, ArtifactPageFactory, ArtifactCardFactory>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ArtifactBook"/> class.
    /// </summary>
    public ArtifactBook() : base(0.75f, 0.37f, 0.015f, 0.02f, 4)
    {
      ArtifactManager.ArtifactRegistered += ArtifactCreated;
      PopulatePages();
      Title = "Artifacts (F7)";
      LauncherParent = BlzGetFrameByName("UpperButtonBarQuestsButton", 0);
      Position = new Point(0.4f, 0.35f);
      var trigger = CreateTrigger();
      trigger.RegisterSharedKeyEvent(OSKEY_F7, BlzGetTriggerPlayerMetaKey(), false);
      TriggerAddAction(trigger, () =>
      {
        if (GetTriggerPlayer() != GetLocalPlayer())
          return;
        Open(GetLocalPlayer());
      });
    }

    private void AddArtifact(Artifact artifact)
    {
      var lastPage = GetFirstAvailablePage();
      lastPage.AddItem(artifact);
      artifact.Disposed += OnArtifactDisposed;
    }

    private void OnArtifactDisposed(object? sender, Artifact artifact) => ReRender();
    
    private void ArtifactCreated(object? sender, Artifact artifact)
    {
      AddArtifact(artifact);
    }

    /// <inheritdoc />
    protected override void PopulatePages()
    {
      foreach (var artifact in ArtifactManager.GetAllArtifacts())
        AddArtifact(artifact);
    }
  }
}