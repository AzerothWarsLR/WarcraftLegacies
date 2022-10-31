using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
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
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h003")),
        DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies."
      };
      Legend.Register(LegendSilvermoon);
      LegendSilvermoon.Unit.SetInvulnerable(true);

      LegendSunwell = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_N001_THE_SUNWELL),
        Capturable = true
      };
      Legend.Register(LegendSunwell);
      LegendSunwell.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS, new Point(20479, 17477)));
      LegendSunwell.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS, new Point(17415, 13196)));

      LegendAnasterian = new Legend
      {
        UnitType = Constants.UNIT_H00Q_KING_OF_QUEL_THALAS_QUEL_THALAS,
        PlayerColor = PLAYER_COLOR_MAROON
      };
      LegendAnasterian.AddUnitDependency(LegendSunwell.Unit);
      LegendAnasterian.StartingXp = 1000;
      Legend.Register(LegendAnasterian);

      LegendRommath = new Legend
      {
        UnitType = Constants.UNIT_H04F_ARCHMAGE_GREEN,
        StartingXp = 1800
      };
      Legend.Register(LegendRommath);

      LegendJennalla = new Legend
      {
        UnitType = Constants.UNIT_H02B_ARCANE_PHANTOM_KHADGAR
      };
      Legend.Register(LegendJennalla);

      LegendPathaleon = new Legend
      {
        UnitType = Constants.UNIT_H098_SUNFURY_MASTERMIND_HIGH_ELVES,
        StartingXp = 1800
      };
      Legend.Register(LegendPathaleon);

      LegendSylvanas = new Legend
      {
        UnitType = Constants.UNIT_HVWD_RANGER_GENERAL_OF_SILVERMOON_QUEL_THALAS,
        PlayerColor = PLAYER_COLOR_GREEN
      };
      Legend.Register(LegendSylvanas);

      LegendKael = new Legend
      {
        PlayerColor = PLAYER_COLOR_RED,
        UnitType = Constants.UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUEL_THALAS,
        StartingXp = 1800
      };
      Legend.Register(LegendKael);

      LegendLorthemar = new Legend
      {
        UnitType = Constants.UNIT_H02E_REGENT_OF_QUEL_THALAS_QUEL_THALAS_VASSAL,
        StartingXp = 2800
      };
      Legend.Register(LegendLorthemar);

      LegendKiljaeden = new Legend
      {
        UnitType = Constants.UNIT_U004_THE_DECEIVER_LEGION,
        PermaDies = true,
        StartingXp = 10800,
        DeathMessage =
          "Kil'jaeden the Deceiver has been annihilated, but it is too late for the Blood Elves, who will continue to live and die with demonic taint coursing through their veins."
      };
      Legend.Register(LegendKiljaeden);
    }
  }
}