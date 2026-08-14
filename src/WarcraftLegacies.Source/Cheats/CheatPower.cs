using System.Linq;
using MacroTools.Commands;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A <see cref="CompositeCommand"/> that manages a faction's <see cref="MacroTools.Factions.Power"/>s.
/// </summary>
public sealed class CheatPower : CompositeCommand
{
  public CheatPower() : base("power", "Manages faction powers.")
  {
  }

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 3);

  protected override void ConfigureVerbs()
  {
    AddVerb("list", "<faction>", "lists a faction's powers", List);
    AddVerb("remove", "<faction> <key>", "removes a faction's power", Remove);
  }

  private static string List(player whichPlayer, string[] args)
  {
    if (args.Length < 1)
    {
      return "Usage: -power list <faction>";
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var faction, out var error))
    {
      return error;
    }

    return $"Powers for {faction.Name}:\n" + string.Join("\n", faction.GetAllPowers()
      .Select((power, i) => $"[{i + 1}] [{CommandTargets.GetPowerKey(power)}] {power.Name}")
      .ToList());
  }

  private static string Remove(player whichPlayer, string[] args)
  {
    if (args.Length < 2)
    {
      return "Usage: -power remove <faction> <key>";
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var faction, out var error))
    {
      return error;
    }

    if (!CommandTargets.TryResolvePower(faction, args[1], out var power, out error))
    {
      return error;
    }

    faction.RemovePower(power);
    return $"Removed Power {power.Name}.";
  }
}
