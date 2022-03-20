using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendGoblin{

  
    public static Legend LEGEND_GALLYWIX
    public static Legend LEGEND_NOGGENFOGGER
    public static Legend LEGEND_GAZLOWE

  

    public static void Setup( ){

      LEGEND_GALLYWIX = new Legend();
      LEGEND_GALLYWIX.UnitType = FourCC(O04N);

      LEGEND_NOGGENFOGGER = new Legend();
      LEGEND_NOGGENFOGGER.UnitType = FourCC(Nalc);
      LEGEND_NOGGENFOGGER.StartingXp = 800;

      LEGEND_GAZLOWE = new Legend();
      LEGEND_GAZLOWE.UnitType = FourCC(Ntin);
      LEGEND_GAZLOWE.StartingXp = 1800;

    }

  }
}
