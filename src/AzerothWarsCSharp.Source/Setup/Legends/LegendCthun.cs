using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
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
        DeathMessage =
          "C'thun, God of the Qiraji, was once defeated by the Titans, and again by the combined Dragonflights. " +
          "Today he experiences his third defeat his first true death."
      };
      Legend.Register(legendCthun);

      legendSkeram = new Legend
      {
        UnitType = FourCC("E005"),
        PlayerColor = PLAYER_COLOR_RED,
        Name = "Prophet Skeram"
      };
      Legend.Register(legendSkeram);

      legendGatesahnqiraj = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h02U"))
      };

      legendYor = new Legend
      {
        UnitType = FourCC("U02A"),
        StartingXp = 8800
      };
      Legend.Register(legendYor);
    }
  }
}