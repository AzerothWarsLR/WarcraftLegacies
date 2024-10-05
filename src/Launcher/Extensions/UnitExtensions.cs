using System.Collections.Generic;
using War3Api.Object;
using War3Api.Object.Enums;

namespace Launcher.Extensions
{
  public static class UnitExtensions
  {
    public static List<Target> GetAllTargetsAllowed(this Unit unit)
    {
      List<Target> targetsAllowed = new();
      if (unit.CombatAttacksEnabledRaw is 1 or 3)
      {
        try
        {
          targetsAllowed.AddRange(unit.CombatAttack1TargetsAllowed);
        }
        catch
        {
          //do nothing
        }
      }
      if (unit.CombatAttacksEnabledRaw is 2 or 3)
      {
        try
        {
          targetsAllowed.AddRange(unit.CombatAttack2TargetsAllowed);
        }
        catch
        {
          //do nothing
        }
      }

      return targetsAllowed;
    }
    
    public static IEnumerable<Item> GetTechtreeItemsSoldAndMade(this Unit unit)
    {
      var itemsSold = new List<Item>();
        itemsSold.AddRange(unit.TechtreeItemsSold);
        
        itemsSold.AddRange(unit.TechtreeItemsMade);

      return itemsSold;
    }

    public static int GetPriority(this Unit unit)
    {
        var (x, y) = (unit.ArtButtonPositionX, unit.ArtButtonPositionY);
        return x + y * 10;
    }
  }
}