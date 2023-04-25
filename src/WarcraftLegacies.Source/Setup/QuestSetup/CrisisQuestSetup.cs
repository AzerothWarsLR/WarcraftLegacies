using MacroTools;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
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

      QuestElfDead elfDead = new();
      QuestHordeDead hordeDead = new();
      QuestSADead saDead = new();
      QuestIllidariDead illidariDead = new();
      QuestNADead naDead = new();
      QuestScourgeDead scourgeDead = new();

      elfDead.AddObjective(new ObjectiveDontCompleteQuest(hordeDead));
      hordeDead.AddObjective(new ObjectiveDontCompleteQuest(elfDead));
      saDead.AddObjective(new ObjectiveDontCompleteQuest(illidariDead));
      illidariDead.AddObjective(new ObjectiveDontCompleteQuest(saDead));
      naDead.AddObjective(new ObjectiveDontCompleteQuest(scourgeDead));
      scourgeDead.AddObjective(new ObjectiveDontCompleteQuest(naDead));
      
      crisis.AddQuest(hordeDead);
      crisis.AddQuest(elfDead);
      crisis.AddQuest(illidariDead);
      crisis.AddQuest(saDead);
      crisis.AddQuest(scourgeDead);
      crisis.AddQuest(naDead);

      crisis2.AddQuest(hordeDead);
      crisis2.AddQuest(elfDead);
      crisis2.AddQuest(illidariDead);
      crisis2.AddQuest(saDead);
      crisis2.AddQuest(scourgeDead);
      crisis2.AddQuest(naDead);

      crisis.AddQuest(new QuestTurn25OG());
      crisis.AddQuest(new QuestOldGodPick(preplacedUnitSystem));

      crisis.AddQuest(new QuestNazjatarSpawn(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Nazjatar.Azshara));
      crisis.AddQuest(new QuestBlackEmpireSpawnCaptain(preplacedUnitSystem, Regions.MaelstromChannel, allLegendSetup.BlackEmpire.Nzoth));
      crisis.AddQuest(new QuestCthunSpawn(preplacedUnitSystem, Regions.CthunSpawn, allLegendSetup.Cthun.Cthun));
      crisis.AddQuest(new QuestTwilightHammerSpawn(preplacedUnitSystem, Regions.TwilightUnlock, allLegendSetup.Twilight.Chogall));

      crisis2.AddQuest(new QuestNazjatarSpawn(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Nazjatar.Azshara));
      crisis2.AddQuest(new QuestBlackEmpireSpawnFootman(preplacedUnitSystem, Regions.MaelstromChannel, allLegendSetup.BlackEmpire.Nzoth));
      crisis2.AddQuest(new QuestCthunSpawn(preplacedUnitSystem, Regions.CthunSpawn, allLegendSetup.Cthun.Cthun));
      crisis2.AddQuest(new QuestTwilightHammerSpawn(preplacedUnitSystem, Regions.TwilightUnlock, allLegendSetup.Twilight.Chogall));

    }
  }
}