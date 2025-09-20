using MacroTools.FactionSystem;
using TestMap.Source.Quests;

namespace TestMap.Source.Setup;

public static class AllQuestSetup
{
  public static void Setup()
  {
    var sharedQuest = new SharedQuest();
    foreach (var faction in FactionManager.GetAllFactions())
    {
      faction.AddQuest(sharedQuest);
    }
  }
}
