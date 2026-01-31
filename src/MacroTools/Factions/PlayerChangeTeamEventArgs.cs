using System;

namespace MacroTools.Factions;

public sealed class PlayerChangeTeamEventArgs : EventArgs
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
