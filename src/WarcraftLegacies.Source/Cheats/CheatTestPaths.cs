using System.Linq;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Gives the player's faction some test paths so the Paths menu can be tried out.
/// </summary>
public sealed class CheatTestPaths : Command
{
  /// <inheritdoc />
  public override string CommandText => "testpaths";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Gives your faction some test paths to try out the Paths menu, plus its Roleplay paths if Roleplay mode is off.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var faction = cheater.GetPlayerData().Faction;
    if (faction == null)
    {
      return "You don't have a faction.";
    }

    if (!RoleplaySetting.IsActive && faction is IHasRoleplayPaths hasRoleplayPaths)
    {
      hasRoleplayPaths.AddRoleplayPaths();
    }

    faction.AddPath(new TestPath(500)
    {
      Name = "Path of Testing",
      IconName = "Sacrifice",
      Description = "Available straight away. Takes 15 seconds to go through once accepted, and gives 500 gold.",
      CommitDuration = 15
    });

    faction.AddPath(new TestPath(1000, new ObjectiveTurn(GameTimeManager.Turn + 1))
    {
      Name = "Path of Patience",
      IconName = "Charm",
      Description = "Unlocks next turn, then closes if it isn't accepted within 45 seconds. Gives 1000 gold.",
      DeclineDescription = "Nothing happens, this one just tests the Decline button.",
      OfferDuration = 45,
      CommitDuration = 10
    });

    if (faction is LordaeronFaction)
    {
      faction.AddPath(new TestPath(250)
      {
        Name = "Path of the Palace",
        IconName = "Castle",
        Description = "Only available while you control the Capital Palace. Goes back to locked if you lose it. Gives 250 gold.",
        CommitDuration = 20
      }.RequireToStayTrue(new ObjectiveControlCapital(AllLegends.Lordaeron.CapitalPalace, false)));
    }

    var otherTeam = FactionManager.GetAllTeams().FirstOrDefault(x => x.Size > 0 && !x.Contains(cheater));
    if (otherTeam != null)
    {
      faction.AddPath(new TestTeamPath(otherTeam)
      {
        Name = "Path of Betrayal",
        IconName = "Possession",
        Description = $"Available straight away. Leaves your team and joins the {otherTeam.Name}, with a ceasefire before your old allies become enemies.",
        CommitDuration = 10
      });
    }

    faction.AddPath(new TestTeamPath(null)
    {
      Name = "Path of Solitude",
      IconName = "Invisibility",
      Description = "Available straight away. Leaves your team to stand alone, with a ceasefire before your old allies become enemies.",
      CommitDuration = 10
    });

    return $"Added test paths to {faction.Name}.";
  }
}
