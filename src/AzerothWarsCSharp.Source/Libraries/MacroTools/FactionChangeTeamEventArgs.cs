using System;

namespace AzerothWarsCSharp.Source.Libraries.MacroTools
{
  public sealed class FactionChangeTeamEventArgs : EventArgs
  {
    public Faction Faction { get; }
    public Team? PreviousTeam { get; }

    public FactionChangeTeamEventArgs(Faction faction, Team? previousTeam
    )
    {
      Faction = faction;
      PreviousTeam = previousTeam;
    }
  }
}