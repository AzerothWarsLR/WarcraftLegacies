using MacroTools.Factions;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Paths;

/// <summary>The tauren turn to the night elves, who share their reverence for the land.</summary>
public sealed class PathFindNewAlliesNightElves : PathFindNewAllies
{
  public PathFindNewAlliesNightElves()
  {
    Name = "Find New Allies: The Night Elves";
    Description = "The orcs have given themselves to the demons once more. Cairne leads his people to the night elves, who honour the land and the spirits as the tauren do.";
  }

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.NightElves;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
  }
}
