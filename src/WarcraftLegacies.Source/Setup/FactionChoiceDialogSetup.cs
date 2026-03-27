using MacroTools.Factions.Choices;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Draenei;
using WarcraftLegacies.Source.Factions.Frostwolf;
using WarcraftLegacies.Source.Factions.Gilneas;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.Sentinels;
using WarcraftLegacies.Source.Factions.Sunfury;
using WarcraftLegacies.Source.Factions.Warsong;

namespace WarcraftLegacies.Source.Setup;

public static class FactionChoiceDialogSetup
{
  public static void PostSetup()
  {
    var illidari = new FactionChoice
    {
      Faction = new IllidariFaction(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.IllidanStartingPosition
    };
    var sunfury = new FactionChoice
    {
      Faction = new SunfuryFaction(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.SunfuryStartingPosition
    };
    new FactionChoiceDialogPresenter(illidari, sunfury).Run(player.Create(15));

    var dalaran = new FactionChoice
    {
      Faction = new DalaranFaction(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.DalaStartPos
    };
    var gilneas = new FactionChoice
    {
      Faction = new GilneasFaction(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.DalaStartPos,
      RequiresCheats = false
    };
    new FactionChoiceDialogPresenter(dalaran, gilneas).Run(player.Create(7));

    var sentinels = new FactionChoice
    {
      Faction = new SentinelsFaction(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.SentDraeSharedStartPos
    };
    var draenei = new FactionChoice

    {
      Faction = new DraeneiFaction(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.SentDraeSharedStartPos,
      RequiresCheats = false
    };
    new FactionChoiceDialogPresenter(sentinels, draenei).Run(player.Create(18));
    var frostwolf = new FactionChoice
    {
      Faction = new FrostwolfFaction(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.FrostwolfStartPos
    };
    var warsong = new FactionChoice

    {
      Faction = new WarsongFaction(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.FrostwolfStartPos,
      RequiresCheats = false
    };
    new FactionChoiceDialogPresenter(frostwolf, warsong).Run(player.Create(0));
  }
}
