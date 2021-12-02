using AzerothWarsCSharp.Source.Cheats;

namespace AzerothWarsCSharp.Source.Setup
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