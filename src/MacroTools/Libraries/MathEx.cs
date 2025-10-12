using WCSharp.Shared.Data;

namespace MacroTools.Libraries;

public static class MathEx
{
  public const float Pi = 3.141593F;
  public const float DegToRad = Pi / 180.0f;
  public const float RadToDeg = 180 / Pi;

  public static float Max(float a, float b)
  {
    return b > a ? b : a;
  }

  public static float GetDistanceBetweenPoints(Point positionA, Point positionB)
  {
    var dx = positionB.X - positionA.X;
    var dy = positionB.Y - positionA.Y;

    return SquareRoot(dx * dx + dy * dy);
  }

  public static float GetAngleBetweenPoints(float xa, float ya, float xb, float yb) => RadToDeg * Atan2(yb - ya, xb - xa);

  public static float GetPolarOffsetX(float x, float dist, float angle) => x + dist * Cos(angle * DegToRad);

  public static float GetPolarOffsetY(float y, float dist, float angle) => y + dist * Sin(angle * DegToRad);
}
