namespace MacroTools.Factions;

public sealed class PlayerChangeTeamEventArgs
{
  public player Player { get; }
  public Team? PreviousTeam { get; }

  public PlayerChangeTeamEventArgs(player player, Team? previousTeam
  )
  {
    Player = player;
    PreviousTeam = previousTeam;
  }
}
