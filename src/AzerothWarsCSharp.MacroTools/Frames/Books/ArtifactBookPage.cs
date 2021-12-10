using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames.Books
{
  /// <summary>
  ///   Represents a limited number of Artifacts in a rectangular grid.
  /// </summary>
  public class ArtifactBookPage : Frame
  {
    private const int Rows = 3; //How many Artifact Cards fit horizontally on a page
    private const int Columns = 4; //How many Artifact cards fit vertically on a page
    private const float YOffsetTop = 0.025f; //How much space to push the artifact representations in from the top
    private const float YOffsetBot = 0.05f; ////How much space to push the artifact representations in from the bottom

    private readonly List<Frame> _artifactCards = new();

    public ArtifactBookPage(int pageNumber, Frame parent) : base("ArtifactMenuBackdrop", parent, 0, 0)
    {
      Width = parent.Width;
      Height = parent.Height;
      Texture = @"UI/Widgets/EscMenu/Human/blank-background.blp";
      SetAbsPoint(FRAMEPOINT_CENTER, 0.4f, 0.38f);

      var title = new TextFrame("ArtifactMenuTitle", this, 0, 0)
      {
        Text = "Artifacts"
      };
      title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOP, 0, -0.025f);
      AddFrame(title);

      var pageNumberFrame = new TextFrame("ArtifactMenuTitle", this, 0, 0)
      {
        Text = $"Page {pageNumber}"
      };
      pageNumberFrame.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOPRIGHT, -0.05f, -0.025f);
      AddFrame(pageNumberFrame);

      Visible = false;
    }

    /// <summary>
    ///   The number of cards this page can hold.
    /// </summary>
    public int CardLimit => Rows * Columns;

    /// <summary>
    ///   The number of cards this page is holding.
    /// </summary>
    public int CardCount => _artifactCards.Count;

    /// <summary>
    ///   Renders an Artifact on this MenuPage as an ArtifactCard.
    /// </summary>
    public void AddArtifact(Artifact artifact)
    {
      if (CardCount >= CardLimit)
        throw new Exception($"ArtifactBookPage is already at the card limit of {CardLimit} cards.");
      var artifactCard = new ArtifactCard(artifact, this);
      PositionFrameAtIndex(artifactCard, _artifactCards.Count);
      artifactCard.Disposed += OnArtifactCardDisposed;
      _artifactCards.Add(artifactCard);
      AddFrame(artifactCard);
    }

    private void PositionAllCards()
    {
      var i = 0;
      foreach (var card in _artifactCards)
      {
        Console.WriteLine(i);
        PositionFrameAtIndex(card, i);
        i++;
      }
    }
    
    private void PositionFrameAtIndex(Frame card, int index)
    {
      var cardGridX = index % Columns; //Horizontal index of the card
      var cardGridY = index / Columns;
      var boxSpacingX = (Width - card.Width * Columns) / (Columns + 1);
      var boxSpacingY = (Height - YOffsetTop - YOffsetBot - card.Height * Rows) / (Rows + 1);
      var cardPosX = card.Width * cardGridX + boxSpacingX * (cardGridX + 1);
      var cardPosY = -(YOffsetTop + (card.Height * cardGridY + boxSpacingY * (cardGridY + 1)));
      card.SetPoint(FRAMEPOINT_TOPLEFT, this, FRAMEPOINT_TOPLEFT, cardPosX, cardPosY);
    }

    private void OnArtifactCardDisposed(object? sender, FrameEventArgs args)
    {
      _artifactCards.Remove(args.Frame);
      PositionAllCards();
    }

    public new void Dispose()
    {
      BlzDestroyFrame(_handle);
      Disposed?.Invoke(this, new FrameEventArgs(this));
      foreach (var artifactCard in _artifactCards)
      {
        artifactCard.Disposed -= OnArtifactCardDisposed;
      }
    }
  }
}