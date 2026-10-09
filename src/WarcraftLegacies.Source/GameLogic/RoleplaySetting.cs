using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Paths;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Factions.Druids;
using WarcraftLegacies.Source.Factions.Druids.Paths;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.FelHorde.Paths;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.Illidari.Paths;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Kultiras.Events;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Legion.Paths;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Events;
using WarcraftLegacies.Source.Factions.Scourge.Paths;
using WarcraftLegacies.Source.Factions.Sentinels;
using WarcraftLegacies.Source.Factions.Sentinels.Paths;
using WarcraftLegacies.Source.GameLogic.HyjalPact;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>Sets up Roleplay mode: its teams, events and paths.</summary>
public static class RoleplaySetting
{
  private const int TeamCap = 5;
  private const int BlocCap = 6;
  private const int FelHordePlayer = 6;

  private static readonly HashSet<Faction> _factionsWithPaths = new();
  private static bool _illidariPathsSetUp;

  public static bool IsActive { get; private set; }

  /// <summary>The Pact of Hyjal, once Roleplay mode has set it up.</summary>
  public static PactOfHyjal? HyjalPact { get; private set; }

  /// <summary>Daelin's Vengeance, once Roleplay mode has set it up.</summary>
  public static DaelinsVengeanceEvent? DaelinsVengeance { get; private set; }

  public static void Apply()
  {
    if (IsActive)
    {
      return;
    }

    IsActive = true;
    SetupStartingTeams();
    SetupScourgeSplit();
    SetupHyjalPact();
    SetupDaelinsVengeance();
    SetupNordrassilsSacrifice();
    SetupIllidariPaths();
    FactionManager.FactionRegistered += _ => SetupIllidariPaths();
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
    TeamHandicaps.AreRivals = RoleplayFronts.AreRivals;
    TeamHandicaps.Enable();
  }

  private static void SetupHyjalPact()
  {
    if (!FactionManager.TryGetFactionByType<LegionFaction>(out var legion))
    {
      return;
    }

    HyjalPact = new PactOfHyjal(legion, legion.GetQuestByType<QuestSummonLegion>());
    WorldEventManager.Register(HyjalPact);
  }

  private static void SetupDaelinsVengeance()
  {
    if (!FactionManager.TryGetFactionByType<KultirasFaction>(out var kultiras))
    {
      return;
    }

    DaelinsVengeance = new DaelinsVengeanceEvent(kultiras);
    WorldEventManager.Register(DaelinsVengeance);
  }

  private static void SetupNordrassilsSacrifice()
  {
    if (!FactionManager.TryGetFactionByType<LegionFaction>(out var legion))
    {
      return;
    }

    if (!FactionManager.TryGetFactionByType<DruidsFaction>(out var druids))
    {
      return;
    }

    druids.AddPath(new PathNordrassilsSacrifice(legion, legion.GetQuestByType<QuestConsumeTree>()));
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

  /// <summary>Sets up the paths involving the Illidari once they have been picked.</summary>
  private static void SetupIllidariPaths()
  {
    if (_illidariPathsSetUp)
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

    if (!FactionManager.TryGetFactionByType<SentinelsFaction>(out var sentinels))
    {
      return;
    }

    _illidariPathsSetUp = true;
    var magtheridon = AllLegends.FelHorde.Magtheridon;
    var lordOfOutland = new PathLordOfOutland(felHorde, magtheridon);
    var maghar = new PathMaghar(magtheridon);
    illidari.AddPath(lordOfOutland);
    felHorde.AddPath(maghar);
    CloseWhenResolved(lordOfOutland, maghar);
    CloseWhenResolved(maghar, lordOfOutland);

    var betrayersRedemption = new PathBetrayersRedemption();
    illidari.AddPath(betrayersRedemption);
    var illidanReturnedToAlliance = new ObjectiveTriggered("Illidan has returned to the Night Elves") { ShowsInQuestLog = false };
    var illidanReturnedToHunt = new ObjectiveTriggered("Illidan has returned to the Night Elves") { ShowsInQuestLog = false };
    var wardensAlliance = new PathWardensVengeanceAlliance(illidanReturnedToAlliance);
    var wardensAlone = new PathWardensVengeanceAlone(illidanReturnedToHunt);
    sentinels.AddPath(wardensAlliance);
    sentinels.AddPath(wardensAlone);
    CloseWhenResolved(wardensAlliance, wardensAlone);
    CloseWhenResolved(wardensAlone, wardensAlliance);
    betrayersRedemption.StateChanged += path =>
    {
      if (path.State == PathState.Taken)
      {
        illidanReturnedToAlliance.Trigger();
        illidanReturnedToHunt.Trigger();
      }
    };
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
