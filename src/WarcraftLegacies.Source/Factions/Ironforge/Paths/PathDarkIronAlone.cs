namespace WarcraftLegacies.Source.Factions.Ironforge.Paths;

/// <summary>The Dark Iron rule from Shadowforge City and answer to no one.</summary>
public sealed class PathDarkIronAlone : PathDarkIron
{
  public PathDarkIronAlone(DarkIronTransformation transformation) : base(transformation)
  {
    Name = "The Dark Iron: Alone";
    Description = "The Great Forge has gone cold and Magni is dead. Dagran Thaurissan and Moira claim what is left of the dwarves for the Dark Iron and rule from Shadowforge City and Grim Batol, bowing to neither the Alliance nor the Legion. The rest of Khaz Modan is left to the Alliance.";
    CanGoSolo = true;
  }
}
