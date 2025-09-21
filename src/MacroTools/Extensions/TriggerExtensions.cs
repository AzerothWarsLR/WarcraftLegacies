using System.Collections.Generic;
using WCSharp.Api.Enums;
using WCSharp.Shared.Data;

namespace MacroTools.Extensions;

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
    {
      whichTrigger.RegisterPlayerChatEvent(player, chatMessageToDetect, exactMatchOnly);
    }
  }

  /// <summary>
  /// Registers a key event for all players.
  /// </summary>
  public static void RegisterSharedKeyEvent(this trigger whichTrigger, oskeytype key, MetaKey metaKey, bool keyDown)
  {
    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichTrigger.RegisterPlayerKeyEvent(player, key, metaKey, keyDown);
    }
  }

  public static void RegisterEnterRegions(this trigger whichTrigger, IEnumerable<Rectangle> regions,
    boolexpr? filter = null)
  {
    foreach (var region in regions)
    {
      whichTrigger.RegisterEnterRegion(region.Region, filter);
    }
  }

  public static void RegisterLeaveRegions(this trigger whichTrigger, IEnumerable<Rectangle> regions,
    boolexpr? filter = null)
  {
    foreach (var region in regions)
    {
      whichTrigger.RegisterLeaveRegion(region.Region, filter);
    }
  }
}
