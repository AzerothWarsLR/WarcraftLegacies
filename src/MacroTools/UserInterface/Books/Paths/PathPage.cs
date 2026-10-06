using MacroTools.Paths;
using MacroTools.UserInterface.Books.Core;

namespace MacroTools.UserInterface.Books.Paths;

public sealed class PathPage : Page<FactionPath, PathCard, PathCardFactory>
{
  public PathPage(float width, float height) : base(width, height, 2, 1, 0.04f, 0.05f)
  {
  }
}
