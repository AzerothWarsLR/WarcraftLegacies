using System;
using System.Collections.Generic;
using War3Api.Object;
using War3Api.Object.Enums;

namespace Launcher.Extensions
{
  public static class UnitExtensions
  {
    public static List<Target> GetAllTargetsAllowedSafe(this Unit unit)
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
    
    public static IEnumerable<Item> GetSoldItemsSafe(this Unit unit)
    {
      var itemsSold = new List<Item>();
      try
      {
        itemsSold.AddRange(unit.TechtreeItemsSold);
      }
      catch
      {
        //do nothing
      }
      
      try
      {
        itemsSold.AddRange(unit.TechtreeItemsMade);
      }
      catch
      {
        //do nothing
      }

      return itemsSold;
    }
    
    public static IEnumerable<Upgrade> GetResearchesAvailableSafe(this Unit unit)
    {
      if (unit.IsTechtreeResearchesAvailableModified)
        return unit.TechtreeResearchesAvailable;
        
      return Array.Empty<Upgrade>();
    }
    
    public static string GetTextNameSafe(this Unit unit)
    {
      try
      {
        return unit.TextName;
      }
      catch
      {
        return "";
      }
    }
    
    public static string GetExtendedTooltipSafe(this Unit unit)
    {
      try
      {
        return unit.TextTooltipExtended;
      }
      catch
      {
        return "";
      }
    }

    public static int GetPrioritySafe(this Unit unit)
    {
      try
      {
        var (x, y) = (unit.ArtButtonPositionX, unit.ArtButtonPositionY);
        return x + y * 10;
      }
      catch
      {
        return 0;
      }
    }
  }
}