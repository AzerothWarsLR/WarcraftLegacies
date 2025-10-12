namespace MacroTools.Extensions;

public static class PlayerResourceExtensions
{
  /// <summary>Adds an amount of gold to a player.</summary>
  public static void AddGold(this player player, float gold) => PlayerData.ByHandle(player).AddGold(gold);

  /// <summary>Sets the player's gold to a specific value.</summary>
  public static void SetGold(this player player, float gold) => PlayerData.ByHandle(player).SetGold(gold);

  /// <summary>Returns the player's gold, including any partial gold.</summary>
  public static float GetGold(this player player) => PlayerData.ByHandle(player).GetGold();
}
