using MacroTools;
using MacroTools.Extensions;
using MacroTools.Instances;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Responsible for setting up all <see cref="Instance"/>s.
  /// </summary>
  public static class InstanceSetup
  {
    /// <summary>
    /// Sets up all <see cref="Instance"/>s.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      InstanceSystem.Register(
        new Instance("Argus", Regions.MonolithNoBuild)
      );

      InstanceSystem.Register(
        new Instance("Outland", Regions.InstanceOutland)
      );

      var proudmooreFlagshipUnit = preplacedUnitSystem.GetUnit(Constants.UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS);
      var proudmooreFlagshipInterior = new Instance("Proudmoore Flagship Interior", Regions.ShipAmbient);
      proudmooreFlagshipInterior.AddDependency(proudmooreFlagshipUnit);
      proudmooreFlagshipInterior.AddDependency(preplacedUnitSystem.GetUnit(Constants.UNIT_H09D_FLEETMASTER_S_TABLE_KUL_TIRAS_OTHER));
      proudmooreFlagshipInterior.AddGate(new Gate(
        () => Regions.ShipInside.Center,
        () => proudmooreFlagshipUnit.GetPosition()));
      InstanceSystem.Register(proudmooreFlagshipInterior);

      var draeneiShipInterior = new Instance("Draenei Ship interior", Regions.Exodar_Interior_All);
      var exodarRegalis = preplacedUnitSystem.GetUnit(Constants.UNIT_E01X_EXODAR_REGALIS_DRAENEI_SPACESHIP);
      draeneiShipInterior.AddDependency(exodarRegalis);
      draeneiShipInterior.AddDependency(preplacedUnitSystem.GetUnit(Constants.UNIT_N00E_DIMENSIONAL_GENERATOR_DRAENEI));
      draeneiShipInterior.AddGate(new Gate(
        () => Regions.Exodar_South_Interior.Center, 
        () => exodarRegalis.GetPosition()));
      InstanceSystem.Register(draeneiShipInterior);

      InstanceSystem.Register(new Instance("Artifact dummy area", Regions.ArtifactDummyInstance));
    }
  }
}