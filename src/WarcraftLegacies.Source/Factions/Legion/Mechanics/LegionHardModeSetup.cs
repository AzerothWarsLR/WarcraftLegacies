using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Legion.Mechanics;

/// <summary>
/// Hard mode's effect on the Legion: instantly completes Argus, the only quest needed to bring the Legion to
/// "ready to invade Azeroth" status.
/// </summary>
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

    // Legion normally earns a lot of its early gold from creeps it no longer has to fight through, so
    // compress its starting income window to compensate - delivered over 5 turns instead of the usual 10,
    // same as Scourge. Only works because the actual grant is deferred until after the vote sequence
    // concludes - see FactionStartingResources.GrantPending.
    if (legion.StartingGold != null)
    {
      legion.StartingGold.Turns = 5;
    }

    ForceComplete(legion.GetQuestByType<QuestArgusControl>());

    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    // Gundrak sits inside the region Scourge's own Hard mode sweeps for capturable capitals, but it actually
    // belongs to Legion - this has to run after ScourgeHardModeSetup to win ownership back from it. See
    // HardModeSetting.ApplyWithoutTechUnlocks for the ordering.
    AllLegends.Neutral.Gundrak.Unit.SetOwner(owner);

    ClearNeutralHostileCreeps(Regions.MonolithNoBuild, owner);

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
    if (hero.Unit != null)
    {
      GameStartVoteSequence.PauseUnit(hero.Unit);
    }
  }
}
