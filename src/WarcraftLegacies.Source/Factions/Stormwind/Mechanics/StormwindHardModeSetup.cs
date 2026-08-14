using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Stormwind.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind.Mechanics;

public static class StormwindHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_N00V_DUSKWOOD,
    UNIT_N011_REDRIDGE_MOUNTAINS,
    UNIT_N00Z_ELWYNN_FOREST,
    UNIT_N0A9_BLASTED_LANDS,
    UNIT_N00U_SWAMP_OF_SORROWS,
    UNIT_N00Y_DEADWIND_PASS,
    UNIT_N02I_WESTERN_STRANGLETHORN,
    UNIT_N00X_STRANGLETHORN,
    UNIT_N00W_ZUL_GURUB,
    UNIT_N012_BURNING_STEPPES
  };

  private static readonly Rectangle[] _sweepRegions =
  {
    Regions.StranglethornBaseBuild,
    Regions.ZulGurub,
    Regions.StranglethornAmbient2,
    Regions.BlastedlandAmbient,
    Regions.South_EK_Ships
  };

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<StormwindFaction>(out var stormwind) || stormwind.Player == null)
    {
      return;
    }

    var owner = stormwind.Player;

    if (stormwind.StartingGold != null)
    {
      stormwind.StartingGold.Turns = 5;
    }

    ForceComplete(stormwind.GetQuestByType<QuestDarkshire>());
    ForceComplete(stormwind.GetQuestByType<QuestLakeshire>());
    ForceComplete(stormwind.GetQuestByType<QuestGoldshire>());
    ForceComplete(stormwind.GetQuestByType<QuestStormwindCity>());
    ForceComplete(stormwind.GetQuestByType<QuestConstructionSites>());
    ForceComplete(stormwind.GetQuestByType<QuestNethergarde>());

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    AllLegends.Neutral.Zulgurub.Unit.SetOwner(owner);

    AllPreplacedWidgets.Units.GetClosest(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, 17420, -17900).SetOwner(owner);

    foreach (var region in _sweepRegions)
    {
      ClearNeutralHostileCreeps(region, owner);
    }

    PlaceHeroAtLevel(AllLegends.Stormwind.Varian, owner, AllLegends.Stormwind.StormwindKeep.Unit.GetPosition(), 3);
    PlaceHeroAtLevel(AllLegends.Stormwind.Bolvar, owner, Regions.NethergardeUnlock.Center, 5);
    AllLegends.Stormwind.Bolvar.Unit?.AddItemSafe(Artifacts.CrownOfStormwind.Item);
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
    var townHall = AllPreplacedWidgets.Units.GetClosest(UNIT_H06K_TOWN_HALL_STORMWIND_T1, 7092f, -15613.5f);
    var position = townHall.GetPosition();
    var facing = townHall.Facing;
    townHall.Dispose();
    var castle = unit.Create(owner, UNIT_H06N_CASTLE_STORMWIND_T3, position.X, position.Y, facing);
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
