using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Chat;
using MacroTools.Localization;

namespace MacroTools.Commands;

/// <summary>
/// A <see cref="Command"/> that dispatches to one of its named verbs. The command's output is paged
/// automatically if it would overflow <see cref="GameText.MaxLines"/>.
/// </summary>
public abstract class CompositeCommand : Command
{
  private sealed class VerbEntry
  {
    public VerbEntry(string name, string argsHint, string description, Func<player, string[], string> handler)
    {
      Name = name;
      ArgsHint = argsHint;
#pragma warning disable CA1866 // string.StartsWith(char) crashes at runtime under the CSharp.lua transpiler
      // Marks where a verb's own arguments end, so Paginate can treat anything past that point as a page number.
      ArgsCount = argsHint.Split(' ', StringSplitOptions.RemoveEmptyEntries).Count(token => token.StartsWith("<"));
#pragma warning restore CA1866
      Description = description;
      Handler = handler;
    }

    public string Name { get; }
    public string ArgsHint { get; }
    public int ArgsCount { get; }
    public string Description { get; }
    public Func<player, string[], string> Handler { get; }
  }

  private readonly List<VerbEntry> _verbs = new();
  private string? _cachedUsage;
  private readonly string _commandText;
  private readonly string _baseDescription;

  protected CompositeCommand(string commandText, string baseDescription)
  {
    // Stored in fields, not overridable properties, because under CSharp.lua a read of an abstract
    // property from within its declaring class transpiles to a nil field lookup instead of a getter call.
    _commandText = commandText;
    _baseDescription = baseDescription;
  }

  protected abstract void ConfigureVerbs();

  /// <inheritdoc />
  public sealed override void OnRegister() => ConfigureVerbs();

  /// <inheritdoc />
  public sealed override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public sealed override string CommandText => _commandText;

  protected void AddVerb(string name, string description, Func<player, string> handler)
    => AddVerb(name, "", description, (whichPlayer, _) => handler(whichPlayer));

  protected void AddVerb(string name, string argsHint, string description, Func<player, string[], string> handler)
    => _verbs.Add(new VerbEntry(name, argsHint, description, handler));

  /// <inheritdoc />
  public sealed override string Description =>
    Loc.Get(_baseDescription)
    + Loc.Format(" Verbs: {verbs}.", string.Join(", ", _verbs.Select(v => Loc.Get(v.Name))));

  /// <inheritdoc />
  public sealed override string Execute(player whichPlayer, params string[] parameters)
  {
    if (parameters.Length == 0)
    {
      return Paginate(Usage(), Array.Empty<string>());
    }

    var verb = parameters[0];
    var verbArgs = parameters.Skip(1).ToArray();
    foreach (var entry in _verbs)
    {
      if (entry.Name != verb)
      {
        continue;
      }

      var message = entry.Handler(whichPlayer, verbArgs);
      // Applies pagination uniformly to every verb's output, so individual verbs don't need to opt in or know
      // their output might overflow.
      return Paginate(message, verbArgs.Skip(entry.ArgsCount).ToArray());
    }

    return Loc.Format("Unknown {command} verb '{verb}'. Valid verbs: {verbs}.",
      ("{command}", _commandText),
      ("{verb}", verb),
      ("{verbs}", string.Join(", ", _verbs.Select(v => Loc.Get(v.Name)))));
  }

  private static string Paginate(string message, string[] pageArgs)
  {
    var lines = message.Split('\n');
    if (lines.Sum(GameText.EstimateLineCount) <= GameText.MaxLines)
    {
      return message;
    }

    var page = 1;
    if (pageArgs.Length > 0 && Pager.TryParsePage(pageArgs, pageArgs.Length - 1, out var parsedPage))
    {
      page = parsedPage;
    }

    return Pager.BuildPage(lines[0], lines.Skip(1).ToList(), page);
  }

  private string Usage()
  {
    if (_cachedUsage != null)
    {
      return _cachedUsage;
    }

    var rows = new List<ColumnFormatter.Row>();
    foreach (var verb in _verbs)
    {
      // The verb's own name and hint are shown in the command list, so both are resolved through the table: a list
      // that states what each verb does in one language and names the verb in another is no use to a reader.
      var name = Loc.Get(verb.Name);
      rows.Add(new ColumnFormatter.Row(
        verb.ArgsHint.Length > 0
          ? $"{name} {Loc.Get(verb.ArgsHint)}"
          : name,
        Loc.Get(verb.Description)));
    }

    return _cachedUsage = ColumnFormatter.BuildUsage(Loc.Format("Usage: -{command} <verb> [args]",
      ("{command}", _commandText)), rows);
  }
}
