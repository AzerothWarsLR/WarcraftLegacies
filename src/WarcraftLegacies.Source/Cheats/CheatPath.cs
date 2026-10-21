using System.Linq;
using MacroTools.Commands;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Paths;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A <see cref="CompositeCommand"/> that manages a faction's paths.
/// </summary>
public sealed class CheatPath : CompositeCommand
{
  public CheatPath() : base("path", "Manages faction paths.")
  {
  }

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 3);

  protected override void ConfigureVerbs()
  {
    AddVerb("list", "<faction>", "lists a faction's paths", List);
    AddVerb("unlock", "<faction> <key>", "makes a faction's path available, ignoring its requirements", Unlock);
    AddVerb("take", "<faction> <key>", "makes a faction's path available and accepts it for them", Take);
    AddVerb("close", "<faction> <key>", "closes a faction's path", Close);
  }

  private static string List(player whichPlayer, string[] args)
  {
    if (args.Length < 1)
    {
      return Loc.Get("Usage: -path list <faction>");
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var faction, out var error))
    {
      return error;
    }

    return Loc.Format("Paths for {faction}:", ("{faction}", faction.Name)) + "\n" + string.Join("\n", faction.GetAllPaths()
      .Select((path, i) => $"[{i + 1}] [{CommandTargets.GetPathKey(path)}] {path.Name} - {path.State}")
      .ToList());
  }

  private static string Unlock(player whichPlayer, string[] args)
  {
    var path = ResolvePath(args, "unlock", out var faction, out var error);
    if (path == null)
    {
      return error;
    }

    path.ForceAvailable();
    return Loc.Format("{path} is now {state} for {faction}.",
      ("{path}", path.Name), ("{state}", path.State.ToString()), ("{faction}", faction!.Name));
  }

  private static string Take(player whichPlayer, string[] args)
  {
    var path = ResolvePath(args, "take", out var faction, out var error);
    if (path == null)
    {
      return error;
    }

    var owner = faction!.Player;
    if (owner == null)
    {
      return Loc.Format("Nobody is playing {faction}.", ("{faction}", faction.Name));
    }

    path.ForceAvailable();
    path.Accept(owner);
    return Loc.Format("{faction} accepted {path}; it is now {state}.",
      ("{faction}", faction.Name), ("{path}", path.Name), ("{state}", path.State.ToString()));
  }

  private static string Close(player whichPlayer, string[] args)
  {
    var path = ResolvePath(args, "close", out var faction, out var error);
    if (path == null)
    {
      return error;
    }

    path.Close();
    return Loc.Format("{path} is now {state} for {faction}.",
      ("{path}", path.Name), ("{state}", path.State.ToString()), ("{faction}", faction!.Name));
  }

  private static FactionPath? ResolvePath(string[] args, string verb, out Faction? faction, out string error)
  {
    faction = null;
    if (args.Length < 2)
    {
      error = Loc.Format("Usage: -path {verb} <faction> <key>", ("{verb}", verb));
      return null;
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var resolvedFaction, out error))
    {
      return null;
    }

    faction = resolvedFaction;
    if (!CommandTargets.TryResolvePath(resolvedFaction, args[1], out var path, out error))
    {
      return null;
    }

    return path;
  }
}
