using MacroTools.CheatSystem;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// Sets the <see cref="Team"/> any <see cref="Faction"/>.
  /// </summary>
  public sealed class CheatTeam : Cheat
  {
    /// <inheritdoc />
    public override string Command => "setteam";

    /// <inheritdoc />
    public override int ParameterCount => 2;
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var faction = FactionManager.GetFromName(parameters[0]);
      if (faction == null)
        return $"You must specify a valid {nameof(Faction)} name as the first parameter.";
      if (faction.Player == null)
      {
        return $"The specified {nameof(Faction)} is not occupied by a player and therefore cannot have a {nameof(Team)}.";
      }
      var team = FactionManager.GetTeamByName(parameters[1]);
      if (team == null)
        return $"You must specify a valid {nameof(Team)} name as the second parameter.";
      faction.Player.SetTeam(team);
      return $"Set {faction.Name}'s {nameof(Team)} to {team.Name}.";
    }
  }
}