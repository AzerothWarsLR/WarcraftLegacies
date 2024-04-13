using System;
using System.Collections.Generic;
using MacroTools.BookSystem.Core;
using MacroTools.FactionSystem;

namespace MacroTools.BookSystem.Powers
{
  public sealed class PowerPage : Page<PowerCard, PowerCardFactory>
  {
    private readonly Dictionary<Power, PowerCard> _cardsByPower = new();
    
    public PowerPage(float width, float height) : base(width, height, 3, 1, 0.025f, 0.05f)
    {
    }

    /// <summary>
    /// Unrenders a <see cref="Power"/> from this <see cref="PowerPage"/>.
    /// </summary>
    public void RemovePower(Power power)
    {
      if (_cardsByPower.TryGetValue(power, out var powerCard))
      {
        //Cards.Remove(powerCard);
        _cardsByPower.Remove(power);
      }

      throw new InvalidOperationException($"{power.Name} doesn't exist on this page.");
    }
    
    /// <summary>
    ///   Renders a Power on this PowerPage as a PowerCard.
    /// </summary>
    public void AddPower(Power power)
    {
      var powerCard = GetFirstUnoccupiedCard();
      powerCard.Power = power;
      _cardsByPower.Add(power, powerCard);
    }
  }
}