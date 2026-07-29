using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Lordaeron.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Mechanics;

/// <summary>
/// Hard mode's effect on Lordaeron: instantly completes the quests that would normally secure the Lordaeron
/// heartland (Hearthglen, Strahnbrad, Stratholme, the Capital City), and moves Mograine's return up from turn
/// 15 to turn 8. Shores of Northrend - the actual launch of the Northrend campaign - is deliberately left for
/// the player, same as Scourge's Plague and Legion's Argus.
/// </summary>
public static class LordaeronHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_N01F_TIRISFAL_GLADES,
    UNIT_N03H_BRILL,
    UNIT_N01G_LORDAERON_CITY,
    UNIT_N044_HEARTHGLEN,
    UNIT_N01M_STRATHOLME,
    UNIT_N03P_CORIN_S_CROSSING,
    UNIT_N01C_STRAHNBRAD,
    UNIT_N019_ALTERAC_MOUNTAINS,
    UNIT_N01I_CAER_DARROW
  };

  private static readonly Rectangle[] _sweepRegions =
  {
    Regions.AlteracArea,
    Regions.StrahnbradUnlock,
    Regions.Plague_7,
    Regions.DeathknellUnlock,
    Regions.ShadowfangAmbient,
    Regions.LordaeronAmbient1
  };

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<LordaeronFaction>(out var lordaeron) || lordaeron.Player == null)
    {
      return;
    }

    var owner = lordaeron.Player;

    // Lordaeron normally earns a lot of its early gold from creeps it no longer has to fight through, so
    // compress its starting income window to compensate - delivered over 5 turns instead of the usual 10,
    // same as Scourge and Legion. Only works because the actual grant is deferred until after the vote
    // sequence concludes - see FactionStartingResources.GrantPending.
    if (lordaeron.StartingGold != null)
    {
      lordaeron.StartingGold.Turns = 5;
    }

    ForceComplete(lordaeron.GetQuestByType<QuestHearthglen>());
    ForceComplete(lordaeron.GetQuestByType<QuestStrahnbrad>());
    ForceComplete(lordaeron.GetQuestByType<QuestStratholme>());
    CompleteCapitalCity(lordaeron);
    AccelerateMograine(lordaeron);

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    AllLegends.Neutral.Caerdarrow.Unit.SetOwner(owner);

    foreach (var region in _sweepRegions)
    {
      ClearNeutralHostileCreeps(region, owner);
    }

    PlaceHeroAtLevel(AllLegends.Lordaeron.Arthas, owner, AllLegends.Lordaeron.Stratholme.Unit.GetPosition(), 5);
    UpgradeStartingTownHall(owner);
  }

  private static void CompleteCapitalCity(Faction lordaeron)
  {
    ForceComplete(lordaeron.GetQuestByType<QuestCapitalCity>());
    // QuestCapitalCity.OnComplete creates Uther directly via ForceCreate, bypassing the pause-everything
    // sweep that already ran by this point in the vote sequence - pause him explicitly. He's created at
    // level 5 by that same OnComplete, so no extra leveling is needed here.
    if (AllLegends.Lordaeron.Uther.Unit != null)
    {
      GameStartVoteSequence.PauseUnit(AllLegends.Lordaeron.Uther.Unit);
    }
  }

  // Mograine normally returns once QuestMograine's own ObjectiveTurn(15) fires. Hard mode moves that up to
  // turn 8 rather than force-completing him immediately at game start, since the flavour is "he comes back
  // once things get dire", not "already back before the game begins". The original turn-15 objective is left
  // in place - it's a harmless no-op once the quest is already complete.
  private static void AccelerateMograine(Faction lordaeron)
  {
    var mograine = lordaeron.GetQuestByType<QuestMograine>();
    GameTimeManager.RegisterOnTurn(8, () => ForceComplete(mograine));
  }

  private static void ClearNeutralHostileCreeps(Rectangle region, player owner)
  {
    foreach (var creep in GlobalGroup.EnumUnitsInRect(region))
    {
      if (creep.Owner != player.NeutralAggressive)
      {
        continue;
      }

      if (creep.UnitType == UNIT_NFOH_FOUNTAIN_OF_HEALTH)
      {
        continue;
      }

      if (ControlPointManager.Instance.UnitIsControlPoint(creep))
      {
        continue;
      }

      if (CapitalManager.UnitIsCapital(creep))
      {
        // Capturable neutral Legends/Capitals are awarded, not cleared.
        creep.SetOwner(owner);
        continue;
      }

      // Dispose(), not Kill(), so on-death effects (summons, reincarnation, etc.) don't leave anything behind.
      creep.Dispose();
    }
  }

  // Most quests gate their rewards behind a Tier 3 Town Hall (Castle etc.), which the player would already
  // have built by this point in a normal game - so Hard mode has to grant it directly, since force-completing
  // quests doesn't retroactively upgrade buildings.
  private static void UpgradeStartingTownHall(player owner)
  {
    var townHall = AllPreplacedWidgets.Units.GetClosest(UNIT_HTOW_TOWN_HALL_LORDAERON_T1, 13110, 8499);
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var castle = unit.Create(owner, UNIT_HCAS_CASTLE_LORDAERON_T3, position.X, position.Y, facing);
    GameStartVoteSequence.PauseUnit(castle);
  }

  private static void ForceComplete(QuestData quest)
  {
    quest.SuppressCompletionDisplay = true;
    quest.Progress = QuestProgress.Complete;
  }

  private static void AwardControlPoint(int unitType, player owner) =>
    ControlPointManager.Instance.GetFromUnitType(unitType).Unit.SetOwner(owner);

  private static void PlaceHeroAtLevel(LegendaryHero hero, player owner, Point position, int level)
  {
    hero.ForceCreate(owner, position, 270);
    hero.Unit?.SetExperience(HeroLevelExperience.ForLevel(level), true);
    if (hero.Unit != null)
    {
      GameStartVoteSequence.PauseUnit(hero.Unit);
    }
  }
}
