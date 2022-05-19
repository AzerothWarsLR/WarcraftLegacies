using System;
using WCSharp.Shared.Data;


namespace AzerothWarsCSharp.MacroTools.Libraries
{
  public static class MathEx
  {
    public static float GetDistanceBetweenPoints(Point positionA, Point positionB)
    {
      var dx = positionB.X - positionA.X;
      var dy = positionB.Y - positionA.Y;

      return (float)Math.Sqrt(dx * dx + dy * dy);
    }

    public static float GetAngleBetweenPoints(float xa, float ya, float xb, float yb)
    {
      return (float)(bj_RADTODEG * Math.Atan2(yb - ya, xb - xa));
    }

    public static float GetPolarOffsetX(float x, float dist, float angle)
    {
      return (float)(x + dist * Math.Cos(angle * bj_DEGTORAD));
    }

    public static float GetPolarOffsetY(float y, float dist, float angle)
    {
      return (float)(y + dist * Math.Sin(angle * bj_DEGTORAD));
    }
  }
}