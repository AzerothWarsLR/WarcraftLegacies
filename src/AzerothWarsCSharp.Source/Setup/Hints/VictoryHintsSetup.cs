using AzerothWarsCSharp.Source.GameLogic;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class VictoryHintsSetup
  {
    public static void Initialize()
    {
      Hint.Register(new Hint("Win the game by capturing " + Victory.CPS_VICTORY + " Control Points."));
    }
  }
}