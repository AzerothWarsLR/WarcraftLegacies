using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.Paths;

public sealed class PathCardFactory : ICardFactory<PathCard>
{
  /// <inheritdoc />
  public PathCard Create(Frame parent)
  {
    return new PathCard(parent);
  }
}
