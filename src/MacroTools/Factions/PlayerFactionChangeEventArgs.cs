namespace MacroTools.Factions;

public sealed class PlayerFactionChangeEventArgs
{
  public player Player { get; }
  public Faction? PreviousFaction { get; }

  public PlayerFactionChangeEventArgs(player player, Faction? previousFaction)
  {
    Player = player;
    PreviousFaction = previousFaction;
  }
}
