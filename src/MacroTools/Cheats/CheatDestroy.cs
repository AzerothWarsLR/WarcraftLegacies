using MacroTools.ArtifactSystem;
using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// Destroys an <see cref="Artifact"/>.
  /// </summary>
  public sealed class CheatDestroy : Command
  {
    /// <inheritdoc />
    public override string CommandText => "destroy";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    /// <inheritdoc />
    public override string Description => $"Destroys the specified {nameof(Artifact)}.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var artifact = ArtifactManager.GetFromName(parameters[0]);
      if (artifact == null)
        return $"You must specify the name of a registered {nameof(Artifact)} as the first parameter.";
      
      var artifactName = GetItemName(artifact.Item);
      ArtifactManager.Destroy(artifact);
      return $"Destroyed {artifactName}";
    }
  }
}