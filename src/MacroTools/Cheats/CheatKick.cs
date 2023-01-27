using System;
using MacroTools.CommandSystem;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// Kicks the specified player out of the game.
  /// </summary>
  public sealed class CheatKick : Command
  {

    /// <inheritdoc />
    public override string CommandText => "kick";

    /// <inheritdoc />
    public override int MinimumParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Kicks the specified player out of the game.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      try
      {
        var kickId = S2I(parameters[0]);
        var faction = FactionManager.GetFromName(parameters[0]);
        if (faction != null)
        {
          faction.ScoreStatus = ScoreStatus.Defeated;
          return "Kicking player " + GetPlayerName(Player(kickId)) + ".";
        }
        return " Failed kicking player " + GetPlayerName(Player(kickId)) + ".";

      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
  }
}