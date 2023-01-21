using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatLumber : Command
  {
    /// <inheritdoc />
    public override string CommandText => "lumber";

    /// <inheritdoc />
    public override int ParameterCount => 1;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!int.TryParse(parameters[0], out var lumber))
        return "You must specify a valid integer as the first parameter.";
      
      SetPlayerState(cheater, PLAYER_STATE_RESOURCE_LUMBER, lumber);
      return $"Setting lumber to {lumber}.";
    }
  }
}