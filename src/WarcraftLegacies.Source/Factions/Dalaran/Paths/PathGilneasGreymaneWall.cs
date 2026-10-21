namespace WarcraftLegacies.Source.Factions.Dalaran.Paths;

/// <summary>Gilneas leaves the Alliance and shuts itself away behind the Greymane Wall.</summary>
public sealed class PathGilneasGreymaneWall : PathGilneas
{
  public PathGilneasGreymaneWall(GilneasTransformation transformation) : base(transformation)
  {
    Name = "Gilneas: The Greymane Wall";
    Description = "Gilneas City is free, and Genn Greymane has bled enough for the Alliance's wars. He leaves the rest of Dalaran's lands to Lordaeron, seals the Greymane Wall behind his people and trusts no one beyond it.";
    CanGoSolo = true;
  }
}
