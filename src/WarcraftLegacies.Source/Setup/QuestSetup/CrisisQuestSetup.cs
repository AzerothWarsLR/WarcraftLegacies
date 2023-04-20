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
      
      crisis.AddQuest(new QuestNazjatarSpawnCaptain(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Nazjatar.Azshara));
      crisis.AddQuest(new QuestBlackEmpireSpawnCaptain(preplacedUnitSystem, Regions.MaelstromChannel, allLegendSetup.Nazjatar.Azshara));

      crisis2.AddQuest(new QuestNazjatarSpawnFootman(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Nazjatar.Azshara));

    }
  }
}