using MacroTools.Extensions;
using MacroTools.GameTime;
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
    const int startTurn = 1;
    GameTimeManager.RegisterOnTurn(startTurn, () =>
    {
      foreach (var player in Util.EnumeratePlayers())
      {
        var playerData = player.GetPlayerData();
        var faction = playerData.Faction;
        if (faction == null)
        {
          continue;
        }

        player.SetState(playerstate.ResourceGold, faction.StartingGold.Instant);
        player.SetState(playerstate.ResourceHeroTokens, 1);
        playerData.BonusIncome += faction.StartingGold.Income;

        GameTimeManager.RegisterOnTurn(faction.StartingGold.Turns + 1, () =>
        {
          playerData.BonusIncome -= faction.StartingGold.Income;
        });
      }
    });
  }
}
