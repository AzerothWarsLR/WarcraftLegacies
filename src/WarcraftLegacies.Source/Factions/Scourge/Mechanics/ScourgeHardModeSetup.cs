using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Scourge.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Scourge.Mechanics;

/// <summary>
/// Hard mode's effect on the Scourge: instantly completes the quests that would normally bring it to "ready to
/// invade Lordaeron" status by turn 10-12, so an engagement can start right away instead. The Plague itself
/// (<see cref="QuestPlague"/>) is deliberately left for the player to trigger.
/// </summary>
public static class ScourgeHardModeSetup
{
  private static readonly int[] _unclaimedNorthrendControlPoints =
  {
    UNIT_N02S_STORM_PEAKS,
    UNIT_N02R_CRYSTALSONG_FOREST,
    UNIT_N02Q_DRAGONBLIGHT,
    UNIT_N00F_SHOLAZAR_BASIN,
    UNIT_N07Y_VENTURE_BAY
  };

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge) || scourge.Player == null)
    {
      return;
    }

    var owner = scourge.Player;

    CompleteCultOfTheDamned(scourge, owner);
    CompleteDrakUnlock(scourge, owner);
    CompleteEnKilahUnlock(scourge, owner);
    CompleteSpiderWar(scourge, owner);
    CompleteSapphiron(scourge, owner);
    AwardRemainingNorthrendControlPoints(owner);
    ClearNeutralHostileCreeps(Regions.Northrend_Ambiance, owner);
  }

  private static void CompleteCultOfTheDamned(Faction scourge, player owner)
  {
    ForceComplete(scourge.GetQuestByType<QuestCultoftheDamned>());
    PlaceHeroAtLevel(AllLegends.Scourge.Rivendare, owner, Regions.FTSummon.Center, 4);
  }

  private static void CompleteDrakUnlock(Faction scourge, player owner)
  {
    ForceComplete(scourge.GetQuestByType<QuestDrakUnlock>());
    AwardControlPoint(UNIT_N030_DRAK_THARON_KEEP, owner);
    PlaceHeroAtLevel(AllLegends.Scourge.Kelthuzad, owner, Regions.DrakUnlock.Center, 6);
  }

  private static void CompleteEnKilahUnlock(Faction scourge, player owner)
  {
    ForceComplete(scourge.GetQuestByType<QuestEnKilahUnlock>());
    AwardControlPoint(UNIT_N09H_EN_KILAH, owner);
  }

  private static void CompleteSpiderWar(Faction scourge, player owner)
  {
    ForceComplete(scourge.GetQuestByType<QuestSpiderWar>());
    AwardControlPoint(UNIT_N08D_ICECROWN_GLACIER, owner);
    AwardControlPoint(UNIT_N00G_BOREAN_TUNDRA, owner);
    AwardControlPoint(UNIT_N09H_EN_KILAH, owner);
    // Anub'arak isn't gated behind a specific quest research, but Spider War/En'Kilah are his Nerubian home
    // turf, so he's preplaced here.
    PlaceHeroAtLevel(AllLegends.Scourge.Anubarak, owner, Regions.EnKilahUnlock.Center, 5);
  }

  private static void CompleteSapphiron(Faction scourge, player owner)
  {
    // QuestSapphiron.OnComplete only spawns the reanimated Sapphiron if a real unit dealt the killing blow,
    // which won't be true here - so that part is replicated manually instead of relying on it. Dispose(),
    // not Kill(), so no on-death effects (summons, reincarnation, etc.) trigger.
    AllPreplacedWidgets.Units.Get(UNIT_UBDR_SAPPHIRON_CREEP).Dispose();
    unit.Create(owner, UNIT_UBDD_SAPPHIRON_SCOURGE_DEMI, -2600, 18800, 300);
    ForceComplete(scourge.GetQuestByType<QuestSapphiron>());
  }

  private static void AwardRemainingNorthrendControlPoints(player owner)
  {
    foreach (var unitType in _unclaimedNorthrendControlPoints)
    {
      AwardControlPoint(unitType, owner);
    }
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
        // Capturable neutral Legends/Capitals (e.g. Gundrak, The Nexus) are awarded, not cleared.
        creep.SetOwner(owner);
        continue;
      }

      // Dispose(), not Kill(), so on-death effects (summons, reincarnation, etc.) don't leave anything behind.
      creep.Dispose();
    }
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
  }
}
