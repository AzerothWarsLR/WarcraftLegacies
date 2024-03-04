using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a useful set of extension methods for native Warcraft 3 triggers.
  /// </summary>
  public static class TriggerExtensions
  {
    /// <summary>
    /// Causes the <see cref="trigger"/> to fire when any player executes the specified chat command.
    /// </summary>
    public static trigger RegisterSharedChatEvent(this trigger whichTrigger, string chatMessageToDetect, bool exactMatchOnly)
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        TriggerRegisterPlayerChatEvent(whichTrigger, player, chatMessageToDetect, exactMatchOnly);
      return whichTrigger;
    }
    
    public static trigger RegisterEnterRegion(this trigger whichTrigger, Rectangle region, boolexpr? filter = null)
    {
      TriggerRegisterEnterRegion(whichTrigger, region.Region, filter);
      return whichTrigger;
    }
    
    public static trigger RegisterEnterRegions(this trigger whichTrigger, IEnumerable<Rectangle> regions, boolexpr? filter = null)
    {
      foreach (var region in regions)
        TriggerRegisterEnterRegion(whichTrigger, region.Region, filter);
      return whichTrigger;
    }

    public static trigger RegisterLeaveRegion(this trigger whichTrigger, Rectangle region, boolexpr? filter = null)
    {
      TriggerRegisterLeaveRegion(whichTrigger, region.Region, filter);
      return whichTrigger;
    }
    
    public static trigger RegisterLeaveRegions(this trigger whichTrigger, IEnumerable<Rectangle> regions, boolexpr? filter = null)
    {
      foreach (var region in regions)
        TriggerRegisterLeaveRegion(whichTrigger, region.Region, filter);
      return whichTrigger;
    }

    public static trigger RegisterLifeEvent(this trigger whichTrigger, unit whichUnit, unitstate unitState, limitop limitOp, float limitValue)
    {
      TriggerRegisterUnitStateEvent(whichTrigger, whichUnit, unitState, limitOp, limitValue);
      return whichTrigger;
    }
    
    public static trigger RegisterUnitEvent(this trigger whichTrigger, unit whichUnit, unitevent whichEvent)
    {
      TriggerRegisterUnitEvent(whichTrigger, whichUnit, whichEvent);
      return whichTrigger;
    }

    public static trigger RegisterDialogButtonEvent(this trigger whichTrigger, button whichButton)
    {
      TriggerRegisterDialogButtonEvent(whichTrigger, whichButton);
      return whichTrigger;
    }
    
    public static trigger AddAction(this trigger whichTrigger, Action actionFunc)
    {
      TriggerAddAction(whichTrigger, actionFunc);
      return whichTrigger;
    }
    
    /// <summary>
    /// Destroys the trigger.
    /// </summary>
    public static void Destroy(this trigger whichTrigger) => DestroyTrigger(whichTrigger);
  }
}