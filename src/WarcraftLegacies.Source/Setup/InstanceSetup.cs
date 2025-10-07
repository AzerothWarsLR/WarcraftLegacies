using MacroTools.Extensions;
using MacroTools.Instances;
using MacroTools.Systems;

namespace WarcraftLegacies.Source.Setup;

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
      new Instance(Regions.MonolithNoBuild)
    );

    InstanceSystem.Register(
      new Instance(Regions.InstanceOutland)
    );

    var proudmooreFlagshipUnit = preplacedUnitSystem.GetUnit(UNIT_H05V_PROUDMOORE_FLAGSHIP_KULTIRAS);
    var proudmooreFlagshipInterior = new Instance(Regions.ShipAmbient);
    proudmooreFlagshipInterior.AddDependency(proudmooreFlagshipUnit);
    proudmooreFlagshipInterior.AddDependency(preplacedUnitSystem.GetUnit(UNIT_H09D_FLEETMASTER_S_TABLE_KULTIRAS_OTHER));
    proudmooreFlagshipInterior.AddGate(new Gate(
      () => Regions.ShipInside.Center,
      () => proudmooreFlagshipUnit.GetPosition()));
    InstanceSystem.Register(proudmooreFlagshipInterior);

    InstanceSystem.Register(new Instance(Regions.ArtifactDummyInstance));
  }
}
