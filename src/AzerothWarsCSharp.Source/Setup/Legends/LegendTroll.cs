using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendTroll{

  
    public static Legend LEGEND_PRIEST
    public static Legend LEGEND_RASTAKHAN
    public static Legend LEGEND_HAKKAR
  

    public static void Setup( ){
      LEGEND_PRIEST = new Legend();
      LEGEND_PRIEST.UnitType = FourCC(O01J);
      LEGEND_PRIEST.Essential = true;

      LEGEND_HAKKAR = new Legend();
      LEGEND_HAKKAR.UnitType = FourCC(U023);

      LEGEND_RASTAKHAN = new Legend();
      LEGEND_RASTAKHAN.UnitType = FourCC(O026);
      LEGEND_RASTAKHAN.StartingXp = 2800;

    }

  }
}
