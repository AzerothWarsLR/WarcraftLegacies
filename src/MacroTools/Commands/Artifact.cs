using MacroTools.ArtifactSystem;
using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Commands
{
  public sealed class Artifact : Command
  {
    /// <inheritdoc />
    public override string CommandText => "artifact";

    /// <inheritdoc />
    public override bool Exact => false;

    /// <inheritdoc />
    public override int MinimumParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Normal;

    /// <inheritdoc />
    public override string Description => "Pings the specified Artifact if nobody owns it, and tells you who owns it otherwise.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var artifactName = parameters[0];
      
      if (!ArtifactManager.TryGetByName(artifactName, out var artifact))
        return $"There is no Artifact named {artifactName}";

      switch (artifact.LocationType)
      {
        case ArtifactLocationType.Ground:
          artifact.Ping(cheater);
          return $"Pinging {artifactName}.";
        case ArtifactLocationType.Unit:
        {
          var owningPlayerFaction = artifact.OwningPlayer?.GetFaction();

          if (owningPlayerFaction != null) 
            return $"{artifactName} is owned by {owningPlayerFaction.ColoredName}.";
          
          artifact.Ping(cheater);
          return $"Pinging {artifactName}.";

        }
        default:
          return "Unexpected error when trying to get information about {artifactName}.";
      }
    }
  }
}