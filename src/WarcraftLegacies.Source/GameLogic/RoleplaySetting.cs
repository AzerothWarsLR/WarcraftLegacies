using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Legion.Paths;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Events;
using WarcraftLegacies.Source.Factions.Scourge.Paths;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Tracks whether Roleplay mode is active, sets up the Roleplay starting teams, and gives every
/// <see cref="IHasRoleplayPaths"/> faction its paths when it is.
/// </summary>
public static class RoleplaySetting
{
  private const int TeamCap = 5;
  private const int BlocCap = 6;
  private const int FelHordePlayer = 6;

  private static readonly HashSet<Faction> _factionsWithPaths = new();

  public static bool IsActive { get; private set; }

  public static void Apply()
  {
    if (IsActive)
    {
      return;
    }

    IsActive = true;
    SetupStartingTeams();
    SetupScourgeSplit();
    foreach (var faction in FactionManager.GetAllFactions())
    {
      AddRoleplayPaths(faction);
    }

    FactionManager.FactionRegistered += AddRoleplayPaths;
  }

  private static void SetupStartingTeams()
  {
    var alliance = new Bloc("Alliance");
    alliance.Add(TeamSetup.NorthAlliance);
    alliance.Add(TeamSetup.SouthAlliance);

    player.Create(FelHordePlayer).GetPlayerData().SetTeam(TeamSetup.Legion);

    TeamChanges.Capacity = team => team.Bloc != null ? BlocCap : TeamCap;
    TeamHandicaps.Enable();
  }

  private static void SetupScourgeSplit()
  {
    if (!FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge))
    {
      return;
    }

    if (!FactionManager.TryGetFactionByType<LegionFaction>(out var legion))
    {
      return;
    }

    var split = new ScourgeSplitEvent(scourge, legion, legion.GetQuestByType<QuestSummonLegion>());

    var lichKingBreaksFree = new PathLichKingBreaksFree(split);
    scourge.AddPath(lichKingBreaksFree);
    split.AddSplitPath(lichKingBreaksFree);

    var purgeTheUnworthy = new PathPurgeTheUnworthy(split);
    legion.AddPath(purgeTheUnworthy);
    split.AddSplitPath(purgeTheUnworthy);

    WorldEventManager.Register(split);
  }

  private static void AddRoleplayPaths(Faction faction)
  {
    if (faction is IHasRoleplayPaths hasRoleplayPaths && _factionsWithPaths.Add(faction))
    {
      hasRoleplayPaths.AddRoleplayPaths();
    }
  }
}
