using static War3Api.Common;

namespace MacroTools.Libraries
{
  public class Environment
  {
    public const int MAX_PLAYERS = 28;
    private static unit _posUnit;

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