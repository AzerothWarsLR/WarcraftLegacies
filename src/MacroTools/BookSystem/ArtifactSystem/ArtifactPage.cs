using MacroTools.ArtifactSystem;
using MacroTools.BookSystem.Core;
using MacroTools.BookSystem.Powers;

namespace MacroTools.BookSystem.ArtifactSystem
{
  /// <summary>
  ///   Represents a limited number of Artifacts in a rectangular grid.
  /// </summary>
  public sealed class ArtifactPage : Page<Artifact, ArtifactCard, ArtifactCardFactory>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ArtifactPage"/> class.
    /// </summary>
    internal ArtifactPage(float width, float height) : base(width, height, 3, 5, 0.025f, 0.05f)
    {
    }
  }
}