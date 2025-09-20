using System;
using MacroTools.CommandSystem;
using MacroTools.FactionSystem;

namespace MacroTools.Cheats;

/// <summary>
/// Kicks the specified player out of the game.
/// </summary>
public sealed class CheatKick : Command
{

  /// <inheritdoc />
  public override string CommandText => "kick";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Kicks the specified player out of the game.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    try
    {
      if (!FactionManager.TryGetFactionByName(parameters[0], out var faction))
      {
        return $"There is no faction named {parameters[0]}.";
      }

      faction.Defeat();
      return $"Kicking {nameof(Faction)} {faction.Name}.";
    }
    catch (Exception ex)
    {
      return ex.Message;
    }
  }
}
