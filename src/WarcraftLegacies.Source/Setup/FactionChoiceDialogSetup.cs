using MacroTools.FactionChoices;
using MacroTools.Systems;
using WarcraftLegacies.Source.Factions;

namespace WarcraftLegacies.Source.Setup;

public static class FactionChoiceDialogSetup
{
  public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
  {
    var illidari = new FactionChoice
    {
      Faction = new Illidari(allLegendSetup,
        artifactSetup),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.IllidanStartingPosition
    };
    var sunfury = new FactionChoice
    {
      Faction = new Sunfury(preplacedUnitSystem,
        allLegendSetup,
        artifactSetup),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.SunfuryStartingPosition
    };
    new FactionChoiceDialogPresenter(illidari, sunfury).Run(player.Create(15));

    var dalaran = new FactionChoice
    {
      Faction = new Dalaran(preplacedUnitSystem,
        artifactSetup,
        allLegendSetup),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.DalaStartPos
    };
    var gilneas = new FactionChoice
    {
      Faction = new Gilneas(preplacedUnitSystem,
        artifactSetup,
        allLegendSetup),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.DalaStartPos,
      RequiresCheats = false
    };
    new FactionChoiceDialogPresenter(dalaran, gilneas).Run(player.Create(7));

    var sentinels = new FactionChoice
    {
      Faction = new Sentinels(preplacedUnitSystem,
        allLegendSetup,
        artifactSetup),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.SentDraeSharedStartPos
    };
    var draenei = new FactionChoice

    {
      Faction = new Draenei(preplacedUnitSystem,
        allLegendSetup,
        artifactSetup),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.SentDraeSharedStartPos,
      RequiresCheats = false
    };
    new FactionChoiceDialogPresenter(sentinels, draenei).Run(player.Create(18));
    var frostwolf = new FactionChoice
    {
      Faction = new Frostwolf(preplacedUnitSystem,
        allLegendSetup,
        artifactSetup),
      Difficulty = FactionLearningDifficulty.Basic,
      StartingArea = Regions.FrostwolfStartPos
    };
    var warsong = new FactionChoice

    {
      Faction = new Warsong(preplacedUnitSystem,
        allLegendSetup,
        artifactSetup),
      Difficulty = FactionLearningDifficulty.Advanced,
      StartingArea = Regions.FrostwolfStartPos,
      RequiresCheats = false
    };
    new FactionChoiceDialogPresenter(frostwolf, warsong).Run(player.Create(0));
  }
}
