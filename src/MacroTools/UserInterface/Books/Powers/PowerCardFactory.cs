using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.Powers;

public sealed class PowerCardFactory : ICardFactory<PowerCard>
{
  /// <inheritdoc />
  public PowerCard Create(Frame parent)
  {
    return new PowerCard(parent);
  }
}
