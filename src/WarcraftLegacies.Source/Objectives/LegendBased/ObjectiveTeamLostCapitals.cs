using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>Completed while a team has lost enough of the given capitals.</summary>
public sealed class ObjectiveTeamLostCapitals : Objective
{
  private readonly Team _team;
  private readonly int _count;
  private readonly List<Capital> _capitals;
  private readonly HashSet<Capital> _heldByTeam = new();
  private readonly HashSet<Capital> _destroyed = new();

  public ObjectiveTeamLostCapitals(Team team, int count, params Capital[] capitals)
  {
    _team = team;
    _count = count;
    _capitals = new List<Capital>(capitals);
    SetDescription("The {team} have lost {count} of their capitals",
      ("{team}", team.LocalizedName), ("{count}", count.ToString()));

    foreach (var capital in _capitals)
    {
      var deathTrigger = trigger.Create();
      deathTrigger.RegisterUnitEvent(capital.Unit, unitevent.Death);
      deathTrigger.AddAction(() =>
      {
        _destroyed.Add(capital);
        Refresh();
      });
      capital.ChangedOwner += _ => Refresh();
    }
  }

  /// <inheritdoc />
  public override void OnAdd(Faction faction) => Refresh();

  private void Refresh()
  {
    var lost = 0;
    foreach (var capital in _capitals)
    {
      if (_destroyed.Contains(capital))
      {
        lost++;
        continue;
      }

      var capitalUnit = capital.Unit;
      if (capitalUnit == null)
      {
        continue;
      }

      if (capitalUnit.Owner.GetPlayerData().Team == _team)
      {
        _heldByTeam.Add(capital);
      }
      else if (_heldByTeam.Contains(capital))
      {
        lost++;
      }
    }

    Progress = lost >= _count ? QuestProgress.Complete : QuestProgress.Incomplete;
  }
}
