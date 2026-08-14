using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Mechanics;

public static class IronforgeHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_N08T_DRAGONMAW_PORT,
    UNIT_N04V_NORTHERN_HIGHLANDS,
    UNIT_N09F_SOUTHERN_HIGHLANDS,
    UNIT_N03X_GRIM_BATOL,
    UNIT_N016_WETLANDS,
    UNIT_N017_DUN_MODR,
    UNIT_N013_LOCH_MODAN,
    UNIT_N014_DUN_MOROGH,
    UNIT_N02M_NORTHERN_BADLANDS,
    UNIT_N01E_FUSELIGHT,
    UNIT_N02X_SEARING_GORGE
  };

  private static readonly Rectangle[] _sweepRegions =
  {
    Regions.DunmoroghAmbient2,
    Regions.Gnomergan,
    Regions.LochModanMurlocCreepCamp,
    Regions.WetlandAmbient1,
    Regions.WetlandAmbient2,
    Regions.GrimBatolAmbient1,
    Regions.GrimBatolAmbient2,
    Regions.BurningSteppeAmbient2,
    Regions.BurningSteppesAmbient
  };

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<IronforgeFaction>(out var ironforge) || ironforge.Player == null)
    {
      return;
    }

    var owner = ironforge.Player;

    if (ironforge.StartingGold != null)
    {
      ironforge.StartingGold.Turns = 5;
    }

    ForceComplete(ironforge.GetQuestByType<QuestThelsamar>());
    ForceComplete(ironforge.GetQuestByType<QuestDunMorogh>());
    ForceComplete(ironforge.GetQuestByType<QuestGnomeregan>());
    ForceComplete(ironforge.GetQuestByType<QuestDominion>());

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    AllLegends.Neutral.GrimBatol.Unit.SetOwner(owner);

    foreach (var region in _sweepRegions)
    {
      ClearNeutralHostileCreeps(region, owner);
    }

    PlaceHeroAtLevel(AllLegends.Ironforge.Muradin, owner, AllLegends.Ironforge.Thelsamar.Unit.GetPosition(), 5);
    PlaceHeroAtLevel(AllLegends.Ironforge.Magni, owner, AllLegends.Ironforge.GreatForge.Unit.GetPosition(), 3);
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
    var townHall = AllPreplacedWidgets.Units.GetClosest(UNIT_H07E_MINING_COLONY_IRONFORGE_T1,
      Regions.WetlandAmbient2.Center);
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var greatHold = unit.Create(owner, UNIT_H07G_GREAT_HOLD_IRONFORGE_T3, position.X, position.Y, facing);
    GameStartVoteSequence.PauseUnit(greatHold);
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
