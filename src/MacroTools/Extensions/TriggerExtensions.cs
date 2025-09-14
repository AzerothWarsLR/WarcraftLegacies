using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;
using static War3Api.Common;

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
    public static void RegisterSharedChatEvent(this trigger whichTrigger, string chatMessageToDetect,
      bool exactMatchOnly)
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        TriggerRegisterPlayerChatEvent(whichTrigger, player, chatMessageToDetect, exactMatchOnly);
    }

    /// <summary>
    /// Registers a key event for all players.
    /// </summary>
    public static void RegisterSharedKeyEvent(this trigger whichTrigger, oskeytype key, int metaKey, bool keyDown)
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        BlzTriggerRegisterPlayerKeyEvent(whichTrigger, player, key, metaKey, keyDown);
    }

    public static void RegisterEnterRegion(this trigger whichTrigger, Rectangle region, boolexpr? filter = null)
    {
      TriggerRegisterEnterRegion(whichTrigger, region.Region, filter);
    }

    public static void RegisterEnterRegions(this trigger whichTrigger, IEnumerable<Rectangle> regions,
      boolexpr? filter = null)
    {
      foreach (var region in regions)
        TriggerRegisterEnterRegion(whichTrigger, region.Region, filter);
    }

    public static void RegisterLeaveRegion(this trigger whichTrigger, Rectangle region, boolexpr? filter = null)
    {
      TriggerRegisterLeaveRegion(whichTrigger, region.Region, filter);
    }

    public static void RegisterLeaveRegions(this trigger whichTrigger, IEnumerable<Rectangle> regions,
      boolexpr? filter = null)
    {
      foreach (var region in regions)
        TriggerRegisterLeaveRegion(whichTrigger, region.Region, filter);
    }

    public static void RegisterLifeEvent(this trigger whichTrigger, unit whichUnit, unitstate unitState,
      limitop limitOp, float limitValue)
    {
      TriggerRegisterUnitStateEvent(whichTrigger, whichUnit, unitState, limitOp, limitValue);
    }

    public static void RegisterUnitEvent(this trigger whichTrigger, unit whichUnit, unitevent whichEvent)
    {
      TriggerRegisterUnitEvent(whichTrigger, whichUnit, whichEvent);
    }

    public static void RegisterDialogButtonEvent(this trigger whichTrigger, button whichButton)
    {
      TriggerRegisterDialogButtonEvent(whichTrigger, whichButton);
    }

    public static void AddAction(this trigger whichTrigger, Action actionFunc)
    {
      TriggerAddAction(whichTrigger, actionFunc);
    }

    /// <summary>
    /// Destroys the trigger.
    /// </summary>
    public static void Destroy(this trigger whichTrigger) => DestroyTrigger(whichTrigger);

    /// <summary>
    /// Immediately executes all of the trigger's actions.
    /// </summary>
    public static void Execute(this trigger whichTrigger)
    {
      TriggerExecute(whichTrigger);
    }
  }
}