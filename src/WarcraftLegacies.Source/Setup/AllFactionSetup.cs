using MacroTools;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllFactionSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      LegionSetup.Setup(preplacedUnitSystem);
      LordaeronSetup.Setup(preplacedUnitSystem);
      QuelthalasSetup.Setup(preplacedUnitSystem);
      SentinelsSetup.Setup(preplacedUnitSystem, allLegendSetup);
      DruidsSetup.Setup(preplacedUnitSystem, allLegendSetup);
      FelHordeSetup.Setup(preplacedUnitSystem);
      WarsongSetup.Setup(preplacedUnitSystem);
      StormwindSetup.Setup();
      IronforgeSetup.Setup(preplacedUnitSystem);
      IllidariSetup.Setup();
      GoblinSetup.Setup(preplacedUnitSystem);
      DraeneiSetup.Setup();
      ZandalarSetup.Setup(preplacedUnitSystem);
      SunfurySetup.Setup(preplacedUnitSystem);
      CthunSetup.Setup(preplacedUnitSystem);
      NazjatarSetup.Setup(preplacedUnitSystem);
      BlackEmpireSetup.Setup(preplacedUnitSystem);
      TwilightHammerSetup.Setup(preplacedUnitSystem);
    }
  }
}