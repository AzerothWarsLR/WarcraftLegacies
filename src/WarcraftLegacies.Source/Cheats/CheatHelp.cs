using System.Linq;
using MacroTools.Chat;
using MacroTools.Commands;
using MacroTools.Localization;

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
      return Loc.Get("Usage: -help [page]");
    }

    return Pager.BuildPage(Loc.Get("Commands:"), CommandManager.GetAllCommands()
      .Select(command => $"-{command.CommandText}: {Loc.Get(command.Description)}")
      .ToList(), page);
  }
}
