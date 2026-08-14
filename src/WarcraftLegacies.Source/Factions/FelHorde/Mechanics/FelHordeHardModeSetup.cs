using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.FelHorde.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FelHorde.Mechanics;

public static class FelHordeHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_MD01_WEST_ZANGARMARSH,
    UNIT_N00B_NAGRAND,
    UNIT_N0CV_HALAAR,
    UNIT_N02T_TEROKKAR_FOREST,
    UNIT_N02N_BLADE_S_EDGE_MOUNTAINS,
    UNIT_N07Q_AREA_52,
    UNIT_N0CW_FARAHLON
  };

  private static readonly Rectangle[] _sweepRegions =
  {
    Regions.HellfireUnlock,
    Regions.ShadowmoonBaseUnlock,
    Regions.BlackrockUnlock,
    Regions.DarkPortalUnlock,
    Regions.InstanceOutland
  };

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<FelHordeFaction>(out var felHorde) || felHorde.Player == null)
    {
      return;
    }

    var owner = felHorde.Player;

    if (felHorde.StartingGold != null)
    {
      felHorde.StartingGold.Turns = 5;
    }

    ForceComplete(felHorde.GetQuestByType<QuestHellfireCitadel>());
    ForceComplete(felHorde.GetQuestByType<QuestRuinsofShadowmoon>());
    ForceComplete(felHorde.GetQuestByType<QuestBlackrock>());
    ForceComplete(felHorde.GetQuestByType<QuestDarkPortal>());

    owner.SetTechResearched(UPGRADE_R090_ACTIVATE_THE_BLACKROCK_CLAN_FEL, 1);
    owner.SetTechResearched(UPGRADE_R02C_THE_DARK_PORTAL_FEL_HORDE, 1);

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    AllLegends.FelHorde.BlackrockSpire.Unit.SetOwner(owner);

    AllPreplacedWidgets.Units.GetClosest(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, 3707, -26029).SetOwner(owner);

    foreach (var region in _sweepRegions)
    {
      ClearNeutralHostileCreeps(region, owner);
    }

    UpgradeStartingTownHall(owner);

    var hellfirePosition = AllLegends.FelHorde.HellfireCitadel.Unit.GetPosition();
    var blackrockPosition = AllLegends.FelHorde.BlackrockSpire.Unit.GetPosition();

    PlaceHeroAtLevel(AllLegends.FelHorde.Magtheridon, owner,
      new Point(hellfirePosition.X + 300f, hellfirePosition.Y + 150f), 270, 6);
    PlaceHeroAtLevel(AllLegends.FelHorde.Kargath, owner,
      new Point(hellfirePosition.X - 300f, hellfirePosition.Y + 150f), 270, 5);
    PlaceHeroAtLevel(AllLegends.FelHorde.Rend, owner,
      new Point(blackrockPosition.X + 300f, blackrockPosition.Y), 270, 5);
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
    var nagrandPosition = ControlPointManager.Instance.GetFromUnitType(UNIT_N00B_NAGRAND).Unit.GetPosition();
    var previousMaxDistanceToFind = AllPreplacedWidgets.MaximumDistanceToFind;
    AllPreplacedWidgets.MaximumDistanceToFind = 4000f;
    var townHall = AllPreplacedWidgets.Units.GetClosest(UNIT_O02Y_GREAT_HALL_FEL_T1, nagrandPosition);
    AllPreplacedWidgets.MaximumDistanceToFind = previousMaxDistanceToFind;
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var fortress = unit.Create(owner, UNIT_O030_FORTRESS_FEL_T3, position.X, position.Y, facing);
    GameStartVoteSequence.PauseUnit(fortress);
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
