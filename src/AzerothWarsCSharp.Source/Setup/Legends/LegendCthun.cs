using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendCthun
  {
    public static Legend LEGEND_SKERAM;
    public static Legend LEGEND_GATESAHNQIRAJ;
    public static Legend LEGEND_CTHUN;
    public static Legend LEGEND_YOR;

    public static void Setup()
    {
      LEGEND_CTHUN = new Legend
      {
        Unit = gg_unit_U00R_0609,
        PermaDies = true,
        DeathMessage = "C'thun, God of the Qiraji, was once defeated by the Titans, and again by the combined Dragonflights. " +
                       "Today he experiences his third defeat his first true death."
      };

      LEGEND_SKERAM = new Legend
      {
        UnitType = FourCC(""E005""),
        PlayerColor = PLAYER_COLOR_RED,
        Name = "Prophet Skeram"
      };

      LEGEND_GATESAHNQIRAJ = new Legend
      {
        Unit = gg_unit_h02U_2413
      };

      LEGEND_YOR = new Legend();
      LEGEND_YOR.UnitType = FourCC("U02A");
      LEGEND_YOR.StartingXp = 8800;
    }
  }
}