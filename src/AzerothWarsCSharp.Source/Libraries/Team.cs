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

    public static HashSet<Team> All { get; } = new();

    public EventHandler<TeamEventArgs> ChangesSize;

    public string Name { get; }
  }
}
