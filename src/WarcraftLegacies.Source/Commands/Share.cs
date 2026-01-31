using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.FactionSystem;

namespace WarcraftLegacies.Source.Commands;

/// <summary>Share control of your units with another player.</summary>
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
          cheater.SetAlliance(faction.Player, alliancetype.SharedControl, true);
        }
      }

      return "Shared control with all factions on your team.";
    }

    if (!FactionManager.TryGetFactionByName(parameters[0], out var targetFaction))
    {
      return $"There is no faction named {parameters[0]}.";
    }

    if (targetFaction.Player == null)
    {
      return $"There is nobody playing the {targetFaction.Name} faction.";
    }

    if (cheaterTeam != targetFaction.Player.GetPlayerData().Team)
    {
      return $"{targetFaction.Name} isn't on your team, so you can't share control with them.";
    }

    cheater.SetAlliance(targetFaction.Player, alliancetype.SharedControl, true);

    return $"Shared control with {targetFaction.Name}.";
  }
}
