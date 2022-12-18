using MacroTools;
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
        new Instance("Twisting Nether", Regions.TwistingNether)
      );

      InstanceSystem.Register(
        new Instance("Outland", Regions.InstanceOutland)
      );

      var naxxramas = new Instance("Naxxramas", Regions.NaxxramasInside);
      naxxramas.AddDependency(preplacedUnitSystem.GetUnit(Constants.UNIT_U01X_HEART_OF_NAXXRAMAS));
      naxxramas.AddDependency(preplacedUnitSystem.GetUnit(Constants.UNIT_E013_NAXXRAMAS_SCOURGE));
      InstanceSystem.Register(naxxramas);

      var proudmooreFlagshipInterior = new Instance("Proudmoore Flagship Interior", Regions.ShipAmbient);
      proudmooreFlagshipInterior.AddDependency(preplacedUnitSystem.GetUnit(Constants.UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS));
      proudmooreFlagshipInterior.AddDependency(preplacedUnitSystem.GetUnit(Constants.UNIT_H09D_FLEETMASTER_S_TABLE));
      InstanceSystem.Register(proudmooreFlagshipInterior);

      InstanceSystem.Register(new Instance("Artifact dummy area", Regions.ArtifactDummyInstance));
    }
  }
}