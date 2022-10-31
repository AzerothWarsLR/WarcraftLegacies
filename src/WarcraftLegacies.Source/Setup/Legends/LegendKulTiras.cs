using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendKultiras
  {
    public static Legend LegendAdmiral { get; private set; }
    public static Legend LegendLucille { get; private set; }
    public static Legend LegendKatherine { get; private set; }
    public static Legend LegendBoralus { get; private set; }
    public static Legend Flagship { get; private set; }

    public static void Setup()
    {
      LegendAdmiral = new Legend
      {
        UnitType = FourCC("Hapm")
      };
      Legend.Register(LegendAdmiral);

      LegendLucille = new Legend
      {
        UnitType = FourCC("E016"),
        StartingXp = 2800
      };
      Legend.Register(LegendLucille);

      LegendKatherine = new Legend
      {
        UnitType = FourCC("H05L"),
        StartingXp = 1200
      };
      Legend.Register(LegendKatherine);

      LegendBoralus = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H046_BORALUS_KEEP_KUL_TIRAS),
        DeathMessage = "Boralus Keep has fallen" //Todo: pointless flavour
      };
      Legend.Register(LegendBoralus);

      Flagship = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS)
      };
      Flagship.Unit.SetInvulnerable(true);
      Flagship.Unit.Pause(true);
    }
  }
}