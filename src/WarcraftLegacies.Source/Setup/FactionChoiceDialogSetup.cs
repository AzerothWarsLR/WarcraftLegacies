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
        StartingCameraPosition = Regions.IllidanStartingPosition.Center
      };
      var sunfury = new FactionChoice
      {
        Faction = new Sunfury(preplacedUnitSystem,
          allLegendSetup,
          artifactSetup),
        Difficulty = FactionLearningDifficulty.Advanced,
        StartingCameraPosition = Regions.SunfuryStartingPosition.Center
      };
      new FactionChoiceDialogPresenter(illidari, sunfury).Run(Player(15));

      var dalaran = new FactionChoice
      {
        Faction = new Dalaran(preplacedUnitSystem,
          artifactSetup,
          allLegendSetup),
        Difficulty = FactionLearningDifficulty.Basic,
        StartingCameraPosition = Regions.DalaStartPos.Center
      };
      var gilneas = new FactionChoice
      {
        Faction = new Gilneas(preplacedUnitSystem,
          artifactSetup,
          allLegendSetup),
        Difficulty = FactionLearningDifficulty.Advanced,
        StartingCameraPosition = Regions.GilneasStartPos.Center
      };
      new FactionChoiceDialogPresenter(dalaran, gilneas).Run(Player(7));

      var sentinels = new FactionChoice
      {
        Faction = new Sentinels(preplacedUnitSystem,
          allLegendSetup,
          artifactSetup),
        Difficulty = FactionLearningDifficulty.Basic,
        StartingCameraPosition = Regions.SentDraeSharedStartPos.Center
      };
      var draenei = new FactionChoice
      {
        Faction = new Draenei(preplacedUnitSystem,
          allLegendSetup,
          artifactSetup),
        Difficulty = FactionLearningDifficulty.Advanced,
        StartingCameraPosition = Regions.SentDraeSharedStartPos.Center
      };
      new FactionChoiceDialogPresenter(sentinels, draenei).Run(Player(18));
    }
  }
}