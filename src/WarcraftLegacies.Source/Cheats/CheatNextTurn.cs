using MacroTools.Commands;
using MacroTools.GameTime;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Advances the manual historical timeline by exactly one turn.</summary>
public sealed class CheatNextTurn : Command
{
  public override string CommandText => "nextturn";

  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  public override CommandType Type => CommandType.Cheat;

  public override string Description => "Advances the manual historical timeline by one turn.";

  public override string Execute(player cheater, params string[] parameters)
  {
    GameTimeManager.SkipTurns(1);
    return $"Historical Turn: {GameTimeManager.Turn}";
  }
}
