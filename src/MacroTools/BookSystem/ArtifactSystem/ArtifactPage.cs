using MacroTools.ArtifactSystem;
using MacroTools.BookSystem.Core;
using MacroTools.BookSystem.Powers;

namespace MacroTools.BookSystem.ArtifactSystem
{
  /// <summary>
  ///   Represents a limited number of Artifacts in a rectangular grid.
  /// </summary>
  public sealed class ArtifactPage : Page<ArtifactCard, ArtifactCardFactory>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ArtifactPage"/> class.
    /// </summary>
    internal ArtifactPage(float width, float height) : base(width, height, 3, 5, 0.025f, 0.05f)
    {
    }

    /// <summary>
    ///   Renders an Artifact on this MenuPage as an ArtifactCard.
    /// </summary>
    internal void AddArtifact(Artifact artifact)
    {
      var artifactCard = GetFirstUnoccupiedCard();
      artifactCard.Artifact = artifact;
    }

    internal void Clear()
    {
      foreach (var card in Cards) 
        card.Artifact = null;
    }
  }
}