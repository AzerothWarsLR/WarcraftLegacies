using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Commands;

/// <summary>
/// Share control of your units with another player.
/// </summary>
public sealed class Share : Command
{
  /// <inheritdoc />
  public override string CommandText => "share";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Normal;

  /// <inheritdoc />
  public override string Description => "Share control of your units with another faction.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var cheaterTeam = cheater.GetPlayerData().Team;

    if (parameters.Length >= 1 && parameters[0].ToLower() == "all")
    {
      var factions = FactionManager.GetAllFactions();

      foreach (var faction in factions)
      {
        if (faction.Player != null && faction.Player.GetPlayerData().Team == cheaterTeam)
        {
          SetPlayerAlliance(cheater, faction.Player, ALLIANCE_SHARED_CONTROL, true);
        }
      }

      return "Shared control with all factions on your team.";
    }

    if (!FactionManager.TryGetFactionByName(parameters[0], out var targetFaction))
    {
      return Loc.Format("There is no faction named {value}.", ("{value}", parameters[0]));
    }

    if (targetFaction.Player == null)
    {
      return Loc.Format("There is nobody playing the {faction} faction.", ("{faction}", targetFaction.Name));
    }

    if (cheaterTeam != targetFaction.Player.GetPlayerData().Team)
    {
      return Loc.Format("{faction} isn't on your team, so you can't share control with them.", ("{faction}", targetFaction.Name));
    }

    SetPlayerAlliance(cheater, targetFaction.Player, ALLIANCE_SHARED_CONTROL, true);

    return Loc.Format("Shared control with {faction}.", ("{faction}", targetFaction.Name));
  }
}
