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
    if (AllLegends.Lordaeron.Uther.Unit != null)
    {
      GameStartVoteSequence.PauseUnit(AllLegends.Lordaeron.Uther.Unit);
    }
  }

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
        creep.SetOwner(owner);
        continue;
      }

      creep.Dispose();
    }
  }

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
