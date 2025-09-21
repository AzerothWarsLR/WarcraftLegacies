using MacroTools.Extensions;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Responsible for giving players resources at the start of the game.
/// </summary>
public static class StartingResources
{
  /// <summary>
  /// After a period of time, gives all players their starting resources.
  /// </summary>
  public static void Setup()
  {
    var trig = trigger.Create();
    trig.RegisterTimerEvent(58, false);
    trig.AddAction(() =>
    {
      foreach (var player in Util.EnumeratePlayers())
      {
        var faction = player.GetFaction();
        if (faction == null)
        {
          continue;
        }

        player.SetState(playerstate.ResourceGold, faction.StartingGold);
        player.SetState(playerstate.ResourceHeroTokens, 1);
      }
    });
  }
}
