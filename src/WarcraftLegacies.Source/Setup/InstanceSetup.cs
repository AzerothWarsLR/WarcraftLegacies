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
    public static void Setup()
    {
      InstanceSystem.Register(
        new Instance("Barrow Deeps", Regions.InstanceBarrowDeeps)
      );

      InstanceSystem.Register(
        new Instance("Twisting Nether", Regions.TwistingNether)
      );

      InstanceSystem.Register(
        new Instance("Dire Maul", Regions.InstanceDireMaul)
      );

      var scholomance = new Instance("Scholomance", Regions.InstanceScholomance);
      scholomance.AddDependency(PreplacedUnitSystem.GetUnit(Constants.UNIT_N035_SCHOLOMANCE));
      InstanceSystem.Register(scholomance);

      InstanceSystem.Register(
        new Instance("Blackrock Depths", Regions.InstanceBlackrock)
      );

      InstanceSystem.Register(
        new Instance("Tomb of Sargeras", Regions.InstanceSargerasTomb)
      );

      InstanceSystem.Register(
        new Instance("Azjol'nerub", Regions.InstanceAzjolNerub)
      );


      InstanceSystem.Register(
        new Instance("Outland", Regions.InstanceOutland)
      );


      InstanceSystem.Register(
        new Instance("Nazjatar", Regions.InstanceNazjatar)
      );

      InstanceSystem.Register(
        new Instance("Dalaran Dungeons", new[]
        {
          Regions.InstanceDalaranDungeon1,
          Regions.InstanceDalaranDungeon2,
          Regions.InstanceDalaranDungeon3
        })
      );

      var naxxramas = new Instance("Naxxramas", Regions.NaxxramasInside);
      naxxramas.AddDependency(PreplacedUnitSystem.GetUnit(Constants.UNIT_U01X_HEART_OF_NAXXRAMAS));
      naxxramas.AddDependency(PreplacedUnitSystem.GetUnit(Constants.UNIT_E013_NAXXRAMAS_SCOURGE));
      InstanceSystem.Register(naxxramas);

      var scarletMonastery = new Instance("Scarlet Monastery", Regions.ScarletAmbient);
      scarletMonastery.AddDependency(PreplacedUnitSystem.GetUnit(Constants.UNIT_H00T_SCARLET_MONASTERY_LORDAERON));
      InstanceSystem.Register(scarletMonastery);

      var proudmooreFlagshipInterior = new Instance("Proudmoore Flagship Interior", Regions.ShipAmbient);
      proudmooreFlagshipInterior.AddDependency(PreplacedUnitSystem.GetUnit(Constants.UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS));
      proudmooreFlagshipInterior.AddDependency(PreplacedUnitSystem.GetUnit(Constants.UNIT_H09D_FLEETMASTER_S_TABLE));
      InstanceSystem.Register(proudmooreFlagshipInterior);
    }
  }
}