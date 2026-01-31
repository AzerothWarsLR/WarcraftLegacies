using MacroTools.Factions;
using MacroTools.UserInterface.Books.Core;

namespace MacroTools.UserInterface.Books.Powers;

public sealed class PowerPage : Page<Power, PowerCard, PowerCardFactory>
{
  public PowerPage(float width, float height) : base(width, height, 3, 1, 0.025f, 0.05f)
  {
  }
}
