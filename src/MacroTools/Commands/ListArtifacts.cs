using System.Linq;
using MacroTools.ArtifactSystem;
using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Commands
{
  public sealed class ListArtifacts : Command
  {
    /// <inheritdoc />
    public override string CommandText => "artifacts";

    /// <inheritdoc />
    public override bool Exact => true;

    /// <inheritdoc />
    public override int MinimumParameterCount => 0;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Lists all Artifacts in the game.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var artifactList = string.Join(", ", ArtifactManager.GetAllArtifacts().Select(x => GetItemName(x.Item)));
      return
        $"{artifactList}\n\nType -artifact followed by the name of one of the artifacts for extra information about it.";
    }
  }
}