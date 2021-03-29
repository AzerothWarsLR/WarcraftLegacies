using AzerothWarsCSharp.Source.Libraries;
using System;

namespace AzerothWarsCSharp.Source
{
  public class FactionTeamChangedEventArgs : EventArgs
  {
    public Faction FactionChangingTeam;
    public Team PreviousTeam;
  }
}
