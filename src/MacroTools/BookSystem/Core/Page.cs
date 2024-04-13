using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Frames;
using static War3Api.Common;

namespace MacroTools.BookSystem.Core
{
  public abstract class Page<TCard, TCardFactory> : Frame
    where TCard : Card
    where TCardFactory : ICardFactory<TCard>, new()
  {
    private readonly List<TCard> _cards;
    private readonly TextFrame _pageNumberFrame;
    private readonly int _rows;
    private readonly int _columns;
    private readonly float _yOffsetTop;
    private readonly float _yOffsetBot;

    public int PageNumber
    {
      set => _pageNumberFrame.Text = $"Page {value.ToString()}";
    }

    protected Page(float width, float height, int rows, int columns, float yOffsetTop, float yOffsetBot) :
      base("ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
    {
      _rows = rows;
      _columns = columns;
      _yOffsetTop = yOffsetTop;
      _yOffsetBot = yOffsetBot;
      Width = width;
      Height = height;
      Texture = "UI/Widgets/EscMenu/Human/blank-background.blp";
      SetAbsPoint(FRAMEPOINT_CENTER, 0.4f, 0.38f);

      _pageNumberFrame = new TextFrame("ArtifactMenuTitle", this, 0)
      {
        Text = "Page DEFAULT"
      };
      _pageNumberFrame.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOPRIGHT, -0.05f, -0.025f);
      AddFrame(_pageNumberFrame);

      _cards = CreateCards(rows * columns);

      Visible = false;
    }

    /// <summary>
    /// Whether or not the Page still has room to fill in new cards.
    /// </summary>
    public bool HasUnoccupiedCards() => !_cards.All(x => x.Occupied);

    /// <summary>
    /// Whether or not the Page has any active cards.
    /// </summary>
    public bool HasOccupiedCards() => _cards.Any(x => x.Occupied);

    /// <summary>
    /// Returns the first unoccupied Card.
    /// </summary>
    protected TCard GetFirstUnoccupiedCard() => _cards.First(x => !x.Occupied);

    private void PositionFrameAtIndex(Frame card, int index)
    {
      var cardGridX = index % _columns; //Horizontal index of the card
      var cardGridY = index / _columns;
      var boxSpacingX = (Width - card.Width * _columns) / (_columns + 1);
      var boxSpacingY = (Height - _yOffsetTop - _yOffsetBot - card.Height * _rows) / (_rows + 1);
      var cardPosX = card.Width * cardGridX + boxSpacingX * (cardGridX + 1);
      var cardPosY = -(_yOffsetTop + (card.Height * cardGridY + boxSpacingY * (cardGridY + 1)));
      card.SetPoint(FRAMEPOINT_TOPLEFT, this, FRAMEPOINT_TOPLEFT, cardPosX, cardPosY);
    }

    private List<TCard> CreateCards(int maximumCardCount)
    {
      var cards = new List<TCard>(maximumCardCount);
      var cardFactory = new TCardFactory();
      for (var i = 0; i < maximumCardCount; i++)
      {
        var newCard = cardFactory.Create(this);
        cards.Add(newCard);
        PositionFrameAtIndex(newCard, i);
      }

      return cards;
    }
  }
}