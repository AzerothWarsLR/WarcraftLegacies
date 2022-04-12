using System;

namespace AzerothWarsCSharp.MacroTools.Frames.Books.Powers
{
  public class PowerPage : Page
  {
    public PowerPage()
    {
      Rows = 3;
      Columns = 1;
      YOffsetTop = 0.025f;
      YOffsetBot = 0.05f;
    }
    
    /// <summary>
    ///   Renders a Power on this PowerPage as a PowerCard.
    /// </summary>
    public void AddPower(Power power)
    {
      if (CardCount >= CardLimit)
        throw new Exception($"PowerPage is already at the card limit of {CardLimit} cards.");
      var powerCard = new PowerCard(power, this);
      PositionFrameAtIndex(powerCard, Cards.Count);
      Cards.Add(powerCard);
      AddFrame(powerCard);
    }
  }
}