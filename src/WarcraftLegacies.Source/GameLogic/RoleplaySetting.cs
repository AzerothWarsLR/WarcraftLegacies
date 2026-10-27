using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Paths;
using MacroTools.Quests;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Factions.Druids;
using WarcraftLegacies.Source.Factions.Druids.Paths;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.FelHorde.Paths;
using WarcraftLegacies.Source.Factions.FelHorde.Quests;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.Illidari.Paths;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Factions.Kultiras.Events;
using WarcraftLegacies.Source.Factions.Kultiras.Paths;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Legion.Paths;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.Lordaeron.Quests;
using WarcraftLegacies.Source.Factions.OrcishHorde;
using WarcraftLegacies.Source.Factions.OrcishHorde.Paths;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.Quelthalas.Quests;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Events;
using WarcraftLegacies.Source.Factions.Scourge.Paths;
using WarcraftLegacies.Source.Factions.Scourge.Quests;
using WarcraftLegacies.Source.Factions.Sentinels;
using WarcraftLegacies.Source.Factions.Sentinels.Paths;
using WarcraftLegacies.Source.Factions.TaurenTribes;
using WarcraftLegacies.Source.Factions.TaurenTribes.Paths;
using WarcraftLegacies.Source.Factions.Theramore;
using WarcraftLegacies.Source.GameLogic.GrandAlliance;
using WarcraftLegacies.Source.GameLogic.HyjalPact;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>Sets up Roleplay mode: its teams, events and paths.</summary>
public static class RoleplaySetting
{
  private const int TeamCap = 5;
  private const int BlocCap = 6;
  private const int FelHordePlayer = 6;
  private const int DarkPortalEarliestTurn = 5;
  private const int DarkPortalForcedTurn = 7;
  private const int PlagueEarliestTurn = 5;
  private const int PlagueForcedTurn = 8;

  private static readonly HashSet<Faction> _factionsWithPaths = new();
  private static bool _illidariPathsSetUp;

  public static bool IsActive { get; private set; }

  /// <summary>The Pact of Hyjal, once Roleplay mode has set it up.</summary>
  public static PactOfHyjal? HyjalPact { get; private set; }

  /// <summary>The Orcish Horde's fall to chaos, once Roleplay mode has set it up.</summary>
  public static ChaosOrcs? OrcCorruption { get; private set; }

  /// <summary>The Grand Alliance, once Roleplay mode has set it up.</summary>
  public static GrandAllianceEvent? GrandAlliance { get; private set; }

  /// <summary>Magtheridon's chains outside Hellfire Citadel, once Roleplay mode has set them up.</summary>
  public static ChainedMagtheridon? ChainedMagtheridon { get; private set; }

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
    SetupGrandAlliance();
    SetupDaughtersOfTheAlliance();
    SetupBloodOfMannoroth();
    SetupNordrassilsSacrifice();
    SetupFelHorde();
    SetupPlagueEvent();
    SetupIllidariPaths();
    FactionManager.FactionRegistered += _ => SetupIllidariPaths();
    foreach (var faction in FactionManager.GetAllFactions())
    {
      AddRoleplayPaths(faction);
    }

