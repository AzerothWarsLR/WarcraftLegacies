using System.Linq;
using WCSharp.Shared;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// Responsible for determining whether or not the map should be run in test mode.
  /// </summary>
  public static partial class TestMode
  {
    /// <summary>
    /// If true, cheats are active for all players.
    /// </summary>
    public static bool AreCheatsActive { get; private set; }

    /// <summary>
    /// Returns true if <see cref="GetTriggerPlayer"/> has cheats enabled.
    /// </summary>
    public static bool CheatCondition()
    {
      var triggerPlayerName = GetPlayerName(GetTriggerPlayer());
      return triggerPlayerName is "YakaryBovine#6863" or "Lordsebas#11619" || AreCheatsActive;
    }

    /// <summary>
    /// Sets up <see cref="TestMode"/>.
    /// </summary>
    public static void Setup()
    {
      AreCheatsActive = Util.EnumeratePlayers().Count(player =>
        GetPlayerSlotState(player) == PLAYER_SLOT_STATE_PLAYING && GetPlayerController(player) == MAP_CONTROL_USER) < 2;

    }
  }
}