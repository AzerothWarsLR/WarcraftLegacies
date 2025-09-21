namespace MacroTools.Extensions;

public static class PlayerResourceExtensions
{
  /// <summary>
  /// Increases or decreases a specific player state for the player.
  /// </summary>
  public static void AdjustPlayerState(this player player, playerstate playerState, int value) =>
    player.SetState(playerState, player.GetState(playerState) + value);

  /// <summary>Adds an amount of gold to a player.</summary>
  public static void AddGold(this player player, float gold) => PlayerData.ByHandle(player).AddGold(gold);

  /// <summary>Sets the player's gold to a specific value.</summary>
  public static void SetGold(this player player, float gold) => PlayerData.ByHandle(player).SetGold(gold);

  /// <summary>Returns the player's gold, including any partial gold.</summary>
  public static float GetGold(this player player) => PlayerData.ByHandle(player).GetGold();

  /// <summary>
  /// Returns the amount of food the player is using.
  /// </summary>
  public static int GetFoodUsed(this player whichPlayer) =>
    whichPlayer.GetState(playerstate.ResourceFoodUsed);

  /// <summary>
  /// Returns the player's food cap.
  /// </summary>
  public static int GetFoodCap(this player whichPlayer) =>
    whichPlayer.GetState(playerstate.ResourceFoodCap);

  /// <summary>
  /// Returns player's food cap ceiling.
  /// </summary>
  public static int GetFoodCapCeiling(this player whichPlayer) =>
    whichPlayer.GetState(playerstate.FoodCapCeiling);

  /// <summary>Removes all of the player's resources.</summary>
  public static player RemoveAllResources(this player whichPlayer)
  {
    whichPlayer.SetGold(0);
    return whichPlayer;
  }
}
