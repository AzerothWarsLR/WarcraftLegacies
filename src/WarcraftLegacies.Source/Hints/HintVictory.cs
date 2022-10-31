using WarcraftLegacies.MacroTools.HintSystem;
using WarcraftLegacies.Source.GameLogic.GameEnd;

namespace WarcraftLegacies.Source.Hints
{
  public class HintVictory{
    public static void Setup( ){
      Hint.Register(new Hint($"Win the game by capturing {ControlPointVictory.GetControlPointsRequiredVictory()} Control Points."));
    }
  }
}
