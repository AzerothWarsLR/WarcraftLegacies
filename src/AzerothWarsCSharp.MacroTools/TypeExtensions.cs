using System;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public static class TypeExtensions
  {
    public static bool ExistsAsBuffOnUnit(this Type type, unit whichUnit)
    {
      foreach (var buff in BuffSystem.GetBuffsOnUnit(whichUnit))
      {
        if (buff.GetType() == type)
        {
          return true;
        }
      }

      return false;
    }
  }
}