using MacroTools.Factions;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Ironforge.Paths;

/// <summary>The Dark Iron join the Burning Legion's side, as they once marched beside the Blackrock orcs.</summary>
public sealed class PathDarkIronLegion : PathDarkIron
{
  public PathDarkIronLegion(DarkIronTransformation transformation) : base(transformation)
  {
    Name = "The Dark Iron: The Burning Legion";
    Description = "The Great Forge has gone cold and Magni is dead. Dagran Thaurissan and Moira claim what is left of the dwarves for the Dark Iron, rule from Shadowforge City and Grim Batol, and take up arms once more beside the Blackrock and their demon masters. The rest of Khaz Modan is left to the Alliance.";
  }

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.Legion;
}
