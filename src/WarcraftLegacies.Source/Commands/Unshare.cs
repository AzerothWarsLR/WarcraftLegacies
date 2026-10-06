using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// Removes shared unit control from another faction or all allied factions.
/// </summary>
public sealed class Unshare : Command
{
  public override string CommandText => "unshare";
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 1);
  public override CommandType Type => CommandType.Normal;
  public override string Description => "Removes shared unit control from a faction or all factions on your team.";

  public override string Execute(player commandUser, params string[] parameters)
  {
    var commandUserTeam = commandUser.GetPlayerData().Team;

    if (parameters.Length >= 1 && parameters[0].ToLower() == "all")
    {
      var factions = FactionManager.GetAllFactions();

      foreach (var faction in factions)
      {
        if (faction.Player != null && faction.Player.GetPlayerData().Team == commandUserTeam)
        {
          SetPlayerAlliance(commandUser, faction.Player, ALLIANCE_SHARED_CONTROL, false);
        }
      }

      return "Removed shared control from all factions on your team.";
    }

    if (!FactionManager.TryGetFactionByName(parameters[0], out var targetFaction))
    {
      return Loc.Format("There is no faction named {value}.", ("{value}", parameters[0]));
    }

    if (targetFaction.Player == null)
    {
      return Loc.Format("There is nobody playing the {faction} faction.", ("{faction}", targetFaction.Name));
    }

    if (commandUserTeam != targetFaction.Player.GetPlayerData().Team)
    {
      return Loc.Format("{faction} isn't on your team, so you can't unshare control with them.", ("{faction}", targetFaction.Name));
    }

    SetPlayerAlliance(commandUser, targetFaction.Player, ALLIANCE_SHARED_CONTROL, false);

    return Loc.Format("Removed shared control from {faction}.", ("{faction}", targetFaction.Name));
  }
}
