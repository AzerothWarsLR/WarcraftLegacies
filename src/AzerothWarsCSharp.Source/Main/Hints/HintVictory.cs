using AzerothWarsCSharp.Source.Main.Game_Logic.GameEnd;
using AzerothWarsCSharp.Source.Main.Libraries;

namespace AzerothWarsCSharp.Source.Main.Hints
{
  public class HintVictory{
    public static void Setup( ){
      Hint.Register(new Hint($"Win the game by capturing {ControlPointVictory.GetControlPointsRequiredVictory()} Control Points."));
    }
  }
}
