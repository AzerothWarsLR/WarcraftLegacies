using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Dalaran.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran.Mechanics;

public static class DalaranHardModeSetup
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

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<DalaranFaction>(out var dalaran) || dalaran.Player == null)
    {
      return;
    }

    var owner = dalaran.Player;

    if (dalaran.StartingGold != null)
    {
      dalaran.StartingGold.Turns = 5;
    }

    ForceComplete(dalaran.GetQuestByType<QuestShadowfang>());
    ForceComplete(dalaran.GetQuestByType<QuestSouthshore>());
    ForceComplete(dalaran.GetQuestByType<QuestGilneas>());
    ForceComplete(dalaran.GetQuestByType<QuestDalaran>());

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    foreach (var region in _sweepRegions)
    {
      ClearNeutralHostileCreeps(region, owner);
    }

    PlaceHeroAtLevel(AllLegends.Dalaran.Jaina, owner, AllLegends.Dalaran.Shadowfang.Unit.GetPosition(), 4);
    PlaceHeroAtLevel(AllLegends.Dalaran.Antonidas, owner, AllLegends.Dalaran.Dalaran.Unit.GetPosition(), 5);
    UpgradeStartingTownHall(owner);
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
    var townHall = AllPreplacedWidgets.Units.GetClosest(UNIT_H065_REFUGE_DALARAN_T1, Regions.DalaStartPos.Center);
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var observatory = unit.Create(owner, UNIT_H068_OBSERVATORY_DALARAN_T3, position.X, position.Y, facing);
    GameStartVoteSequence.PauseUnit(observatory);
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
