using MacroTools;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllFactionSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      ScourgeSetup.Setup(preplacedUnitSystem);
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
      IllidanSetup.Setup();
      GilneasSetup.Setup();
      ZandalarSetup.Setup(preplacedUnitSystem);
      GoblinSetup.Setup();
      TwilightSetup.Setup();
      ScarletSetup.Setup(preplacedUnitSystem);
      CthunSetup.Setup();
      ForsakenSetup.Setup();
      DraeneiSetup.Setup();
      NzothSetup.Setup();
      DragonmawSetup.Setup();
    }
  }
}