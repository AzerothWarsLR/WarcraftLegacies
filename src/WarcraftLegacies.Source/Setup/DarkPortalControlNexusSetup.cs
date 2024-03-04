using MacroTools;
using MacroTools.Extensions;
using WCSharp.Events;
using WCSharp.Shared.Data;


namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// When a Dark Portal Control Nexus is captured, transfer the ownership of the Dark Portal portals to the capturing player.
  /// </summary>
  public static class DarkPortalControlNexusSetup
  {
    /// <summary>
    /// Sets up <see cref="DarkPortalControlNexusSetup"/>.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      foreach (var controlNexus in preplacedUnitSystem.GetUnits(Constants.UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS))
        controlNexus.MakeCapturable();

      //Control Nexus inside Outland
      PlayerUnitEvents.Register(UnitEvent.ChangesOwner, () =>
      {
        var newOwner = GetTriggerUnit().OwningPlayer();
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_1.Center).SetOwner(newOwner);
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_2.Center).SetOwner(newOwner);
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_3.Center).SetOwner(newOwner);
      }, preplacedUnitSystem.GetUnit(Constants.UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, new Point(3707, -26029)));

      //Control Nexus outside Outland
      PlayerUnitEvents.Register(UnitEvent.ChangesOwner, () =>
      {
        var newOwner = GetTriggerUnit().OwningPlayer();
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_1.Center).SetOwner(newOwner);
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_2.Center).SetOwner(newOwner);
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_3.Center).SetOwner(newOwner);
      }, preplacedUnitSystem.GetUnit(Constants.UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, new Point(17411, -17902)));
    }
  }
}