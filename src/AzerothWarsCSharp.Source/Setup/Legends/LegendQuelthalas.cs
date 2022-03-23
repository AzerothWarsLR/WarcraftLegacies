using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendQuelthalas
  {
    public static Legend legendAnasterian;
    public static Legend legendRommath;
    public static Legend legendJennalla;
    public static Legend legendSylvanas;
    public static Legend legendKorialstrasz;
    public static Legend legendKael;
    public static Legend legendLorthemar;
    public static Legend legendKiljaeden;
    public static Legend legendPathaleon;

    public static Legend legendSilvermoon;
    public static Legend legendSunwell;


    public static void Setup()
    {
      legendSilvermoon = new Legend();
      legendSilvermoon.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h003"));
      legendSilvermoon.DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies.";
      legendSilvermoon.IsCapital = true;

      legendSunwell = new Legend();
      legendSunwell.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n001"));
      legendSunwell.Capturable = true;
      legendSunwell.IsCapital = true;

      legendAnasterian = new Legend();
      legendAnasterian.UnitType = FourCC("H00Q");
      legendAnasterian.PlayerColor = PLAYER_COLOR_MAROON;
      legendAnasterian.AddUnitDependency(legendSunwell.Unit);
      legendAnasterian.Essential = true;
      legendAnasterian.StartingXp = 1000;

      legendRommath = new Legend();
      legendRommath.UnitType = FourCC("H04F");
      legendRommath.StartingXp = 1800;

      legendJennalla = new Legend();
      legendJennalla.UnitType = FourCC("H02B");

      legendPathaleon = new Legend();
      legendPathaleon.UnitType = FourCC("H098");
      legendPathaleon.StartingXp = 1800;

      legendSylvanas = new Legend();
      legendSylvanas.UnitType = FourCC("Hvwd");
      legendSylvanas.PlayerColor = PLAYER_COLOR_GREEN;

      legendKael = new Legend();
      legendKael.PlayerColor = PLAYER_COLOR_RED;
      legendKael.UnitType = FourCC("Hkal");
      legendKael.StartingXp = 1800;

      legendLorthemar = new Legend();
      legendLorthemar.UnitType = FourCC("H02E");
      legendLorthemar.StartingXp = 2800;

      legendKiljaeden = new Legend();
      legendKiljaeden.UnitType = FourCC("U004");
      legendKiljaeden.PermaDies = true;
      legendKiljaeden.StartingXp = 10800;
      legendKiljaeden.DeathMessage =
        "KilFourCC(jaeden the Deceiver has been annihilated, but it is too late for the Blood Elves, who will continue to live && die with demonic taint coursing through their veins.";
    }
  }
}