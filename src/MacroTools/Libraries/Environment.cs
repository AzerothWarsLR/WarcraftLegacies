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
    _posUnit.X = position.X;
    _posUnit.Y = position.Y;
    return _posUnit.Z;
  }

  static Environment() =>
    _posUnit = unit.Create(player.NeutralPassive, FourCC("u00X"), 0, 0, 0);
}
