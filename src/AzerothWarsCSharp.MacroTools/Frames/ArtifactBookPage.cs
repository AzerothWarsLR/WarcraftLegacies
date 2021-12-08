using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames
{
  /// <summary>
  ///   Represents a limited number of Artifacts in a rectangular grid.
  /// </summary>
  public class ArtifactBookPage : Frame
  {
    private const float BackdropWidth = 0.7f;
    private const float BackdropHeight = 0.37f;
    private const float BottomButtonYOffset = 0.015f;
    private const float BottomButtonXOffset = 0.02f;
    private const int Rows = 3; //How many Artifact Cards fit horizontally on a page
    private const int Columns = 4; //How many Artifact cards fit vertically on a page
    private const float YOffsetTop = 0.025f; //How much space to push the artifact representations in from the top
    private const float YOffsetBot = 0.05f; ////How much space to push the artifact representations in from the bottom

    private readonly List<Frame> _artifactCards = new();
    private readonly Button _nextButton;
    private readonly Button _previousButton;
    private ArtifactBookPage? _next;
    private ArtifactBookPage? _previous;

    public ArtifactBookPage(int pageNumber) : base("ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0),
      0, 0)
    {
      Width = BackdropWidth;
      Height = BackdropHeight;
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

      //Exit button
      var exitbutton = new Button("ScriptDialogButton", this, 0, 0)
      {
        Width = 0.09f,
        Height = 0.037f,
        Text = "Exit",
        OnClick = () => Visible = false
      };
      exitbutton.SetPoint(FRAMEPOINT_BOTTOM, this, FRAMEPOINT_BOTTOM, 0, BottomButtonYOffset);
      AddFrame(exitbutton);

      //Next button
      _nextButton = new Button("ScriptDialogButton", this, 0, 0)
      {
        Width = 0.09f,
        Height = 0.037f,
        Text = "Next",
        OnClick = OnClickNext,
        Visible = false
      };
      _nextButton.SetPoint(FRAMEPOINT_BOTTOMRIGHT, this, FRAMEPOINT_BOTTOMRIGHT, -BottomButtonXOffset,
        BottomButtonYOffset);
      AddFrame(_nextButton);

      //Next button
      _previousButton = new Button("ScriptDialogButton", this, 0, 0)
      {
        Width = 0.09f,
        Height = 0.037f,
        Text = "Previous",
        OnClick = OnClickPrevious,
        Visible = false
      };
      _previousButton.SetPoint(FRAMEPOINT_BOTTOMLEFT, this, FRAMEPOINT_BOTTOMLEFT, BottomButtonXOffset,
        BottomButtonYOffset);
      AddFrame(_previousButton);

      Visible = false;
    }

    public ArtifactBookPage? Next
    {
      get => _next;
      set
      {
        _next = value;
        _nextButton.Visible = value != null;
      }
    }

    public ArtifactBookPage? Previous
    {
      get => _previous;
      set
      {
        _previous = value;
        _previousButton.Visible = value != null;
      }
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
    
    private void OnClickNext()
    {
      try
      {
        if (Next == null) throw new Exception("ArtifactBookPage has no next page.");
        Visible = false;
        Next.Visible = true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void OnClickPrevious()
    {
      try
      {
        if (Previous == null) throw new Exception("ArtifactBookPage has no previous page.");
        Visible = false;
        Previous.Visible = true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
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