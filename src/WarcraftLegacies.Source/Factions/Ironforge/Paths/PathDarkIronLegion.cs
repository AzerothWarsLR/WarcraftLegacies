using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Ironforge.Paths;

/// <summary>The Dark Iron take Ironforge and join the Burning Legion's side.</summary>
public sealed class PathDarkIronLegion : PathDarkIron
{
  public PathDarkIronLegion(DarkIronTransformation transformation, QuestDarkIron darkIronAlliance)
    : base(transformation, darkIronAlliance)
  {
    Name = "The Dark Iron: The Burning Legion";
    Description = "The Dark Iron have returned to the fold, but not as subjects. Moira Thaurissan, Magni's own daughter and Dagran's queen, claims the throne of Ironforge, and all of Khaz Modan and Grim Batol answer to the Dark Iron. Their old masters stir in the fires below, and the dwarves take up arms beside the Burning Legion. Magni, Muradin and Falstad will not serve her.";
  }

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.Legion;
}
