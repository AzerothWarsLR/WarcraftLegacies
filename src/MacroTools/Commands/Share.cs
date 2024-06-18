using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;
using System;

namespace MacroTools.Commands
{
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
      var cheaterTeam = cheater.GetTeam(); // Declare cheaterTeam once at the beginning

      // Check if the first parameter is 'all', regardless of any additional parameters
      if (parameters.Length >= 1 && parameters[0].ToLower() == "all")
      {
        var factions = FactionManager.GetAllFactions();

        foreach (var faction in factions)
        {
          if (faction.Player != null && faction.Player.GetTeam() == cheaterTeam)
          {
            SetPlayerAlliance(cheater, faction.Player, ALLIANCE_SHARED_CONTROL, true);
          }
        }

        return $"Shared control with all factions on your team.";
      }

      // If not 'all', then proceed with previous share logic from Yak's code
      if (parameters.Length == 0 || parameters[0].ToLower() == "")
      {
        return $"Please specify a faction name or 'all' to share control.";
      }

      var targetFaction = FactionManager.GetFactionByName(parameters[0]);
      if (targetFaction == null)
        return $"There is no faction named {parameters[0]}.";

      if (targetFaction.Player == null)
        return $"There is nobody playing the {targetFaction.Name} faction.";

      if (cheaterTeam != targetFaction.Player.GetTeam())
        return $"{targetFaction.Name} isn't on your team, so you can't share control with them.";

      SetPlayerAlliance(cheater, targetFaction.Player, ALLIANCE_SHARED_CONTROL, true);

      return $"Shared control with {targetFaction.Name}.";
    }
  }
}
