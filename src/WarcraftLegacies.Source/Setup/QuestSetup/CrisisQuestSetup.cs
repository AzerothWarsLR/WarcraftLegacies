using MacroTools;
using WarcraftLegacies.Source.Quests.CrisisSpawn;
using WarcraftLegacies.Source.Setup.FactionSetup;


namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class CrisisQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var crisis = CrisisCaptainSetup.CrisisCaptain;
      var crisis2 = CrisisFootmanSetup.CrisisFootman;

      crisis.AddQuest(new QuestOldGodPick(preplacedUnitSystem));
      
      crisis.AddQuest(new QuestNazjatarSpawn(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Nazjatar.Azshara));
      crisis.AddQuest(new QuestBlackEmpireSpawnCaptain(preplacedUnitSystem, Regions.MaelstromChannel, allLegendSetup.BlackEmpire.Nzoth));
      crisis.AddQuest(new QuestCthunSpawn(preplacedUnitSystem, Regions.CthunSpawn, allLegendSetup.Cthun.Cthun));
      crisis.AddQuest(new QuestTwilightHammerSpawn(preplacedUnitSystem, Regions.TwilightUnlock, allLegendSetup.Cthun.Cthun));

      crisis2.AddQuest(new QuestNazjatarSpawn(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Nazjatar.Azshara));
      crisis2.AddQuest(new QuestBlackEmpireSpawnFootman(preplacedUnitSystem, Regions.MaelstromChannel, allLegendSetup.BlackEmpire.Nzoth));
      crisis2.AddQuest(new QuestCthunSpawn(preplacedUnitSystem, Regions.CthunSpawn, allLegendSetup.Cthun.Cthun));
      crisis2.AddQuest(new QuestTwilightHammerSpawn(preplacedUnitSystem, Regions.TwilightUnlock, allLegendSetup.Cthun.Cthun));

    }
  }
}