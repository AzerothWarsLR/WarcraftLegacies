using System;
using MacroTools.ArtifactSystem;

namespace MacroTools.BookSystem.ArtifactSystem
{
  /// <summary>
  ///   Represents a limited number of Artifacts in a rectangular grid.
  /// </summary>
  public sealed class ArtifactPage : Page
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ArtifactPage"/> class.
    /// </summary>
    public ArtifactPage()
    {
      Rows = 3;
      Columns = 5;
      YOffsetTop = 0.025f;
      YOffsetBot = 0.05f;
    }

    /// <summary>
    ///   Renders an Artifact on this MenuPage as an ArtifactCard.
    /// </summary>
    public void AddArtifact(Artifact artifact)
    {
      if (HasRoom())
        throw new Exception("ArtifactPage is already at the card limit.");
      var artifactCard = new ArtifactCard(artifact, this);
      PositionFrameAtIndex(artifactCard, Cards.Count);
      Cards.Add(artifactCard);
      AddFrame(artifactCard);
    }
  }
}