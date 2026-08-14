using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Quelthalas.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Quelthalas.Mechanics;

public static class QuelthalasHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_N01V_ZUL_AMAN,
    UNIT_N01L_EVERSONG_WOODS
  };

  private static readonly Rectangle[] _sweepRegions =
  {
    Regions.ZulAman_trolls,
    Regions.Dreadscar_2
  };

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<QuelthalasFaction>(out var quelthalas) || quelthalas.Player == null)
    {
      return;
    }

    var owner = quelthalas.Player;

    if (quelthalas.StartingGold != null)
    {
      quelthalas.StartingGold.Turns = 5;
    }

    ForceComplete(quelthalas.GetQuestByType<QuestSilvermoon>());
    ForceComplete(quelthalas.GetQuestByType<QuestUnlockSpire>());
    ForceComplete(quelthalas.GetQuestByType<QuestQueldanil>());

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    foreach (var region in _sweepRegions)
    {
      ClearNeutralHostileCreeps(region, owner);
    }

    PlaceHeroAtLevel(AllLegends.Quel.Anasterian, owner, AllLegends.Quel.Silvermoon.Unit.GetPosition(), 3);
    PlaceHeroAtLevel(AllLegends.Quel.Sylvanas, owner, AllLegends.Quel.Spire.Unit.GetPosition(), 4);
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
    var townHall = AllPreplacedWidgets.Units.GetClosest(UNIT_H033_STEADING_QUELTHALAS_T1, 17146.6f, 12466.4f);
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var palace = unit.Create(owner, UNIT_H03T_PALACE_QUELTHALAS_T3, position.X, position.Y, facing);
    GameStartVoteSequence.PauseUnit(palace);
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
