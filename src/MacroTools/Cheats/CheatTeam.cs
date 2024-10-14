using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// Sets the <see cref="Team"/> any <see cref="Faction"/>.
  /// </summary>
  public sealed class CheatTeam : Command
  {
    /// <inheritdoc />
    public override string CommandText => "team";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1, 2);
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    /// <inheritdoc />
    public override string Description => "Sets the specified faction to the specified team.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!FactionManager.TryGetFactionByName(parameters[0], out var faction))
        return $"There is no faction named {parameters[0]}.";
      
      if (faction.Player == null)
        return $"The specified {nameof(Faction)} is not occupied by a player and therefore cannot have a {nameof(Team)}.";

      if (!FactionManager.TryGetTeamByName(parameters[1], out var team))
        return $"You must specify a valid {nameof(Team)} name as the second parameter.";
      
      faction.Player.SetTeam(team);
      return $"Set {faction.Name}'s {nameof(Team)} to {team.Name}.";
    }
  }
}