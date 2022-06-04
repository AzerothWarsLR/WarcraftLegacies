using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Instances;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class InstanceSetup
  {
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

      InstanceSystem.Register(
        new Instance("Scholomance", Regions.InstanceScholomance)
      );

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
    }
  }
}