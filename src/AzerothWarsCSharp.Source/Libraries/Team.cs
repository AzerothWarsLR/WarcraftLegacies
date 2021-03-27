using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public static HashSet<Team> All { get; } = new();

    public EventHandler<TeamEventArgs> ChangesSize;

    public string Name { get; }
  }
}
