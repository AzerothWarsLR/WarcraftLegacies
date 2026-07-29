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

/// <summary>
/// Hard mode's effect on Ironforge: instantly completes the quests that would normally secure Ironforge's
/// home territory (Thelsamar, Dun Morogh, Gnomeregan, and Ironforge itself via Dwarven Dominion).
/// </summary>
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

    // Ironforge normally earns a lot of its early gold from creeps it no longer has to fight through, so
    // compress its starting income window to compensate - delivered over 5 turns instead of the usual 10,
    // same as the other completed factions. Only works because the actual grant is deferred until after the
    // vote sequence concludes - see FactionStartingResources.GrantPending.
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

    // Grim Batol is both a strategic control point (above) and a separate Capital - both need awarding
    // independently, same as Lordaeron's Caer Darrow.
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
        // Capturable neutral Legends/Capitals are awarded, not cleared.
        creep.SetOwner(owner);
        continue;
      }

      // Dispose(), not Kill(), so on-death effects (summons, reincarnation, etc.) don't leave anything behind.
      creep.Dispose();
    }
  }

  // Most quests gate their rewards behind a Tier 3 town hall, which the player would already have built by
  // this point in a normal game - so Hard mode has to grant it directly, since force-completing quests
  // doesn't retroactively upgrade buildings.
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
