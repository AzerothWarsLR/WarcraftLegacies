namespace WarcraftLegacies.Source.Factions.Dalaran.Paths;

/// <summary>Gilneas leaves the Alliance and shuts itself away behind the Greymane Wall.</summary>
public sealed class PathGilneasGreymaneWall : PathGilneas
{
  public PathGilneasGreymaneWall(GilneasTransformation transformation) : base(transformation)
  {
    Name = "Gilneas: The Greymane Wall";
    Description = "With Gilneas City in hand, Dalaran gives way to the kingdom of Gilneas. Genn Greymane leaves the rest of Dalaran's land to Lordaeron, seals the Greymane Wall and trusts no one but his own people.";
    CanGoSolo = true;
  }
}
