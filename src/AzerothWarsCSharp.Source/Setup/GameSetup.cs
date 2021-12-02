using AzerothWarsCSharp.Source.UserInterface;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class GameSetup
  {
    public static void Setup()
    {
      SpellSetup.Setup();
      TeamSetup.Setup();
      FactionMultiboard.Initialize();
    }
  }
}