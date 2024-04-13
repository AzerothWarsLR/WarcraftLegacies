using MacroTools.BookSystem.Core;
using MacroTools.Frames;

namespace MacroTools.BookSystem.ArtifactSystem
{
  public sealed class ArtifactCardFactory : ICardFactory<ArtifactCard>
  {
    /// <inheritdoc />
    public ArtifactCard Create(Frame parent) => new(parent);
  }
}