using MacroTools.BookSystem.Core;
using MacroTools.FactionSystem;

namespace MacroTools.BookSystem.Powers
{
  public sealed class PowerPage : Page<Power, PowerCard, PowerCardFactory>
  {
    public PowerPage(float width, float height) : base(width, height, 3, 1, 0.025f, 0.05f)
    {
    }
    
    /// <summary>
    ///   Renders a Power on this PowerPage as a PowerCard.
    /// </summary>
    public void AddPower(Power power)
    {
      var powerCard = GetFirstUnoccupiedCard();
      powerCard.Item = power;
    }
  }
}