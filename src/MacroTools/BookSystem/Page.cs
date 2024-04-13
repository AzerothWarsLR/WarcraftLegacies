using System;
using System.Collections.Generic;
using MacroTools.Frames;
using static War3Api.Common;

namespace MacroTools.BookSystem
{
  public abstract class Page : Frame
  {
    protected readonly List<Frame> Cards = new();
    private readonly TextFrame _pageNumberFrame;

    public int PageNumber
    {
      set => _pageNumberFrame.Text = $"Page {value.ToString()}";
    }

    protected int Rows { get; init; }
    protected int Columns { get; init; }
    protected float YOffsetTop { get; init; }
    protected float YOffsetBot { get; init; }

    protected Page() : base("ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
    {
      Texture = "UI/Widgets/EscMenu/Human/blank-background.blp";
      SetAbsPoint(FRAMEPOINT_CENTER, 0.4f, 0.38f);

      _pageNumberFrame = new TextFrame("ArtifactMenuTitle", this, 0)
      {
        Text = "Page DEFAULT"
      };
      _pageNumberFrame.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOPRIGHT, -0.05f, -0.025f);
      AddFrame(_pageNumberFrame);

      Visible = false;
    }

    /// <summary>
    ///   The number of cards this page can hold.
    /// </summary>
    private int CardLimit => Rows * Columns;

    /// <summary>
    ///   The number of cards this page is holding.
    /// </summary>
    private int CardCount => Cards.Count;

    /// <summary>
    /// Whether or not the <see cref="Page"/> still has room to fill in new cards.
    /// </summary>
    public bool HasRoom() => CardCount < CardLimit;
    
    protected void PositionAllCards()
    {
      var i = 0;
      foreach (var card in Cards)
      {
        PositionFrameAtIndex(card, i);
        i++;
      }
    }
    
    protected void PositionFrameAtIndex(Frame card, int index)
    {
      var cardGridX = index % Columns; //Horizontal index of the card
      var cardGridY = index / Columns;
      var boxSpacingX = (Width - card.Width * Columns) / (Columns + 1);
      var boxSpacingY = (Height - YOffsetTop - YOffsetBot - card.Height * Rows) / (Rows + 1);
      var cardPosX = card.Width * cardGridX + boxSpacingX * (cardGridX + 1);
      var cardPosY = -(YOffsetTop + (card.Height * cardGridY + boxSpacingY * (cardGridY + 1)));
      card.SetPoint(FRAMEPOINT_TOPLEFT, this, FRAMEPOINT_TOPLEFT, cardPosX, cardPosY);
    }
  }
}