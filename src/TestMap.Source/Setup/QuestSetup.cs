using MacroTools.FactionSystem;
using TestMap.Source.Quests;
using TestMap.Source.Setup.FactionSetup.FactionSetup;

namespace TestMap.Source.Setup
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