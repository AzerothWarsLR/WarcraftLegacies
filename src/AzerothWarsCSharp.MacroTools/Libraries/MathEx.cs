using System;
using WCSharp.Shared.Data;


namespace AzerothWarsCSharp.MacroTools.Libraries
{
  public static class MathEx
  {
    private const double DEG_TO_RAD = Math.PI / 180.0;
    
    public static int ModuloInteger(int dividend, int divisor)
    {
      var modulus = dividend - (dividend / divisor) * divisor;

      // If the dividend was negative, the above modulus calculation will
      // be negative, but within (-divisor..0).  We can add (divisor) to
      // shift this result into the desired range of (0..divisor).
      if (modulus < 0)
      {
        modulus += divisor;
      }

      return modulus;
    }
    
    public static float GetDistanceBetweenPoints(Point positionA, Point positionB)
    {
      var dx = positionB.X - positionA.X;
      var dy = positionB.Y - positionA.Y;

      return (float)Math.Sqrt(dx * dx + dy * dy);
    }

    public static float GetAngleBetweenPoints(float xa, float ya, float xb, float yb)
    {
      return (float)(DEG_TO_RAD * Math.Atan2(yb - ya, xb - xa));
    }

    public static float GetPolarOffsetX(float x, float dist, float angle)
    {
      return (float)(x + dist * Math.Cos(angle * DEG_TO_RAD));
    }

    public static float GetPolarOffsetY(float y, float dist, float angle)
    {
      return (float)(y + dist * Math.Sin(angle * DEG_TO_RAD));
    }
  }
}