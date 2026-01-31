using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.Artifacts;

public sealed class ArtifactCardFactory : ICardFactory<ArtifactCard>
{
  /// <inheritdoc />
  public ArtifactCard Create(Frame parent) => new(parent);
}
