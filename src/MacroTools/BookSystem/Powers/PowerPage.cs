using MacroTools.BookSystem.Core;
using MacroTools.Factions;

namespace MacroTools.BookSystem.Powers;

public sealed class PowerPage : Page<Power, PowerCard, PowerCardFactory>
{
  public PowerPage(float width, float height) : base(width, height, 3, 1, 0.025f, 0.05f)
  {
  }
}
