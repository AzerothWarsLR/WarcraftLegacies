using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Kultiras.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Kultiras.Mechanics;

public static class KultirasHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_N0BX_TIRAGARDE_SOUND,
    UNIT_N0BW_STORMSONG_VALLEY,
    UNIT_N0BV_DRUSTVAR,
    UNIT_N00L_BOOTY_BAY,
    UNIT_N01W_BORALUS,
    UNIT_N07L_BALOR,
    UNIT_N03W_JAGUERO_ISLE
  };

  private static readonly (int UnitType, float X, float Y, float Facing)[] _outpostBuildings =
  {
    (UNIT_H062_TOWN_HALL_KULTIRAS_T1, 7285.9f, -16815.5f, 74.1f),
    (UNIT_H06R_GARRISON_KULTIRAS_BARRACKS, 6548.8f, -16032.0f, 62.4f),
    (UNIT_H06R_GARRISON_KULTIRAS_BARRACKS, 6898.8f, -16032.0f, 62.4f),
    (UNIT_H07P_WORKSHOP_KULTIRAS_SPECIALIST, 7638.5f, -16665.9f, 89.4f),
    (UNIT_H07Q_SCHOOL_OF_THE_TIDES_KULTIRAS_MAGIC, 8148.2f, -16666.9f, 85.3f)
  };

  private static readonly Point _daelinSpawnPoint = new(7432.2f, -16347.9f);
  private static readonly Point _katherineSpawnPoint = new(7532.2f, -16347.9f);
  private const float HeroSpawnFacing = 85.6f;

  private static readonly Rectangle[] _sweepRegions =
  {
    Regions.BalorAmbient,
    Regions.Kultiras,
    Regions.StranglethornAmbient2
  };

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<KultirasFaction>(out var kultiras) || kultiras.Player == null)
    {
      return;
    }

    var owner = kultiras.Player;

    if (kultiras.StartingGold != null)
    {
      kultiras.StartingGold.Turns = 5;
    }

    var questUnlockShip = kultiras.GetQuestByType<QuestStranglethornExpedition>();
    questUnlockShip.SkipDialog = true;
    questUnlockShip.SuppressCompletionDisplay = true;

    ForceComplete(kultiras.GetQuestByType<QuestBoralus>());
    ForceComplete(kultiras.GetQuestByType<QuestWestfallOutpost>());
    ForceComplete(kultiras.GetQuestByType<QuestHighBank>());

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    AllLegends.Kultiras.LegendBoralus.Unit.SetOwner(owner);

    foreach (var region in _sweepRegions)
    {
      ClearNeutralHostileCreeps(region, owner);
    }

    UpgradeStartingTownHall(owner);

    foreach (var building in _outpostBuildings)
    {
      var outpostBuilding = unit.Create(owner, building.UnitType, building.X, building.Y, building.Facing);
      GameStartVoteSequence.PauseUnit(outpostBuilding);
    }

    PlaceHeroAtLevel(AllLegends.Kultiras.LegendAdmiral, owner, _daelinSpawnPoint, HeroSpawnFacing, 5);
    PlaceHeroAtLevel(AllLegends.Kultiras.LegendKatherine, owner, _katherineSpawnPoint, HeroSpawnFacing, 4);
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
    var townHall = AllPreplacedWidgets.Units.GetClosest(UNIT_H062_TOWN_HALL_KULTIRAS_T1, Regions.BalorAmbient.Center);
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var castle = unit.Create(owner, UNIT_H06I_CASTLE_KULTIRAS_T3, position.X, position.Y, facing);
    GameStartVoteSequence.PauseUnit(castle);
  }

  private static void ForceComplete(QuestData quest)
  {
    quest.SuppressCompletionDisplay = true;
    quest.Progress = QuestProgress.Complete;
  }

  private static void AwardControlPoint(int unitType, player owner) =>
    ControlPointManager.Instance.GetFromUnitType(unitType).Unit.SetOwner(owner);

  private static void PlaceHeroAtLevel(LegendaryHero hero, player owner, Point position, float facing, int level)
  {
    hero.ForceCreate(owner, position, facing);
    hero.Unit?.SetExperience(HeroLevelExperience.ForLevel(level), true);
    if (hero.Unit != null)
    {
      GameStartVoteSequence.PauseUnit(hero.Unit);
    }
  }
}
