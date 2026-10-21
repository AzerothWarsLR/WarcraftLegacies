using System;
using System.Linq;
using MacroTools.Commands;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A <see cref="CompositeCommand"/> that sets up the situation a particular path or event needs, so it can be tested.
/// Each scenario is one of the old -test commands, run by its name without the "test" prefix.
/// </summary>
public sealed class CheatScenario : CompositeCommand
{
  private const string TestPrefix = "test";
  private readonly Command[] _scenarios;

  public CheatScenario(params Command[] scenarios) : base("scenario",
    "Sets up the situation a path or event needs, so it can be tested.")
  {
    _scenarios = scenarios;
  }

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 3);

  protected override void ConfigureVerbs()
  {
    AddVerb("list", "lists every scenario", _ => List());
    foreach (var scenario in _scenarios)
    {
      var captured = scenario;
      AddVerb(GetName(captured), "[args]", captured.Description, (whichPlayer, args) => captured.Execute(whichPlayer, args));
    }
  }

  private string List() =>
    Loc.Get("Scenarios:") + "\n" + string.Join("\n", _scenarios
      .Select(scenario => $"{GetName(scenario)}: {Loc.Get(scenario.Description)}")
      .ToList());

  private static string GetName(Command scenario)
  {
    var commandText = scenario.CommandText;
    return commandText.StartsWith(TestPrefix, StringComparison.Ordinal)
      ? commandText.Substring(TestPrefix.Length)
      : commandText;
  }
}
