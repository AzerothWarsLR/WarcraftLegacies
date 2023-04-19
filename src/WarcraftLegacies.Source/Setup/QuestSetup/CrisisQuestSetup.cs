using WarcraftLegacies.Source.Quests.CrisisSpawn;
using WarcraftLegacies.Source.Setup.FactionSetup;


namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class CrisisQuestSetup
  {
    public static void Setup()
    {
      var crisis = CrisisCaptainSetup.CrisisCaptain;
      var crisis2 = CrisisFootmanSetup.CrisisFootman;

      crisis.AddQuest(new QuestOldGodPick());
      crisis.AddQuest(new QuestCthunSpawn(Regions.Silithus_Bug_Exterior));

      crisis2.AddQuest(new QuestCthunSpawn(Regions.Silithus_Bug_Exterior));

    }
  }
}