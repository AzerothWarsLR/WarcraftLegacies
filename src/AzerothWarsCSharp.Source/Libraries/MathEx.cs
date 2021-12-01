using System;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Libraries
{
  public static class MathEx
  {
    public static float GetDistanceBetweenPoints(float xa, float ya, float xb, float yb)
    {
      var dx = xb - xa;
      var dy = yb - ya;

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