using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
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
      LegendSilvermoon = new Legend();
      LegendSilvermoon.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h003"));
      LegendSilvermoon.DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies.";
      LegendSilvermoon.IsCapital = true;

      LegendSunwell = new Legend();
      LegendSunwell.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n001"));
      LegendSunwell.Capturable = true;
      LegendSunwell.IsCapital = true;

      LegendAnasterian = new Legend();
      LegendAnasterian.UnitType = FourCC("H00Q");
      LegendAnasterian.PlayerColor = PLAYER_COLOR_MAROON;
      LegendAnasterian.AddUnitDependency(LegendSunwell.Unit);
      LegendAnasterian.Essential = true;
      LegendAnasterian.StartingXp = 1000;

      LegendRommath = new Legend();
      LegendRommath.UnitType = FourCC("H04F");
      LegendRommath.StartingXp = 1800;

      LegendJennalla = new Legend();
      LegendJennalla.UnitType = FourCC("H02B");

      LegendPathaleon = new Legend();
      LegendPathaleon.UnitType = FourCC("H098");
      LegendPathaleon.StartingXp = 1800;

      LegendSylvanas = new Legend();
      LegendSylvanas.UnitType = FourCC("Hvwd");
      LegendSylvanas.PlayerColor = PLAYER_COLOR_GREEN;

      LegendKael = new Legend();
      LegendKael.PlayerColor = PLAYER_COLOR_RED;
      LegendKael.UnitType = FourCC("Hkal");
      LegendKael.StartingXp = 1800;

      LegendLorthemar = new Legend();
      LegendLorthemar.UnitType = FourCC("H02E");
      LegendLorthemar.StartingXp = 2800;

      LegendKiljaeden = new Legend();
      LegendKiljaeden.UnitType = FourCC("U004");
      LegendKiljaeden.PermaDies = true;
      LegendKiljaeden.StartingXp = 10800;
      LegendKiljaeden.DeathMessage =
        "Kil'jaeden the Deceiver has been annihilated, but it is too late for the Blood Elves, who will continue to live && die with demonic taint coursing through their veins.";
    }
  }
}