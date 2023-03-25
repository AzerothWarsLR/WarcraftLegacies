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

      InstanceSystem.Register(new Instance("Artifact dummy area", Regions.ArtifactDummyInstance));
    }
  }
}