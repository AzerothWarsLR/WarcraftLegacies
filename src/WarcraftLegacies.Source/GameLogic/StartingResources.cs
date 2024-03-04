using MacroTools.Extensions;


namespace WarcraftLegacies.Source.GameLogic
{
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
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 58, false);
      TriggerAddAction(trig, () =>
      {
        foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        {
          var faction = player.GetFaction();
          if (faction == null) continue;
          SetPlayerState(player, PLAYER_STATE_RESOURCE_GOLD, faction.StartingGold);
          SetPlayerState(player, PLAYER_STATE_RESOURCE_LUMBER, faction.StartingLumber);
          SetPlayerState(player, PLAYER_STATE_RESOURCE_HERO_TOKENS, 1);
        }
      });
    }
  }
}