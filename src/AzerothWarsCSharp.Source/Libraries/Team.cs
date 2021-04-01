using System;
using System.Collections.Generic;

namespace AzerothWarsCSharp.Source.Libraries
{ 
  public class TeamEventArgs : EventArgs
  {
    public Team Team;
  }

  public class Team
  {
    public Team(string name)
    {
      Name = name;
      All.Add(this);
    }

    /// <summary>
    /// Returns the Team with the provided name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Team ByName(string name)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// A complete set of ALL Teams.
    /// </summary>
    public static HashSet<Team> All { get; } = new();

    public EventHandler<TeamEventArgs> ChangesSize;

    public string Name { get; }

    /// <summary>
    /// Checks whether or not a faction would have too much weight to join this team.
    /// </summary>
    /// <param name="joinerFaction"></param>
    /// <returns></returns>
    public bool CanFitFaction(Faction joinerFaction)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Checks if a faction has previously been invited to this team.
    /// </summary>
    /// <param name="whichFaction"></param>
    /// <returns></returns>
    public bool IsFactionInvited(Faction whichFaction)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Invites a faction to join this team, but doesn't actually add them to it.
    /// </summary>
    /// <param name="joinerFaction"></param>
    public void InviteFaction(object joinerFaction)
    {
      throw new NotImplementedException();
    }
  }
}
