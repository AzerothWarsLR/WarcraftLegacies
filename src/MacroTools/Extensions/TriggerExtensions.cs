using System;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a useful set of extension methods for native Warcraft 3 triggers.
  /// </summary>
  public static class TriggerExtensions
  {
    public static trigger RegisterEnterRegion(this trigger whichTrigger, Rectangle region, boolexpr? filter = null)
    {
      TriggerRegisterEnterRegion(whichTrigger, region.Region, filter);
      return whichTrigger;
    }

    public static trigger RegisterLeaveRegion(this trigger whichTrigger, Rectangle region, boolexpr? filter = null)
    {
      TriggerRegisterLeaveRegion(whichTrigger, region.Region, filter);
      return whichTrigger;
    }
    
    public static trigger RegisterUnitEvent(this trigger whichTrigger, unit whichUnit, unitevent whichEvent)
    {
      TriggerRegisterUnitEvent(whichTrigger, whichUnit, whichEvent);
      return whichTrigger;
    }
    
    public static trigger AddAction(this trigger whichTrigger, Action actionFunc)
    {
      TriggerAddAction(whichTrigger, actionFunc);
      return whichTrigger;
    }
  }
}