using System;
using System.Collections.Generic;
using MacroTools.FactionSystem;

namespace MacroTools.BookSystem.Powers
{
  public sealed class PowerPage : Page<PowerCard>
  {
    private readonly Dictionary<Power, PowerCard> _cardsByPower = new();
    
    public PowerPage() : base(3, 1)
    {
      YOffsetTop = 0.025f;
      YOffsetBot = 0.05f;
    }

    /// <summary>
    /// Unrenders a <see cref="Power"/> from this <see cref="PowerPage"/>.
    /// </summary>
    public void RemovePower(Power power)
    {
      if (_cardsByPower.TryGetValue(power, out var powerCard))
      {
        Cards.Remove(powerCard);
        _cardsByPower.Remove(power);
      }

      throw new InvalidOperationException($"{power.Name} doesn't exist on this page.");
    }
    
    /// <summary>
    ///   Renders a Power on this PowerPage as a PowerCard.
    /// </summary>
    public void AddPower(Power power)
    {
      if (!HasRoom())
        throw new Exception("PowerPage is already at the card limit of cards.");
      
      var powerCard = new PowerCard(power, this);
      PositionFrameAtIndex(powerCard, Cards.Count);
      Cards.Add(powerCard);
      AddFrame(powerCard);
      _cardsByPower.Add(power, powerCard);
    }
  }
}