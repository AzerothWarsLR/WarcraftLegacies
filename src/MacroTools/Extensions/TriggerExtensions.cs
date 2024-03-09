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
    public static void RegisterSharedChatEvent(this trigger whichTrigger, string chatMessageToDetect,
      bool exactMatchOnly)
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        TriggerRegisterPlayerChatEvent(whichTrigger, player, chatMessageToDetect, exactMatchOnly);
    }
    
    public static void RegisterEnterRegions(this trigger whichTrigger, IEnumerable<Rectangle> regions,
      boolexpr? filter = null)
    {
      foreach (var region in regions)
        TriggerRegisterEnterRegion(whichTrigger, region.Region, filter);
    }
    
    public static void RegisterLeaveRegions(this trigger whichTrigger, IEnumerable<Rectangle> regions,
      boolexpr? filter = null)
    {
      foreach (var region in regions)
        TriggerRegisterLeaveRegion(whichTrigger, region.Region, filter);
    }

    public static void RegisterLifeEvent(this trigger whichTrigger, unit whichUnit, unitstate unitState,
      limitop limitOp, float limitValue) =>
      TriggerRegisterUnitStateEvent(whichTrigger, whichUnit, unitState, limitOp, limitValue);

    public static void RegisterDialogButtonEvent(this trigger whichTrigger, button whichButton) =>
      TriggerRegisterDialogButtonEvent(whichTrigger, whichButton);
  }
}