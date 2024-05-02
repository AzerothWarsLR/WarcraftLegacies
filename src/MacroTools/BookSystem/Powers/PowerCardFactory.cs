using MacroTools.BookSystem.Core;
using MacroTools.Frames;

namespace MacroTools.BookSystem.Powers
{
  public sealed class PowerCardFactory : ICardFactory<PowerCard>
  {
    /// <inheritdoc />
    public PowerCard Create(Frame parent)
    {
      return new PowerCard(parent);
    }
  }
}