    FactionManager.FactionRegistered += AddRoleplayPaths;
    RemoveReplacedQuests();
  }

  private static void RemoveReplacedQuests()
  {
    if (FactionManager.TryGetFactionByType<LordaeronFaction>(out var lordaeron))
    {
      RemoveQuest(lordaeron, lordaeron.GetQuestByType<QuestScarletCrusade>(), UPGRADE_R0XZ_THE_SCARLET_CRUSADE_LORDAERON_SCARLET);
    }

    if (FactionManager.TryGetFactionByType<QuelthalasFaction>(out var quelthalas))
    {
      quelthalas.RemoveQuest(quelthalas.GetQuestByType<QuestTheBloodElves>());
      quelthalas.RemoveQuest(quelthalas.GetQuestByType<QuestQueensArchive>());
      quelthalas.RemoveQuest(quelthalas.GetQuestByType<QuestForgottenKnowledge>());
      quelthalas.AddQuest(new QuestChampionsOfSilvermoon(AllLegends.Neutral.DraktharonKeep));
      quelthalas.AddQuest(new QuestAzsharasForbiddenTomes(AllLegends.Quel.Rommath));
      quelthalas.AddQuest(new QuestRuinsOfSuramar());
      quelthalas.SetObjectLimit(UNIT_N048_BLOOD_MAGE_QUELTHALAS, 0);
      quelthalas.SetObjectLimit(UPGRADE_R004_SUNFURY_TRAINING_QUEL_THALAS, 0);
    }

    AllLegends.Quel.Sunwell.DeathMessage =
      "The Sunwell has fallen. The fount that sustained the high elves for seven thousand years is gone, and a terrible hunger takes hold of every elf of Quel'thalas.";
  }

  private static void RemoveQuest(Faction faction, QuestData quest, int researchId)
  {
    faction.RemoveQuest(quest);
    faction.SetObjectLimit(researchId, 0);
  }

  private static void SetupStartingTeams()
  {
    var alliance = new Bloc("Alliance");
    alliance.Add(TeamSetup.NorthAlliance);
    alliance.Add(TeamSetup.SouthAlliance);

    player.Create(FelHordePlayer).GetPlayerData().SetTeam(TeamSetup.Legion);

    TeamChanges.Capacity = team => team.Bloc != null ? BlocCap : TeamCap;
    RoleplayFronts.Register();
  }

  private static void SetupGrandAlliance()
  {
    GrandAlliance = new GrandAllianceEvent();
    WorldEventManager.Register(GrandAlliance);
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
    kultiras.AddPath(new PathTheAdmiralsFall());
  }

  private static void SetupDaughtersOfTheAlliance()
  {
    if (!FactionManager.TryGetFactionByType<SentinelsFaction>(out var sentinels))
    {
      return;
    }

    var daughters = new PathDaughtersOfTheAlliance();
    sentinels.AddPath(daughters);
    if (HyjalPact != null)
    {
      HyjalPact.Ended += daughters.Open;
    }

    if (FactionManager.TryGetFactionByType<DruidsFaction>(out var druids))
    {
      druids.ScoreStatusChanged += faction =>
      {
        if (faction.ScoreStatus == ScoreStatus.Defeated)
        {
          daughters.Open();
        }
      };
    }
  }

  private static void SetupBloodOfMannoroth()
  {
    if (!FactionManager.TryGetFactionByType<OrcishHordeFaction>(out var orcs))
    {
      return;
    }

    var fountain = AllLegends.Neutral.FountainOfBlood.Unit;
    if (fountain.Owner == player.NeutralPassive)
    {
      fountain.SetOwner(player.NeutralAggressive);
    }

    var chaosOrcs = new ChaosOrcs(orcs);
    OrcCorruption = chaosOrcs;
    var bloodFades = new PathTheBloodFades(chaosOrcs);
    chaosOrcs.MannorothSlain += bloodFades.Open;
    orcs.AddPath(new PathBloodOfMannoroth(chaosOrcs, drinker =>
    {
      drinker.AddPath(bloodFades);
      OfferTaurenNewAllies();
    }));
  }

  private static void OfferTaurenNewAllies()
  {
    if (!FactionManager.TryGetFactionByType<TaurenTribesFaction>(out var tauren))
    {
      return;
    }

    var taurenPlayer = tauren.Player;
    if (taurenPlayer == null || tauren.ScoreStatus == ScoreStatus.Defeated || IsAlliedWithTheramore(taurenPlayer))
    {
      return;
    }

    var nightElves = new PathFindNewAlliesNightElves();
    var alone = new PathFindNewAlliesAlone();
    tauren.AddPath(nightElves);
    tauren.AddPath(alone);
    nightElves.Open();
    alone.Open();
  }

  private static bool IsAlliedWithTheramore(player whichPlayer)
  {
    if (!FactionManager.TryGetFactionByType<TheramoreFaction>(out var theramore))
    {
      return false;
    }

    var theramorePlayer = theramore.Player;
    return theramorePlayer != null && TeamChanges.AreTeammates(whichPlayer, theramorePlayer);
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

  private static void SetupFelHorde()
  {
    if (!FactionManager.TryGetFactionByType<FelHordeFaction>(out var felHorde))
    {
      return;
    }

    var blackrockSpire = AllLegends.FelHorde.BlackrockSpire;
    var rend = AllLegends.FelHorde.Rend;
    rend.AddUnitDependency(blackrockSpire.Unit);
    felHorde.AddQuest(new QuestDarkHorde(AllLegends.Stormwind.StormwindKeep, blackrockSpire, rend));
    new FelBloodedFury(felHorde);
    felHorde.GetQuestByType<QuestBlackrock>().OutpostWaitsForDarkPortal = true;
    SetupDarkPortal(felHorde);

    var hellfireCitadel = AllLegends.FelHorde.HellfireCitadel.Unit;
    var magtheridon = AllLegends.FelHorde.Magtheridon;
    if (hellfireCitadel != null)
    {
      magtheridon.AddUnitDependency(hellfireCitadel);
      ChainedMagtheridon = new ChainedMagtheridon(felHorde, magtheridon, new Point(hellfireCitadel.X, hellfireCitadel.Y));
    }
  }

  private static void SetupDarkPortal(FelHordeFaction felHorde)
  {
    var normalDarkPortal = felHorde.GetQuestByType<QuestDarkPortal>();
    felHorde.RemoveQuest(normalDarkPortal);
    var darkPortal = normalDarkPortal.WithTurns(DarkPortalEarliestTurn, DarkPortalForcedTurn);
    darkPortal.Global = false;
    felHorde.AddQuest(darkPortal);
    WorldEventManager.Register(new QuestCompletedEvent(felHorde, darkPortal, "The Fel Horde tears open the Dark Portal")
    {
      Name = "The Dark Portal Opens",
      EarliestTurn = DarkPortalEarliestTurn,
      IconName = "DarkPortal",
      Description = "The Dark Portal has been torn open once more. The Fel Horde pours out of Outland into the Blasted Lands."
    });
  }

  private static void SetupPlagueEvent()
  {
    if (!FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge))
    {
      return;
    }

    foreach (var quest in scourge.GetAllQuests())
    {
      if (quest is QuestPlague plague)
      {
        plague.Global = false;
        plague.SetTurns(PlagueEarliestTurn, PlagueForcedTurn);
        WorldEventManager.Register(new QuestCompletedEvent(scourge, plague, "The Cult of the Damned unleashes its plague upon Lordaeron")
        {
          Name = "The Plague of Undeath",
          EarliestTurn = PlagueEarliestTurn,
          IconName = "PlagueBarrel",
          Description = "The Cult of the Damned has unleashed its plague across Lordaeron. The dead rise in the streets and the Scourge marches south."
        });
      }
    }
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

    var summonLegion = legion.GetQuestByType<QuestSummonLegion>();
    legion.AddQuest(new QuestHeraldOfArchimonde(summonLegion, legion));
    scourge.AddQuest(new QuestHeraldOfArchimonde(summonLegion, legion));

    var split = new ScourgeSplitEvent(scourge, legion, summonLegion);

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

    var chainedMagtheridon = ChainedMagtheridon;
    if (chainedMagtheridon == null)
    {
      return;
    }

    _illidariPathsSetUp = true;
    var magtheridon = AllLegends.FelHorde.Magtheridon;
    var lordOfOutland = new PathLordOfOutland(felHorde, magtheridon, chainedMagtheridon);
    var maghar = new PathMaghar(magtheridon);
    var pitLordsBargain = new PathPitLordsBargain(illidari, magtheridon, chainedMagtheridon);
    illidari.AddPath(lordOfOutland);
    felHorde.AddPath(maghar);
    felHorde.AddPath(pitLordsBargain);
    CloseWhenResolved(lordOfOutland, maghar);
    CloseWhenResolved(lordOfOutland, pitLordsBargain);
    CloseWhenResolved(maghar, lordOfOutland);
    CloseWhenResolved(maghar, pitLordsBargain);
    CloseWhenResolved(pitLordsBargain, lordOfOutland);
    CloseWhenResolved(pitLordsBargain, maghar);

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
