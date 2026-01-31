using MacroTools.Extensions;
using MacroTools.Instances;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Responsible for setting up all <see cref="Instance"/>s.
/// </summary>
public static class InstanceSetup
{
  /// <summary>
  /// Sets up all <see cref="Instance"/>s.
  /// </summary>
  public static void Setup()
  {
    InstanceSystem.Register(
      new Instance(Regions.MonolithNoBuild)
    );

    InstanceSystem.Register(
      new Instance(Regions.InstanceOutland)
    );

    var proudmooreFlagshipUnit = AllPreplacedWidgets.Units.Get(UNIT_H05V_PROUDMOORE_FLAGSHIP_KULTIRAS);
    var proudmooreFlagshipInterior = new Instance(Regions.ShipAmbient);
    proudmooreFlagshipInterior.AddDependency(proudmooreFlagshipUnit);
    proudmooreFlagshipInterior.AddDependency(AllPreplacedWidgets.Units.Get(UNIT_H09D_FLEETMASTER_S_TABLE_KULTIRAS_OTHER));
    proudmooreFlagshipInterior.AddGate(new Gate(
      () => Regions.ShipInside.Center,
      () => proudmooreFlagshipUnit.GetPosition()));
    InstanceSystem.Register(proudmooreFlagshipInterior);

    InstanceSystem.Register(new Instance(Regions.ArtifactDummyInstance));
  }
}
