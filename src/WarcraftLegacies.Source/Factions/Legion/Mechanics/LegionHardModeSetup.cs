using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Legion.Mechanics;

public static class LegionHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_N0BF_ANTORAN_WASTES,
    UNIT_N0BG_KROKUUN,
    UNIT_N0BH_EREDATH,
    UNIT_N00H_ZUL_DRAK,
    UNIT_N03U_GRIZZLY_HILLS,
    UNIT_N02J_HOWLING_FJORDS
  };

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<LegionFaction>(out var legion) || legion.Player == null)
    {
      return;
    }

    var owner = legion.Player;

    if (legion.StartingGold != null)
    {
      legion.StartingGold.Turns = 5;
    }

    ForceComplete(legion.GetQuestByType<QuestArgusControl>());

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    AllLegends.Neutral.Gundrak.Unit.SetOwner(owner);

    ClearNeutralHostileCreeps(Regions.MonolithNoBuild, owner);
    UpgradeStartingTownHall(owner);

    var krokuunPosition = ControlPointManager.Instance.GetFromUnitType(UNIT_N0BG_KROKUUN).Unit.GetPosition();
    PlaceHeroAtLevel(AllLegends.Legion.Malganis, owner,
      new Point(krokuunPosition.X - 150, krokuunPosition.Y + 150), 5);
    PlaceHeroAtLevel(AllLegends.Legion.Anetheron, owner,
      new Point(krokuunPosition.X + 150, krokuunPosition.Y + 150), 5);
    PlaceHeroAtLevel(AllLegends.Legion.Tichondrius, owner,
      new Point(krokuunPosition.X, krokuunPosition.Y - 150), 4);
  }

  private static void ClearNeutralHostileCreeps(Rectangle region, player owner)
  {
    foreach (var creep in GlobalGroup.EnumUnitsInRect(region))
    {
      if (creep.Owner != player.NeutralAggressive)
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
    var townHall = AllPreplacedWidgets.Units.GetClosest(UNIT_U00F_DORMANT_SPIRE_LEGION_T1, 18825.9f, -31054.4f);
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var citadel = unit.Create(owner, UNIT_U00N_BURNING_CITADEL_LEGION_T3, position.X, position.Y, facing);
    GameStartVoteSequence.PauseUnit(citadel);
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
