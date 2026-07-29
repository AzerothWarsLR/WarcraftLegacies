using WarcraftLegacies.Source.Factions.Dalaran.Mechanics;
using WarcraftLegacies.Source.Factions.Legion.Mechanics;
using WarcraftLegacies.Source.Factions.Lordaeron.Mechanics;
using WarcraftLegacies.Source.Factions.Quelthalas.Mechanics;
using WarcraftLegacies.Source.Factions.Scourge.Mechanics;
using WarcraftLegacies.Source.GameLogic.Rocks;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Applies Hard mode's game-start effects: the universal effects every faction would normally have by this
/// stage of the game (Flight/Navigation/Deep Burrow unlocked, every path-blocking rock removed), then each
/// covered faction's own "already at invasion readiness" setup - see the corresponding per-faction setup class
/// (e.g. <see cref="ScourgeHardModeSetup"/>) for what that means for each faction covered so far.
/// </summary>
public static class HardModeSetting
{
  /// <summary>
  /// Everything Hard mode does. Called when Hard wins the top-level Difficulty vote, since in that path the
  /// Custom Options page (and with it, the separate Flight/Navigation Availability votes) never shows - this
  /// has to grant those techs itself or nothing would.
  /// </summary>
  public static void Apply()
  {
    GrantUniversalTechUnlocks();
    ApplyWithoutTechUnlocks();
  }

  /// <summary>
  /// Everything <see cref="Apply"/> does except granting Flight/Navigation/Deep Burrow. Used by the "Early
  /// Game (PvE)" Custom Option, which sits on the same page as the dedicated Flight/Navigation Availability
  /// votes - granting those techs here too would silently override whatever the player explicitly chose there.
  /// </summary>
  public static void ApplyWithoutTechUnlocks()
  {
    RockSystem.RemoveAll();
    ScourgeHardModeSetup.Setup();
    // Legion must run after Scourge - Gundrak sits in the region Scourge's setup sweeps for capturable
    // capitals, but actually belongs to Legion, so this order lets Legion's explicit award win out.
    LegionHardModeSetup.Setup();
    LordaeronHardModeSetup.Setup();
    DalaranHardModeSetup.Setup();
    QuelthalasHardModeSetup.Setup();
  }

  private static void GrantUniversalTechUnlocks()
  {
    ResearchGranting.GrantToAllPlayers(UPGRADE_R09X_FLIGHT_UNIVERSAL_UPGRADE);
    ResearchGranting.GrantToAllPlayers(UPGRADE_R04R_NAVIGATION_UNIVERSAL_UPGRADE);
    // Ahn'Qiraj has no ships - Deep Burrow is its equivalent way to cross water, so it belongs here too.
    ResearchGranting.GrantToAllPlayers(UPGRADE_RDBD_DEEP_BURROW_C_THUN);
  }
}
