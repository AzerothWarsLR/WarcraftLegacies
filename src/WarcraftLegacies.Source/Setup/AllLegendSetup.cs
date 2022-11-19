using MacroTools;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllLegendSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendDalaran.Setup(preplacedUnitSystem);
      LegendDraenei.Setup(preplacedUnitSystem);
      LegendDruids.Setup(preplacedUnitSystem);
      LegendFelHorde.Setup(preplacedUnitSystem);
      LegendForsaken.Setup(preplacedUnitSystem);
      LegendFrostwolf.Setup(preplacedUnitSystem);
      LegendGilneas.Setup();
      LegendGoblin.Setup(preplacedUnitSystem);
      LegendIronforge.Setup(preplacedUnitSystem);
      LegendKultiras.Setup(preplacedUnitSystem);
      LegendLegion.Setup(preplacedUnitSystem);
      LegendLordaeron.Setup(preplacedUnitSystem);
      LegendNaga.Setup(preplacedUnitSystem);
      LegendNeutral.Setup(preplacedUnitSystem);
      LegendQuelthalas.Setup(preplacedUnitSystem);
      LegendScarlet.Setup();
      LegendScourge.Setup(preplacedUnitSystem);
      LegendSentinels.Setup(preplacedUnitSystem);
      LegendStormwind.Setup(preplacedUnitSystem);
      LegendTroll.Setup();
      LegendTwilight.Setup(preplacedUnitSystem);
      LegendWarsong.Setup(preplacedUnitSystem);
      LegendDragonmaw.Setup(preplacedUnitSystem);
    }
  }
}