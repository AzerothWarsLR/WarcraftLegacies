using MacroTools.Factions;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Dalaran.Paths;

/// <summary>Gilneas leaves the Alliance to stand with the Night Elves.</summary>
public sealed class PathGilneasNightElves : PathGilneas
{
  public PathGilneasNightElves(GilneasTransformation transformation) : base(transformation)
  {
    Name = "Gilneas: The Night Elves";
    Description = "With Gilneas City in hand, Dalaran gives way to the kingdom of Gilneas. Genn Greymane leaves the rest of Dalaran's land to Lordaeron and turns from the Alliance to seek the Night Elves, whose druids may yet hold the answer to the curse stirring in his people.";
  }

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.NightElves;
}
