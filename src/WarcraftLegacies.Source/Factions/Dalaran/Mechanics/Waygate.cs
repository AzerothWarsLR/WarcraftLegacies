namespace WarcraftLegacies.Source.Factions.Dalaran.Mechanics;

/// <summary>
/// One of Dalran's two gates.
/// </summary>
public sealed class Waygate
{
  public Waygate(unit whichUnit)
  {
    Unit = whichUnit;
  }

  public unit Unit { get; }

  public bool IsConstructed { get; private set; }

  public Waygate? Sister { get; set; }

  public bool IsOperational =>
    IsConstructed &&
    Unit.Alive &&
    Sister is { IsConstructed: true } &&
    Sister.Unit.Alive;

  public void MarkConstructed()
  {
    IsConstructed = true;
  }
}
