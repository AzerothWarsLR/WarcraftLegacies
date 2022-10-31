using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.TestSource.Quests;
using WarcraftLegacies.TestSource.Setup.FactionSetup.FactionSetup;

namespace WarcraftLegacies.TestSource.Setup
{
  public static class AllQuestSetup
  {
    public static void Setup()
    {
      var exampleQuestA = new ExampleQuestA();
      
      BlackEmpireSetup.BlackEmpire.AddQuest(exampleQuestA);
      BlackEmpireSetup.BlackEmpire.AddQuest(new ExampleQuestB(exampleQuestA));
      BlackEmpireSetup.BlackEmpire.AddQuest(new ExampleQuestC());

      var sharedQuest = new SharedQuest();
      foreach (var faction in FactionManager.GetAllFactions())
      {
        faction.AddQuest(sharedQuest);
      }
    }
  }
}