using System;
using System.Linq;
using WCSharp.Buffs;


namespace MacroTools.Extensions
{
  /// <summary>
  /// Useful extensions to the <see cref="Type"/> class.
  /// </summary>
  public static class TypeExtensions
  {
    /// <summary>
    /// Returns whether or not a particular <see cref="Buff"/> exists on a unit.
    /// Should only be used with a <see cref="Type"/> that extends from <see cref="Buff"/>.
    /// </summary>
    public static bool ExistsAsBuffOnUnit(this Type type, unit whichUnit) => 
      BuffSystem.GetBuffsOnUnit(whichUnit).Any(buff => buff.GetType() == type);
  }
}