using MacroTools.FactionChoices;
using WarcraftLegacies.Source.Factions;

namespace WarcraftLegacies.Source.Setup;

public static class FactionChoiceDialogSetup
{
  public static void Setup()
  {
    var illidari = new FactionChoice
    {
      Faction = new Illidari(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.IllidanStartingPosition
    };
    var sunfury = new FactionChoice
    {
      Faction = new Sunfury(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.SunfuryStartingPosition
    };
    new FactionChoiceDialogPresenter(illidari, sunfury).Run(player.Create(15));

    var dalaran = new FactionChoice
    {
      Faction = new Dalaran(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.DalaStartPos
    };
    var gilneas = new FactionChoice
    {
      Faction = new Gilneas(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.DalaStartPos,
      RequiresCheats = false
    };
    new FactionChoiceDialogPresenter(dalaran, gilneas).Run(player.Create(7));

    var sentinels = new FactionChoice
    {
      Faction = new Sentinels(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.SentDraeSharedStartPos
    };
    var draenei = new FactionChoice

    {
      Faction = new Draenei(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.SentDraeSharedStartPos,
      RequiresCheats = false
    };
    new FactionChoiceDialogPresenter(sentinels, draenei).Run(player.Create(18));
    var frostwolf = new FactionChoice
    {
      Faction = new Frostwolf(),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.FrostwolfStartPos
    };
    var warsong = new FactionChoice

    {
      Faction = new Warsong(),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.FrostwolfStartPos,
      RequiresCheats = false
    };
    new FactionChoiceDialogPresenter(frostwolf, warsong).Run(player.Create(0));
  }
}
