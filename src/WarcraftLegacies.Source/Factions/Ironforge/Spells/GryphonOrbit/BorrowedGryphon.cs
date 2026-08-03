namespace WarcraftLegacies.Source.Factions.Ironforge.Spells.GryphonOrbit;

public sealed class BorrowedGryphon
{
  public unit Unit { get; }
  public float X { get; }
  public float Y { get; }
  public float Facing { get; }
  public player Owner { get; }

  public BorrowedGryphon(unit unit)
  {
    Unit = unit;
    X = unit.X;
    Y = unit.Y;
    Facing = unit.Facing;
    Owner = unit.Owner;
  }
}
