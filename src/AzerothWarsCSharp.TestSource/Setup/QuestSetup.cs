using AzerothWarsCSharp.TestSource.Quests;
using AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class AllQuestSetup
  {
    public static void Setup()
    {
      BlackEmpireSetup.BlackEmpire.AddQuest(new ExampleQuestA());
    }
  }
}