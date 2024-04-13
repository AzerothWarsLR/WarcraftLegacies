using MacroTools.BookSystem.ArtifactSystem;
using MacroTools.BookSystem.Core;
using MacroTools.Frames;

namespace MacroTools.BookSystem.Powers
{
  public sealed class ArtifactCardFactory : ICardFactory<ArtifactCard>
  {
    /// <inheritdoc />
    public ArtifactCard Create(Frame parent)
    {
      return new ArtifactCard(parent);
    }
  }
}