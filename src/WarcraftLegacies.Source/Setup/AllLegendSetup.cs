using MacroTools;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllLegendSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      LegendDalaran.Setup(preplacedUnitSystem);
      LegendDraenei.Setup(preplacedUnitSystem);
      LegendDruids.Setup(preplacedUnitSystem);
      LegendFelHorde.Setup(preplacedUnitSystem);
      LegendForsaken.Setup();
      LegendFrostwolf.Setup(preplacedUnitSystem);
      LegendGilneas.Setup();
      LegendGoblin.Setup(preplacedUnitSystem);
      LegendIronforge.Setup(preplacedUnitSystem);
      LegendKultiras.Setup(preplacedUnitSystem);
      LegendLegion.Setup(preplacedUnitSystem);
      LegendLordaeron.Setup(preplacedUnitSystem, artifactSetup);
      LegendNaga.Setup();
      LegendNeutral.Setup(preplacedUnitSystem);
      LegendQuelthalas.Setup(preplacedUnitSystem);
      LegendScarlet.Setup();
      LegendScourge.Setup(preplacedUnitSystem);
      LegendSentinels.Setup(preplacedUnitSystem);
      LegendStormwind.Setup(preplacedUnitSystem);
      LegendTroll.Setup();
      LegendWarsong.Setup(preplacedUnitSystem);
      LegendDragonmaw.Setup(preplacedUnitSystem);
    }
  }
}