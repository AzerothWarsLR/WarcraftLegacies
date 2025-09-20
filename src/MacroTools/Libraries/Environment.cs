using WCSharp.Shared.Data;

namespace MacroTools.Libraries;

public static class Environment
{
  public const int MaxPlayers = 28;
  private static readonly unit _posUnit;

  /// <summary>
  /// Returns the height of the terrain at the given position.
  /// </summary>
  public static float GetPositionZ(Point position)
  {
    SetUnitX(_posUnit, position.X);
    SetUnitY(_posUnit, position.Y);
    return BlzGetUnitZ(_posUnit);
  }

  static Environment() =>
    _posUnit = CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE), FourCC("u00X"), 0, 0, 0);
}
