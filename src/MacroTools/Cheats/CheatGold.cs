using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// Gives the player a specified amount of gold.
  /// </summary>
  public sealed class CheatGold : Command
  {

    /// <inheritdoc />
    public override string CommandText => "addgold";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Gives the player a specified amount of gold.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      SetPlayerState(cheater, PLAYER_STATE_RESOURCE_GOLD, S2I(parameters[0]));
      return "Set to " + parameters[0] + " gold.";
    }
  }
}