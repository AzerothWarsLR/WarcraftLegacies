using AzerothWarsCSharp.TestSource.Quests;
using AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class AllQuestSetup
  {
    public static void Setup()
    {
      var exampleQuestA = new ExampleQuestA();
      
      BlackEmpireSetup.BlackEmpire.AddQuest(exampleQuestA);
      BlackEmpireSetup.BlackEmpire.AddQuest(new ExampleQuestB(exampleQuestA));
    }
  }
}