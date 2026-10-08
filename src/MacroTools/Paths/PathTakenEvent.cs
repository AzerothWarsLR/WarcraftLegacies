using MacroTools.Extensions;
using MacroTools.Localization;
using MacroTools.WorldEvents;

namespace MacroTools.Paths;

/// <summary>
/// A record in the Events menu of a faction taking a <see cref="FactionPath"/>, so everyone can look back on how the
/// world changed.
/// </summary>
public sealed class PathTakenEvent : WorldEvent
{
  /// <param name="path">The path that was taken.</param>
  /// <param name="factionName">The coloured name of the faction that took it, as it was before taking it.</param>
  /// <param name="owner">The player who took it, used to describe what they became and which team they are on now.</param>
  /// <param name="changedTeam">Whether taking the path moved them to another team.</param>
  public PathTakenEvent(FactionPath path, string factionName, player? owner, bool changedTeam)
  {
    Name = path.Name;
    IconName = path.IconName;
    Description = Loc.Format("{faction} took this path.", ("{faction}", factionName));
    Outcome = GetOutcome(factionName, owner, changedTeam);
  }

  /// <inheritdoc />
  protected override void OnHappened()
  {
  }

  private static string? GetOutcome(string factionName, player? owner, bool changedTeam)
  {
    if (owner == null)
    {
      return null;
    }

    var playerData = owner.GetPlayerData();
    var newName = playerData.Faction?.ColoredName ?? factionName;
    var becameNewFaction = newName != factionName;
    var team = changedTeam ? playerData.Team : null;

    if (becameNewFaction && team != null)
    {
      return Loc.Format("{faction} became the {newFaction} and joined the {team}.",
        ("{faction}", factionName), ("{newFaction}", newName), ("{team}", team.LocalizedName));
    }

    if (becameNewFaction)
    {
      return Loc.Format("{faction} became the {newFaction}.", ("{faction}", factionName), ("{newFaction}", newName));
    }

    return team == null
      ? null
      : Loc.Format("{faction} joined the {team}.", ("{faction}", factionName), ("{team}", team.LocalizedName));
  }
}
