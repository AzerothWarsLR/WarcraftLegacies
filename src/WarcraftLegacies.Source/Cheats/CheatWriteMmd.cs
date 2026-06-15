using MacroTools.Commands;
using WarcraftLegacies.Source.GameLogic.Mmd;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Forces an immediate MMD write to the game cache.
/// Usage: -mmd
/// </summary>
public sealed class CheatWriteMmd : Command
{
  public override string CommandText => "mmd";

  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  public override CommandType Type => CommandType.Cheat;

  public override string Description => "Forces MMD to write to the game cache immediately.";

  public override string Execute(player cheater, params string[] parameters)
  {
    MmdManager.WriteToMmdCache();
    return "MMD write triggered.";
  }
}
