namespace MacroTools.Legends;

public sealed class LegendChangeOwnerEventArgs
{
  public Legend Legend { get; }
  public player? PreviousOwner { get; }

  public LegendChangeOwnerEventArgs(Legend legend, player? previousOwner = null)
  {
    Legend = legend;
    PreviousOwner = previousOwner;
  }
}
