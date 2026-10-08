using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Paths;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.FelHorde.Paths;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.Illidari.Paths;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Legion.Paths;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Events;
using WarcraftLegacies.Source.Factions.Scourge.Paths;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

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
  private static bool _outlandSetUp;

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
    SetupOutland();
    FactionManager.FactionRegistered += _ => SetupOutland();
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

  /// <summary>
  /// Sets up the Outland paths once both the Fel Horde and the Illidari exist. The Illidari are picked from a choice, so
  /// they may only register after Roleplay starts.
  /// </summary>
  private static void SetupOutland()
  {
    if (_outlandSetUp)
    {
      return;
    }

    if (!FactionManager.TryGetFactionByType<FelHordeFaction>(out var felHorde))
    {
      return;
    }

    if (!FactionManager.TryGetFactionByType<IllidariFaction>(out var illidari))
    {
      return;
    }

    _outlandSetUp = true;
    var magtheridon = AllLegends.FelHorde.Magtheridon;
    var lordOfOutland = new PathLordOfOutland(felHorde, magtheridon);
    var maghar = new PathMaghar(magtheridon);
    illidari.AddPath(lordOfOutland);
    felHorde.AddPath(maghar);
    CloseWhenResolved(lordOfOutland, maghar);
    CloseWhenResolved(maghar, lordOfOutland);
  }

  /// <summary>Closes <paramref name="rival"/> once <paramref name="path"/> has been taken or declined.</summary>
  private static void CloseWhenResolved(FactionPath path, FactionPath rival)
  {
    path.StateChanged += changed =>
    {
      if (changed.State == PathState.Taken || changed.State == PathState.Declined)
      {
        rival.Close();
      }
    };
  }

  private static void AddRoleplayPaths(Faction faction)
  {
    if (faction is IHasRoleplayPaths hasRoleplayPaths && _factionsWithPaths.Add(faction))
    {
      hasRoleplayPaths.AddRoleplayPaths();
    }
  }
}
