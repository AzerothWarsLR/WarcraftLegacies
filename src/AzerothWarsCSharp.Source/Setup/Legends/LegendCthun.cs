using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendCthun
  {
    public static Legend legendSkeram;
    public static Legend legendGatesahnqiraj;
    public static Legend legendCthun;
    public static Legend legendYor;
    
    public static void Setup()
    {
      legendCthun = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("U00R")),
        PermaDies = true,
        DeathMessage = "C'thun, God of the Qiraji, was once defeated by the Titans, and again by the combined Dragonflights. " +
                       "Today he experiences his third defeat his first true death."
      };

      legendSkeram = new Legend
      {
        UnitType = FourCC("E005"),
        PlayerColor = PLAYER_COLOR_RED,
        Name = "Prophet Skeram"
      };

      legendGatesahnqiraj = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h02U"))
      };

      legendYor = new Legend();
      legendYor.UnitType = FourCC("U02A");
      legendYor.StartingXp = 8800;
    }
  }
}