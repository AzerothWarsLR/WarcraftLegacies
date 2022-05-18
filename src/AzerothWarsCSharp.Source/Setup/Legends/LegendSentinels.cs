using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendSentinels
  {
    public static Legend legendMaiev;
    public static Legend legendTyrande;
    public static Legend legendShandris;
    public static Legend legendJarod;
    public static Legend legendAuberdine;
    public static Legend legendFeathermoon;

    public static void Setup()
    {
      legendMaiev = new Legend
      {
        UnitType = FourCC("Ewrd")
      };
      Legend.Register(legendMaiev);

      legendAuberdine = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("e00J"))
      };
      Legend.Register(legendAuberdine);

      legendFeathermoon = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("e00M"))
      };
      Legend.Register(legendFeathermoon);

      legendTyrande = new Legend
      {
        UnitType = FourCC("Etyr"),
        PlayerColor = PLAYER_COLOR_CYAN
      };
      Legend.Register(legendTyrande);

      legendShandris = new Legend
      {
        UnitType = FourCC("E002"),
        StartingXp = 1000
      };
      Legend.Register(legendShandris);

      legendJarod = new Legend
      {
        UnitType = FourCC("O02E"),
        StartingXp = 4000
      };
      Legend.Register(legendJarod);
    }
  }
}