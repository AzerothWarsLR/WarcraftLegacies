using MacroTools.Factions;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Dalaran.Paths;

/// <summary>Gilneas leaves the Alliance to stand with the Night Elves.</summary>
public sealed class PathGilneasNightElves : PathGilneas
{
  public PathGilneasNightElves(GilneasTransformation transformation) : base(transformation)
  {
    Name = "Gilneas: The Night Elves";
    Description = "Gilneas City is free, but a curse stirs among its people that no human priest can mend. Genn Greymane leaves the rest of Dalaran's lands to Lordaeron and turns from the Alliance to the night elves, whose druids may yet know a cure.";
  }

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.NightElves;
}
