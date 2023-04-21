using MacroTools;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllFactionSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      ScourgeSetup.Setup(preplacedUnitSystem, artifactSetup.HelmOfDomination);
      LegionSetup.Setup(preplacedUnitSystem);
      LordaeronSetup.Setup(preplacedUnitSystem);
      DalaranSetup.Setup(preplacedUnitSystem);
      QuelthalasSetup.Setup(preplacedUnitSystem);
      SentinelsSetup.Setup(preplacedUnitSystem);
      DruidsSetup.Setup(preplacedUnitSystem);
      FelHordeSetup.Setup(preplacedUnitSystem);
      FrostwolfSetup.Setup(preplacedUnitSystem);
      WarsongSetup.Setup(preplacedUnitSystem);
      StormwindSetup.Setup();
      IronforgeSetup.Setup(preplacedUnitSystem);
      KultirasSetup.Setup(preplacedUnitSystem);
      IllidariSetup.Setup();
      GoblinSetup.Setup(preplacedUnitSystem);
      DraeneiSetup.Setup();
      ZandalarSetup.Setup(preplacedUnitSystem);

      CthunSetup.Setup(preplacedUnitSystem);
      NazjatarSetup.Setup(preplacedUnitSystem);
      BlackEmpireSetup.Setup(preplacedUnitSystem);

      CrisisCaptainSetup.Setup(preplacedUnitSystem);
      CrisisFootmanSetup.Setup(preplacedUnitSystem);
    }
  }
}