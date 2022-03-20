using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendDalaran{

  
    public static Legend LEGEND_ANTONIDAS
    public static Legend LEGEND_MEDIVH
    public static Legend LEGEND_JAINA
    public static Legend LEGEND_KALECGOS
    public static Legend LEGEND_MALYGOS

    public static Legend LEGEND_DALARAN
  

    public static void Setup( ){
      LEGEND_JAINA = new Legend();
      LEGEND_JAINA.UnitType = FourCC(Hjai);
      LEGEND_JAINA.Essential = true;

      LEGEND_MEDIVH = new Legend();
      LEGEND_MEDIVH.UnitType = FourCC(Haah);
      LEGEND_MEDIVH.StartingXp = 2800;

      LEGEND_KALECGOS = new Legend();
      LEGEND_KALECGOS.UnitType = FourCC(U027);
      LEGEND_KALECGOS.StartingXp = 9800;

      LEGEND_MALYGOS = new Legend();
      LEGEND_MALYGOS.UnitType = FourCC(U026);
      LEGEND_MALYGOS.StartingXp = 10900;

      LEGEND_DALARAN = new Legend();
      LEGEND_DALARAN.Unit = gg_unit_h002_0230;
      LEGEND_DALARAN.DeathMessage = "The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle.";
      LEGEND_DALARAN.IsCapital = true;

      LEGEND_ANTONIDAS = new Legend();
      LEGEND_ANTONIDAS.UnitType = FourCC(Hant);
      LEGEND_ANTONIDAS.StartingXp = 1000;
      LEGEND_ANTONIDAS.AddUnitDependency(LEGEND_DALARAN.Unit);
      LEGEND_ANTONIDAS.DeathMessage = "Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind.";
    }

  }
}
