using MacroTools.Extensions;
using MacroTools.PreplacedWidgets;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// When a Dark Portal Control Nexus is captured, transfer the ownership of the Dark Portal portals to the capturing player.
/// </summary>
public static class DarkPortalControlNexusSetup
{
  /// <summary>
  /// Sets up <see cref="DarkPortalControlNexusSetup"/>.
  /// </summary>
  public static void Setup()
  {
    foreach (var controlNexus in AllPreplacedWidgets.Units.GetAll(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS))
    {
      controlNexus.MakeCapturable();
    }

    //Control Nexus inside Outland
    PlayerUnitEvents.Register(UnitEvent.ChangesOwner, () =>
    {
      var newOwner = @event.Unit.Owner;
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_1.Center).SetOwner(newOwner);
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_2.Center).SetOwner(newOwner);
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_3.Center).SetOwner(newOwner);
    }, AllPreplacedWidgets.Units.GetClosest(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, 3707, -26029));

    //Control Nexus outside Outland
    PlayerUnitEvents.Register(UnitEvent.ChangesOwner, () =>
    {
      var newOwner = @event.Unit.Owner;
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_1.Center).SetOwner(newOwner);
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_2.Center).SetOwner(newOwner);
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_3.Center).SetOwner(newOwner);
    }, AllPreplacedWidgets.Units.GetClosest(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, 17411, -17902));
  }
}
