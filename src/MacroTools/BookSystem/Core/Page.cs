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
    protected readonly List<TCard> Cards;
    private protected readonly TCardFactory CardFactory;
    
    private readonly TextFrame _pageNumberFrame;
    private readonly int _rows;
    private readonly int _columns;
    
    public int PageNumber
    {
      set => _pageNumberFrame.Text = $"Page {value.ToString()}";
    }
    
    protected float YOffsetTop { get; init; }
    
    protected float YOffsetBot { get; init; }

    protected Page(int rows, int columns) : base("ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
    {
      _rows = rows;
      _columns = columns;
      CardFactory = new TCardFactory();
      Cards = CreateCards(rows * columns);
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
    /// Whether or not the Page still has room to fill in new cards.
    /// </summary>
    public bool HasRoom() => !Cards.All(x => x.Visible);
    
    /// <summary>
    /// Whether or not the Page has any active cards.
    /// </summary>
    public bool HasCards() => Cards.Any(x => x.Visible);

    protected void PositionFrameAtIndex(Frame card, int index)
    {
      var cardGridX = index % _columns; //Horizontal index of the card
      var cardGridY = index / _columns;
      var boxSpacingX = (Width - card.Width * _columns) / (_columns + 1);
      var boxSpacingY = (Height - YOffsetTop - YOffsetBot - card.Height * _rows) / (_rows + 1);
      var cardPosX = card.Width * cardGridX + boxSpacingX * (cardGridX + 1);
      var cardPosY = -(YOffsetTop + (card.Height * cardGridY + boxSpacingY * (cardGridY + 1)));
      card.SetPoint(FRAMEPOINT_TOPLEFT, this, FRAMEPOINT_TOPLEFT, cardPosX, cardPosY);
    }

    private List<TCard> CreateCards(int maximumCardCount)
    {
      var cards = new List<TCard>(maximumCardCount);
      var cardFactory = new TCardFactory();
      for (var i = 0; i < maximumCardCount; i++) 
        cards.Add(cardFactory.Create(this));

      return cards;
    }
  }
}