using MacroTools.Commands;
using WarcraftLegacies.Source.GameLogic.Mmd;

namespace WarcraftLegacies.Source.Cheats;

public sealed class CheatForceWin : Command
{
  /// <inheritdoc />
  public override string CommandText => "forcewin";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Marks you as an MMD winner and writes MMD data immediately.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (MmdManager.GetStats(cheater) == null)
    {
      return "You aren't registered with the MMD system yet.";
    }

    MmdManager.SetResult(cheater, "win");
    MmdManager.WriteToMmd();
    return "Marked you as a winner and wrote MMD data.";
  }
}
