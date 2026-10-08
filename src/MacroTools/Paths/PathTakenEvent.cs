using MacroTools.Extensions;
using MacroTools.Localization;
using MacroTools.WorldEvents;

namespace MacroTools.Paths;

/// <summary>Records a faction taking a <see cref="FactionPath"/> in the Events menu.</summary>
public sealed class PathTakenEvent : WorldEvent
{
  /// <param name="path">The path that was taken.</param>
  /// <param name="factionName">The coloured name of the faction before it took the path.</param>
  /// <param name="owner">The player who took it.</param>
  /// <param name="changedTeam">Whether taking it moved them to another team.</param>
  public PathTakenEvent(FactionPath path, string factionName, player? owner, bool changedTeam)
  {
    Name = path.Name;
    IconName = path.IconName;
    Description = Loc.Format("{faction} took this path.", ("{faction}", factionName));
    var outcome = GetOutcome(factionName, owner, changedTeam);
    Outcome = outcome == null ? path.TakenOutcome : path.TakenOutcome == null ? outcome : $"{outcome} {path.TakenOutcome}";
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
    var newFaction = playerData.Faction;
    var newName = newFaction?.ColoredName ?? factionName;
    var becameNewFaction = newName != factionName;
    if (newFaction != null && newFaction.NameTakesArticle)
    {
      newName = $"{Loc.Get("the")} {newName}";
    }
    var team = changedTeam ? playerData.Team : null;

    if (becameNewFaction && team != null)
    {
      return Loc.Format("{faction} became {newFaction} and joined the {team}.",
        ("{faction}", factionName), ("{newFaction}", newName), ("{team}", team.LocalizedName));
    }

    if (becameNewFaction)
    {
      return Loc.Format("{faction} became {newFaction}.", ("{faction}", factionName), ("{newFaction}", newName));
    }

    return team == null
      ? null
      : Loc.Format("{faction} joined the {team}.", ("{faction}", factionName), ("{team}", team.LocalizedName));
  }
}
