using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendScarlet{

  
    public static Legend LEGEND_BRIGITTE
    public static Legend LEGEND_TIRION
  

    public static void Setup( ){

      LEGEND_BRIGITTE = new Legend();
      LEGEND_BRIGITTE.UnitType = FourCC(H00Y);
      LEGEND_BRIGITTE.StartingXp = 7000;

      LEGEND_TIRION = new Legend();
      LEGEND_TIRION.UnitType = FourCC(H09Z);
      LEGEND_TIRION.StartingXp = 7000;

    }

  }
}
