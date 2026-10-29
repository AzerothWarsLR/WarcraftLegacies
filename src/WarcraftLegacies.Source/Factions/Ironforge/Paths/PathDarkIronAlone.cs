using WarcraftLegacies.Source.Factions.Ironforge.Quests;

namespace WarcraftLegacies.Source.Factions.Ironforge.Paths;

/// <summary>The Dark Iron rule Khaz Modan from Ironforge and answer to no one.</summary>
public sealed class PathDarkIronAlone : PathDarkIron
{
  public PathDarkIronAlone(DarkIronTransformation transformation, QuestDarkIron darkIronAlliance)
    : base(transformation, darkIronAlliance)
  {
    Name = "The Dark Iron: Alone";
    Description = "The Dark Iron have returned to the fold, but not as subjects. Moira Thaurissan, Magni's own daughter and Dagran's queen, claims the throne of Ironforge, and all of Khaz Modan and Grim Batol answer to the Dark Iron. They bow to neither the Alliance nor the Legion. Magni, Muradin and Falstad will not serve her.";
    CanGoSolo = true;
  }
}
