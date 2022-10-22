namespace AzerothWarsCSharp.MacroTools.Libraries
{
  public class Environment
  {
    public const int MAX_PLAYERS = 28;
    private static unit _posUnit;

    //Player(21) is used as a hostile computer player in this map. Use this to check if a player is neutral hostile or this pseudo-player.
    public static bool IsPlayerNeutralHostile(player whichPlayer)
    {
      return whichPlayer == Player(21) || whichPlayer == Player(PLAYER_NEUTRAL_AGGRESSIVE);
    }

    public static float GetPositionZ(float x, float y)
    {
      SetUnitX(_posUnit, x);
      SetUnitY(_posUnit, y);
      return BlzGetUnitZ(_posUnit);
    }

    public static bool IsUnitInRect(unit u, rect r)
    {
      return GetUnitX(u) > GetRectMinX(r) - 32 && GetUnitX(u) < GetRectMaxX(r) + 32 &&
             GetUnitY(u) > GetRectMinY(r) - 32 && GetUnitY(u) < GetRectMaxY(r) + 32;
    }

    public static void Setup()
    {
      _posUnit = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), FourCC("u00X"), 0, 0, 0);
    }
  }
}