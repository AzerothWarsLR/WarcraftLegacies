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

      QuestElfDead elfDead2 = new();
      QuestHordeDead hordeDead2 = new();
      QuestSADead saDead2 = new();
      QuestIllidariDead illidariDead2 = new();
      QuestNADead naDead2 = new();
      QuestScourgeDead scourgeDead2 = new();

      elfDead.AddObjective(new ObjectiveDontCompleteQuest(hordeDead));
      hordeDead.AddObjective(new ObjectiveDontCompleteQuest(elfDead));
      saDead.AddObjective(new ObjectiveDontCompleteQuest(illidariDead));
      illidariDead.AddObjective(new ObjectiveDontCompleteQuest(saDead));
      naDead.AddObjective(new ObjectiveDontCompleteQuest(scourgeDead));
      scourgeDead.AddObjective(new ObjectiveDontCompleteQuest(naDead));

      elfDead2.AddObjective(new ObjectiveDontCompleteQuest(hordeDead2));
      hordeDead2.AddObjective(new ObjectiveDontCompleteQuest(elfDead2));
      saDead2.AddObjective(new ObjectiveDontCompleteQuest(illidariDead2));
      illidariDead2.AddObjective(new ObjectiveDontCompleteQuest(saDead2));
      naDead2.AddObjective(new ObjectiveDontCompleteQuest(scourgeDead2));
      scourgeDead2.AddObjective(new ObjectiveDontCompleteQuest(naDead2));

      crisis.AddQuest(hordeDead);
      crisis.AddQuest(elfDead);
      crisis.AddQuest(illidariDead);
      crisis.AddQuest(saDead);
      crisis.AddQuest(scourgeDead);
      crisis.AddQuest(naDead);

      crisis2.AddQuest(hordeDead2);
      crisis2.AddQuest(elfDead2);
      crisis2.AddQuest(illidariDead2);
      crisis2.AddQuest(saDead2);
      crisis2.AddQuest(scourgeDead2);
      crisis2.AddQuest(naDead2);

      crisis.AddQuest(new QuestTurn25OG());
      crisis.AddQuest(new QuestOldGodPick(preplacedUnitSystem));

      crisis.AddQuest(new QuestNazjatarSpawn(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Nazjatar.Azshara, allLegendSetup.Nazjatar.Sivara, allLegendSetup.Nazjatar.Zakajz, allLegendSetup.Nazjatar.Nazjar));
      crisis.AddQuest(new QuestBlackEmpireSpawnCaptain(preplacedUnitSystem, Regions.MaelstromChannel, allLegendSetup.BlackEmpire.Nzoth, allLegendSetup.BlackEmpire.Vezax, allLegendSetup.BlackEmpire.Volazj, allLegendSetup.BlackEmpire.Yorsahj));
      crisis.AddQuest(new QuestCthunSpawn(preplacedUnitSystem, Regions.CthunSpawn, allLegendSetup.Cthun.Cthun, allLegendSetup.Cthun.Moam, allLegendSetup.Cthun.Skeram, allLegendSetup.Cthun.Ouro));
      crisis.AddQuest(new QuestTwilightHammerSpawn(preplacedUnitSystem, Regions.TwilightUnlock, allLegendSetup.Twilight.Chogall, allLegendSetup.Twilight.Azil, allLegendSetup.Twilight.Emberscar, allLegendSetup.Twilight.Ignacious));

      crisis2.AddQuest(new QuestNazjatarSpawn(preplacedUnitSystem, Regions.NzothStartPosition, allLegendSetup.Nazjatar.Azshara, allLegendSetup.Nazjatar.Sivara, allLegendSetup.Nazjatar.Zakajz, allLegendSetup.Nazjatar.Nazjar));
      crisis2.AddQuest(new QuestBlackEmpireSpawnFootman(preplacedUnitSystem, Regions.MaelstromChannel, allLegendSetup.BlackEmpire.Nzoth, allLegendSetup.BlackEmpire.Vezax, allLegendSetup.BlackEmpire.Volazj, allLegendSetup.BlackEmpire.Yorsahj));
      crisis2.AddQuest(new QuestCthunSpawn(preplacedUnitSystem, Regions.CthunSpawn, allLegendSetup.Cthun.Cthun, allLegendSetup.Cthun.Moam, allLegendSetup.Cthun.Skeram, allLegendSetup.Cthun.Ouro));
      crisis2.AddQuest(new QuestTwilightHammerSpawn(preplacedUnitSystem, Regions.TwilightUnlock, allLegendSetup.Twilight.Chogall, allLegendSetup.Twilight.Azil, allLegendSetup.Twilight.Emberscar, allLegendSetup.Twilight.Ignacious));

    }
  }
}