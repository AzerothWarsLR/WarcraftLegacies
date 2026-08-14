using System.Linq;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Sunfury.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sunfury.Mechanics;

public static class SunfuryHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_N07Q_AREA_52,
    UNIT_N0CW_FARAHLON,
    UNIT_N02O_NETHERSTORM,
    UNIT_N00I_BLACK_TEMPLE,
    UNIT_MD04_ALTAR_OF_SHATAR,
    UNIT_MD03_WARDEN_S_CAGE
  };

  private static readonly Rectangle[] _ecoDomes =
  {
    Regions.Biodome1,
    Regions.Biodome2,
    Regions.Biodome3
  };

  private const float HeroSpawnFacing = 270;

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<SunfuryFaction>(out var sunfury) || sunfury.Player == null)
    {
      return;
    }

    var owner = sunfury.Player;

    if (sunfury.StartingGold != null)
    {
      sunfury.StartingGold.Turns = 5;
    }

    ForceComplete(sunfury.GetQuestByType<QuestTempestKeep>());
    ForceComplete(sunfury.GetQuestByType<QuestArea52>());
    ForceComplete(sunfury.GetQuestByType<QuestUpperNetherstorm>());
    ForceComplete(sunfury.GetQuestByType<QuestSolarian>());

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    AllLegends.FelHorde.BlackTemple.Unit.SetOwner(owner);

    foreach (var ecoDome in _ecoDomes)
    {
      var arboretum = unit.Create(owner, UNIT_H0C7_ARBORETUM_SUNFURY_FARM, ecoDome.Center.X, ecoDome.Center.Y,
        HeroSpawnFacing);
      GameStartVoteSequence.PauseUnit(arboretum);
    }

    UpgradeStartingTownHall(owner);

    var tempestKeepCenter = Regions.TempestKeep.Center;

    PlaceHeroAtLevel(AllLegends.Sunfury.Kael, owner, tempestKeepCenter, HeroSpawnFacing, 6);
    PlaceHeroAtLevel(AllLegends.Sunfury.Solarian, owner,
      new Point(tempestKeepCenter.X + 150f, tempestKeepCenter.Y), HeroSpawnFacing, 5);
    AllLegends.Sunfury.Solarian.Unit?.AddItemSafe(Artifacts.EssenceofMurmur.Item);
    PlaceHeroAtLevel(AllLegends.Sunfury.Pathaleon, owner,
      new Point(tempestKeepCenter.X - 150f, tempestKeepCenter.Y), HeroSpawnFacing, 5);
  }

  private static void UpgradeStartingTownHall(player owner)
  {
    var townHall = GlobalGroup.EnumUnitsInRect(Regions.SunfuryStartingPosition)
      .First(candidate => candidate.UnitType == UNIT_H02P_HOLDING_SUNFURY_T1);
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var sanctuary = unit.Create(owner, UNIT_H0C5_SANCTUARY_SUNFURY_T3, position.X, position.Y, facing);
    GameStartVoteSequence.PauseUnit(sanctuary);
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
