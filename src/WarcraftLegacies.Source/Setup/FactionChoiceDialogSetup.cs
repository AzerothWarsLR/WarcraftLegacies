using MacroTools;
using MacroTools.FactionChoices;
using WarcraftLegacies.Source.Factions;

namespace WarcraftLegacies.Source.Setup
{
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
      new FactionChoiceDialogPresenter(illidari, sunfury).Run(Player(15));

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
        StartingArea = Regions.GilneasStartPos
      };
      new FactionChoiceDialogPresenter(dalaran, gilneas).Run(Player(7));

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
        StartingArea = Regions.SentDraeSharedStartPos
      };
      new FactionChoiceDialogPresenter(sentinels, draenei).Run(Player(18));
    }
  }
}