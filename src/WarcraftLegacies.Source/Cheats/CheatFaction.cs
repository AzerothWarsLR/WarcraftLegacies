using System;
using System.Linq;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A <see cref="CompositeCommand"/> that manages <see cref="Faction"/>s.
/// </summary>
public sealed class CheatFaction : CompositeCommand
{
  public CheatFaction() : base("faction", "Manages factions.")
  {
  }

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 3);

  protected override void ConfigureVerbs()
  {
    AddVerb("list", "lists every registered faction", List);
    AddVerb("set", "<faction>", "changes your faction", Set);
    AddVerb("control", "<faction|all>", "takes control of a faction, or every player", (whichPlayer, args) => Control(whichPlayer, args, true));
    AddVerb("uncontrol", "<faction|all>", "surrenders control of a faction, or every player", (whichPlayer, args) => Control(whichPlayer, args, false));
    AddVerb("defeat", "<faction>", "defeats and removes a faction", Defeat);
    AddVerb("team", "<faction> <team>", "assigns a faction's player to a team", SetTeam);
  }

  private static string List(player whichPlayer)
  {
    return Loc.Get("Factions:\n") + string.Join("\n", FactionManager.GetAllFactions()
      .Select((faction, i) => $"[{i + 1}] [{CommandTargets.GetFactionKey(faction)}] {faction.Name}")
      .ToList());
  }

  private static string Set(player whichPlayer, string[] args)
  {
    if (args.Length < 1)
    {
      return Loc.Get("Usage: -faction set <faction>");
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var faction, out var error))
    {
      return error;
    }

    whichPlayer.GetPlayerData().Faction = faction;
    return Loc.Format("Successfully changed faction to {faction}.", ("{faction}", faction.Name));
  }

  private static string Control(player whichPlayer, string[] args, bool control)
  {
    if (args.Length < 1)
    {
      return Loc.Get("Usage: -faction control|uncontrol <faction|all>");
    }

    if (args[0] == "all")
    {
      foreach (var player in Util.EnumeratePlayers())
      {
        if (player == whichPlayer)
        {
          continue;
        }

        whichPlayer.SetPlayerAllianceStateFullControl(player, control);
        player.SetPlayerAllianceStateFullControl(whichPlayer, control);
      }

      return Loc.Get(control ? "Took control of all players." : "Surrendered control of all players.");
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var target, out var error))
    {
      return error;
    }

    if (target.Player == null)
    {
      return Loc.Format("Nobody is playing {faction}.", ("{faction}", target.ColoredName));
    }

    target.Player.SetPlayerAllianceStateFullControl(whichPlayer, control);
    whichPlayer.SetPlayerAllianceStateFullControl(target.Player, control);
    return Loc.Format(control ? "Took control of {faction}." : "Surrendered control of {faction}.",
      ("{faction}", target.ColoredName));
  }

  private static string Defeat(player whichPlayer, string[] args)
  {
    if (args.Length < 1)
    {
      return Loc.Get("Usage: -faction defeat <faction>");
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var faction, out var error))
    {
      return error;
    }

    try
    {
      faction.Defeat();
      return Loc.Format("Defeating {faction}.", ("{faction}", faction.Name));
    }
    catch (Exception ex)
    {
      return ex.Message;
    }
  }

  private static string SetTeam(player whichPlayer, string[] args)
  {
    if (args.Length < 2)
    {
      return Loc.Get("Usage: -faction team <faction> <team>");
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var faction, out var error))
    {
      return error;
    }

    var player = faction.Player;
    if (player == null)
    {
      return Loc.Get("The specified faction is not occupied by a player and therefore cannot have a team.");
    }

    if (!CommandTargets.TryResolveTeam(args[1], out var team, out error))
    {
      return error;
    }

    player.GetPlayerData().SetTeam(team);
    return Loc.Format("Set {faction}'s team to {team}.", ("{faction}", faction.Name), ("{team}", team.LocalizedName));
  }
}
