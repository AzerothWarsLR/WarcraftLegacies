using System;
using MacroTools.ArtifactSystem;

namespace MacroTools.BookSystem.Artifacts
{
  /// <summary>
  ///   Represents a limited number of Artifacts in a rectangular grid.
  /// </summary>
  public sealed class ArtifactPage : Page
  {
    public ArtifactPage()
    {
      Rows = 3;
      Columns = 4;
      YOffsetTop = 0.025f;
      YOffsetBot = 0.05f;
    }

    /// <summary>
    ///   Renders an Artifact on this MenuPage as an ArtifactCard.
    /// </summary>
    public void AddArtifact(Artifact artifact)
    {
      if (CardCount >= CardLimit)
        throw new Exception($"ArtifactPage is already at the card limit of {CardLimit} cards.");
      var artifactCard = new ArtifactCard(artifact, this);
      PositionFrameAtIndex(artifactCard, Cards.Count);
      Cards.Add(artifactCard);
      AddFrame(artifactCard);
    }
  }
}