//using static War3Api.Common;

//namespace AzerothWarsCSharp.Source.GameLogic
//{
//  public static class GameTimer
//  {
//    private static readonly float PERIOD = 1;
//    private static readonly float TURN_LENGTH = 60;

//    /// <summary>
//    /// An alternate metric for how much time has passed since the start of the game.
//    /// </summary>
//    public static int TurnCount
//    {
//      get
//      {
//        return (int)(GameTime / TURN_LENGTH);
//      }
//    }

//    /// <summary>
//    /// How much time has passed since the start of the game.
//    /// </summary>
//    public static double GameTime { get; private set; }

//    private static void AdvanceGameTime()
//    {
//      GameTime += PERIOD;
//    }

//    public static void Initialize()
//    {
//      var gameTimer = CreateTimer();
//      TimerStart(gameTimer, PERIOD, true, AdvanceGameTime);
//    }
//  }
//}
