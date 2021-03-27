using AzerothWarsCSharp.Source.UserInterface;

namespace AzerothWarsCSharp.Source.Setup
{
  public class GameSetup
  {
    public static void Initialize()
    {
      TeamSetup.Initialize();
      FactionSetup.Initialize();
      FactionMultiboard.Initialize();
    }
  }
}
