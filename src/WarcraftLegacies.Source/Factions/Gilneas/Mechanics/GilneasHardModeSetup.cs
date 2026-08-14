using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using System.Linq;
using WarcraftLegacies.Source.Factions.Gilneas.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Gilneas.Mechanics;

public static class GilneasHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_N01D_SILVERPINE_FOREST,
    UNIT_N08M_SOUTHSHORE,
    UNIT_N018_DURNHOLDE,
    UNIT_N01A_HINTERLANDS,
    UNIT_N0EB_JINTHA_ALOR,
    UNIT_N01Z_ARATHI_HIGHLANDS
  };

  private static readonly Rectangle[] _sweepRegions =
  {
    Regions.CaerDarrowShipyard,
    Regions.ShadowfangAmbient,
    Regions.SouthshoreAmbient,
    Regions.SouthshoreAmbient2,
    Regions.SouthshoreAmbient3,
    Regions.SouthshoreAmbient4,
    Regions.SouthshoreAmbient5,
    Regions.HinterlandAmbient1,
    Regions.HinterlandAmbient2
  };

  private const float HeroSpawnFacing = 270;

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<GilneasFaction>(out var gilneas) || gilneas.Player == null)
    {
      return;
    }

    var owner = gilneas.Player;

    if (gilneas.StartingGold != null)
    {
      gilneas.StartingGold.Turns = 5;
    }

    ForceComplete(gilneas.GetQuestByType<QuestShadowfangKeep>());
    ForceComplete(gilneas.GetQuestByType<QuestSouthshoregil>());
    ForceComplete(gilneas.GetQuestByType<QuestGilneasCity>());
    ForceComplete(gilneas.GetQuestByType<QuestDalarangilneas>());
    ForceComplete(gilneas.GetQuestByType<QuestCrowley>());

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    foreach (var region in _sweepRegions)
    {
      ClearNeutralHostileCreeps(region, owner);
    }

    UpgradeStartingTownHall(owner);

    var castlePosition = AllLegends.Gilneas.GilneasCastle.Unit.GetPosition();

    PlaceHeroAtLevel(AllLegends.Gilneas.Genn, owner, new Point(castlePosition.X + 150f, castlePosition.Y), 3);
    PlaceHero(AllLegends.Gilneas.Darius, owner, new Point(castlePosition.X - 150f, castlePosition.Y));
    PlaceHeroAtLevel(AllLegends.Gilneas.Tess, owner, new Point(6901f, -2262f), 4);
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
    var townHall = GlobalGroup.EnumUnitsInRect(Regions.DalaStartPos)
      .First(candidate => candidate.UnitType == UNIT_H01R_TOWN_HALL_GILNEAS_T1);
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var castle = unit.Create(owner, UNIT_H02C_CASTLE_GILNEAS_T3, position.X, position.Y, facing);
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
    hero.ForceCreate(owner, position, HeroSpawnFacing);
    hero.Unit?.SetExperience(HeroLevelExperience.ForLevel(level), true);
    if (hero.Unit != null)
    {
      GameStartVoteSequence.PauseUnit(hero.Unit);
    }
  }

  private static void PlaceHero(LegendaryHero hero, player owner, Point position)
  {
    hero.ForceCreate(owner, position, HeroSpawnFacing);
    if (hero.Unit != null)
    {
      GameStartVoteSequence.PauseUnit(hero.Unit);
    }
  }
}
