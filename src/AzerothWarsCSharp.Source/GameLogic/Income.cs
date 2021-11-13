//using AzerothWarsCSharp.Source.Libraries;
//using static War3Api.Common;

//namespace AzerothWarsCSharp.Source.GameLogic
//{

//  /// <summary>
//  /// All factions receive their income in gold every second.
//  /// </summary>
//  public static class Income
//  {
//    private static readonly float PERIOD = 1;

//    private static void OnIncomeTick()
//    {
//      foreach (var faction in Faction.GetAll())
//      {
//        faction.Gold += faction.Income / PERIOD;
//      }
//    }

//    public static void Initialize()
//    {
//      var incomeTimer = CreateTimer();
//      TimerStart(incomeTimer, PERIOD, TRUE, OnIncomeTick);
//    }
//  }
//}