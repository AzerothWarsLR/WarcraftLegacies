using AzerothWarsCSharp.MacroTools.Cheats;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class CheatSetup
  {
    public static void Setup()
    {
      CheatGold.Setup();
      CheatControl.Setup();
      CheatFood.Setup();
      CheatHp.Setup();
    }
  }
}