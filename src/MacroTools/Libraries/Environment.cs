using WCSharp.Shared.Data;

namespace MacroTools.Libraries
{
  public static class Environment
  {
    public const int MAX_PLAYERS = 28;
    private static readonly unit PosUnit;

    /// <summary>
    /// Returns the height of the terrain at the given position.
    /// </summary>
    public static float GetPositionZ(Point position)
    {
      SetUnitX(PosUnit, position.X);
      SetUnitY(PosUnit, position.Y);
      return BlzGetUnitZ(PosUnit);
    }

    static Environment() =>
      PosUnit = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), FourCC("u00X"), 0, 0, 0);
  }
}