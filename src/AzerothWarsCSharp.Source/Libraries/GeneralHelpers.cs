using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Libraries
{
  public static class GeneralHelpers
  {
    public static region RectToRegion(rect whichRect)
    {
      var rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    public static void ScaleUnitBaseDamage(unit u, float scale, int weaponIndex)
    {
      BlzSetUnitBaseDamage(u, R2I(I2R(BlzGetUnitBaseDamage(u, weaponIndex)) * scale), weaponIndex);
    }

    public static void ScaleUnitMaxHitpoints(unit u, float scale)
    { 
      var percentageHitpoints = GetUnitLifePercent(u);
      BlzSetUnitMaxHP(u, R2I(I2R(BlzGetUnitMaxHP(u)) * scale));
      SetUnitLifePercentBJ(u, percentageHitpoints);
    }
  }
}