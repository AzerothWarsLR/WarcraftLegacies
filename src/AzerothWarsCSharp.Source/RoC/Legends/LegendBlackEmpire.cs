using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendBlackEmpire
  {
    public static Legend LEGEND_YOGG;
    public static Legend LEGEND_VOLAZJ;
    public static Legend LEGEND_ZAKAJZ;

    public static void Setup()
    {
      Legend.Register(LEGEND_YOGG = new Legend
      {
        Unit = gg_unit_U02C_2829,
        PermaDies = true,
        DeathMessage =
          "Yogg-Saron, the Fiend of a Thousand Faces, has been vanquished. The countless souls consigned to his maw have finally been avenged."
      });
      
      Legend.Register(LEGEND_VOLAZJ = new Legend
      {
        UnitType = FourCC("E01D")
      });

      Legend.Register(LEGEND_ZAKAJZ = new Legend
      {
        UnitType = FourCC("U00P"),
        StartingXp = 8800
      });
    }
  }
}