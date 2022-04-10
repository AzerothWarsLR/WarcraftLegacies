using AzerothWarsCSharp.MacroTools;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      PreplacedUnitSystem.Initialize();
      SpellSetup.Setup();
      CheatSetup.Setup();
      QuestMenuSetup.Setup();
      PreplacedUnitSystem.Shutdown();
    }
  }
}