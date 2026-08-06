using System.Linq;
using MacroTools.Chat;
using MacroTools.Commands;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Lists every registered chat command and its description.
/// </summary>
public sealed class CheatHelp : Command
{
  /// <inheritdoc />
  public override string CommandText => "help";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Lists every registered command and its description.";

  /// <inheritdoc />
  public override string Execute(player whichPlayer, params string[] parameters)
  {
    if (!Pager.TryParsePage(parameters, 0, out var page))
    {
      return "Usage: -help [page]";
    }

    return Pager.BuildPage("Commands:", CommandManager.GetAllCommands()
      .Select(command => $"-{command.CommandText}: {command.Description}")
      .ToList(), page);
  }
}
