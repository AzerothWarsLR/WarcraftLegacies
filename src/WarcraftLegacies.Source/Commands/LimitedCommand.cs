using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Commands
{
  /// <summary>
  /// Pings all units belonging to the user that have a limit on how many of them can be made.
  /// </summary>
  public static class LimitedCommand
  {
    private const string Command = "-limited";

    /// <summary>
    /// Sets up <see cref="LimitedCommand"/>.
    /// </summary>
    public static void Setup()
    {
      var trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        TriggerRegisterPlayerChatEvent(trig, player, Command, true);
      TriggerAddAction(trig, Actions);
    }

    private static void Actions()
    {
      var triggerPlayer = GetTriggerPlayer();
      var triggerFaction = triggerPlayer.GetFaction();
      if (triggerFaction == null)
        return;

      foreach (var unit in CreateGroup().EnumUnitsOfPlayer(triggerPlayer).EmptyToList())
      {
        if (IsPingable(triggerFaction, unit) && GetLocalPlayer() == triggerPlayer)
          PingMinimap(GetUnitX(unit), GetUnitY(unit), 5);
      }
    }

    private static bool IsPingable(Faction whichFaction, unit whichUnit)
    {
      var unitTypeId = GetUnitTypeId(whichUnit);
      var objectLimit = whichFaction.GetObjectLimit(GetUnitTypeId(whichUnit));
      return objectLimit < Faction.UNLIMITED && GetUnitTypeId(whichUnit) == whichFaction.GetObjectLimit(unitTypeId) &&
             BlzIsUnitSelectable(whichUnit);
    }
  }
}