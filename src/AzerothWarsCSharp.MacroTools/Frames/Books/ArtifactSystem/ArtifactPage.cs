using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.ArtifactSystem;

namespace AzerothWarsCSharp.MacroTools.Frames.Books.ArtifactSystem
{
  /// <summary>
  ///   Represents a limited number of Artifacts in a rectangular grid.
  /// </summary>
  public sealed class ArtifactPage : Page
  {
    private readonly Dictionary<Artifact, ArtifactCard> _cardsByArtifact = new();
    
    public ArtifactPage()
    {
      Rows = 3;
      Columns = 4;
      YOffsetTop = 0.025f;
      YOffsetBot = 0.05f;
    }
    
    /// <summary>
    /// Unrenders a <see cref="Artifact"/> from this <see cref="ArtifactPage"/>.
    /// </summary>
    public void RemoveArtifact(Artifact artifact)
    {
      if (_cardsByArtifact.TryGetValue(artifact, out var artifactCard))
      {
        Cards.Remove(artifactCard);
        _cardsByArtifact.Remove(artifact);
        artifactCard.Dispose();
      }
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
      _cardsByArtifact.Add(artifact, artifactCard);
    }
  }
}