using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendQuelthalas
  {
    public static Legend LegendAnasterian { get; private set; }
    public static Legend LegendRommath { get; private set; }
    public static Legend LegendJennalla { get; private set; }
    public static Legend LegendSylvanas { get; private set; }
    public static Legend LegendKorialstrasz { get; private set; }
    public static Legend LegendKael { get; private set; }
    public static Legend LegendLorthemar { get; private set; }
    public static Legend LegendKiljaeden { get; private set; }
    public static Legend LegendPathaleon { get; private set; }
    public static Legend LegendSilvermoon { get; private set; }
    public static Legend LegendSunwell { get; private set; }

    public static void Setup()
    {
      LegendSilvermoon = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h003")),
        DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies.",
        IsCapital = true
      };
      Legend.Register(LegendSilvermoon);

      LegendSunwell = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n001")),
        Capturable = true,
        IsCapital = true
      };
      Legend.Register(LegendSunwell);

      LegendAnasterian = new Legend
      {
        UnitType = FourCC("H00Q"),
        PlayerColor = PLAYER_COLOR_MAROON
      };
      LegendAnasterian.AddUnitDependency(LegendSunwell.Unit);
      LegendAnasterian.Essential = true;
      LegendAnasterian.StartingXp = 1000;
      Legend.Register(LegendAnasterian);

      LegendRommath = new Legend
      {
        UnitType = FourCC("H04F"),
        StartingXp = 1800
      };
      Legend.Register(LegendRommath);

      LegendJennalla = new Legend
      {
        UnitType = FourCC("H02B")
      };
      Legend.Register(LegendJennalla);

      LegendPathaleon = new Legend
      {
        UnitType = FourCC("H098"),
        StartingXp = 1800
      };
      Legend.Register(LegendPathaleon);

      LegendSylvanas = new Legend
      {
        UnitType = FourCC("Hvwd"),
        PlayerColor = PLAYER_COLOR_GREEN
      };
      Legend.Register(LegendSylvanas);

      LegendKael = new Legend
      {
        PlayerColor = PLAYER_COLOR_RED,
        UnitType = FourCC("Hkal"),
        StartingXp = 1800
      };
      Legend.Register(LegendKael);

      LegendLorthemar = new Legend
      {
        UnitType = FourCC("H02E"),
        StartingXp = 2800
      };
      Legend.Register(LegendLorthemar);

      LegendKiljaeden = new Legend
      {
        UnitType = FourCC("U004"),
        PermaDies = true,
        StartingXp = 10800,
        DeathMessage =
          "Kil'jaeden the Deceiver has been annihilated, but it is too late for the Blood Elves, who will continue to live and die with demonic taint coursing through their veins."
      };
      Legend.Register(LegendKiljaeden);
    }
  }
}