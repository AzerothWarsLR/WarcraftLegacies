using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Localization;

namespace MacroTools.Factions;

/// <summary>
/// A group of <see cref="Team"/>s that stay separate teams but are allied to each other, and count as one team for
/// team size caps.
/// </summary>
public sealed class Bloc
{
  private readonly List<Team> _teams = new();

  public Bloc(string name) => Name = name;

  public string Name { get; }

  public string LocalizedName => Loc.Get(Name);

  public IReadOnlyList<Team> Teams => _teams;

  /// <summary>The number of players across every <see cref="Team"/> in the bloc.</summary>
  public int Size => _teams.Sum(x => x.Size);

  /// <summary>Adds <paramref name="team"/> to the bloc and allies its players to everyone already in it.</summary>
  public void Add(Team team)
  {
    if (team.Bloc != null)
    {
      throw new InvalidOperationException($"Team {team.Name} is already in the {team.Bloc.Name} bloc.");
    }

    foreach (var existingTeam in _teams)
    {
      foreach (var member in team.Members)
      {
        existingTeam.AllyPlayer(member);
      }
    }

    _teams.Add(team);
    team.Bloc = this;
    TeamChanges.NotifyTeamChanged();
  }
}
