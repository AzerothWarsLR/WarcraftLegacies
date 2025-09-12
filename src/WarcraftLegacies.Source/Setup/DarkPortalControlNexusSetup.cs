using MacroTools.Extensions;
using MacroTools.Systems;
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
      foreach (var controlNexus in preplacedUnitSystem.GetUnits(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS))
        controlNexus.MakeCapturable();

      //Control Nexus inside Outland
      PlayerUnitEvents.Register(UnitEvent.ChangesOwner, () =>
      {
        var newOwner = GetTriggerUnit().OwningPlayer();
        unit tempQualifier = preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_1.Center);
        SetUnitOwner(tempQualifier, newOwner, true);
        unit tempQualifier1 = preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_2.Center);
        SetUnitOwner(tempQualifier1, newOwner, true);
        unit tempQualifier2 = preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_3.Center);
        SetUnitOwner(tempQualifier2, newOwner, true);
      }, preplacedUnitSystem.GetUnit(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, new Point(3707, -26029)));

      //Control Nexus outside Outland
      PlayerUnitEvents.Register(UnitEvent.ChangesOwner, () =>
      {
        var newOwner = GetTriggerUnit().OwningPlayer();
        unit tempQualifier = preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_1.Center);
        SetUnitOwner(tempQualifier, newOwner, true);
        unit tempQualifier1 = preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_2.Center);
        SetUnitOwner(tempQualifier1, newOwner, true);
        unit tempQualifier2 = preplacedUnitSystem.GetUnit(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_3.Center);
        SetUnitOwner(tempQualifier2, newOwner, true);
      }, preplacedUnitSystem.GetUnit(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, new Point(17411, -17902)));
    }
  }
}