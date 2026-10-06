using MacroTools.Artifacts;
using MacroTools.Commands;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Cheats;

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
  public override string Description => "Destroys the specified Artifact.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (!ArtifactManager.TryGetByName(parameters[0], out var artifact))
    {
      return Loc.Get("You must specify the name of a registered Artifact as the first parameter.");
    }

    var artifactName = artifact.Item.Name;
    ArtifactManager.Destroy(artifact);
    return Loc.Format("Destroyed {artifact}", ("{artifact}", artifactName));
  }
}
