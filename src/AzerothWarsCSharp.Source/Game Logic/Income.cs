using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Game_Logic
{
  public static class Income
  {
    /// <summary>
    /// How often players receive income.
    /// Changing this will not affect the total amount of income they receive.
    /// </summary>
    private const float PERIOD = 1;

    public static void Setup()
    {
      timer incomeTimer = CreateTimer();
      TimerStart(incomeTimer, PERIOD, true, () =>
      {
        foreach (var player in GetAllPlayers())
        {
          var person = Person.ByHandle(player);
          if (person != null)
          {
            var goldPerSecond = person.Faction.Income * PERIOD / 60;
            person.AddGold(goldPerSecond);
          }
        }
      });
    }
  }
}