using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.FelHorde;
using WarcraftLegacies.Source.Factions.Illidari.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Illidari.Mechanics;

public static class IllidariHardModeSetup
{
  private static readonly int[] _controlPoints =
  {
    UNIT_N00I_BLACK_TEMPLE,
    UNIT_MD04_ALTAR_OF_SHATAR,
    UNIT_MD03_WARDEN_S_CAGE,
    UNIT_N02O_NETHERSTORM
  };

  public static void Setup()
  {
    if (!FactionManager.TryGetFactionByType<IllidariFaction>(out var illidari) || illidari.Player == null)
    {
      return;
    }

    var owner = illidari.Player;

    if (illidari.StartingGold != null)
    {
      illidari.StartingGold.Turns = 5;
    }

    ForceComplete(illidari.GetQuestByType<QuestBrokenIsles>());
    ForceComplete(illidari.GetQuestByType<QuestBlackTemple>());

    AllLegends.FelHorde.BlackTemple.Unit.SetOwner(owner);
    foreach (var unitType in _controlPoints)
    {
      AwardControlPoint(unitType, owner);
    }

    ForceComplete(illidari.GetQuestByType<QuestZangarmarsh>());
    ForceComplete(illidari.GetQuestByType<QuestLostOnes>());

    var blackTemplePosition = AllLegends.FelHorde.BlackTemple.Unit.GetPosition();
    var zangarmarshPosition = Regions.TelredorUnlock.Center;

    PlaceHeroAtLevel(AllLegends.Naga.Illidan, owner,
      new Point(blackTemplePosition.X + 250f, blackTemplePosition.Y + 150f), 270, 6);
    PlaceHero(AllLegends.Naga.Akama, owner,
      new Point(blackTemplePosition.X - 250f, blackTemplePosition.Y + 150f), 270);
    PlaceHero(AllLegends.Naga.Vashj, owner, zangarmarshPosition, 270);
  }

  private static void AwardControlPoint(int unitType, player owner) =>
    ControlPointManager.Instance.GetFromUnitType(unitType).Unit.SetOwner(owner);

  private static void ForceComplete(QuestData quest)
  {
    quest.SuppressCompletionDisplay = true;
    quest.Progress = QuestProgress.Complete;
  }

  private static void PlaceHero(LegendaryHero hero, player owner, Point position, float facing)
  {
    hero.ForceCreate(owner, position, facing);
    if (hero.Unit != null)
    {
      GameStartVoteSequence.PauseUnit(hero.Unit);
    }
  }

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
