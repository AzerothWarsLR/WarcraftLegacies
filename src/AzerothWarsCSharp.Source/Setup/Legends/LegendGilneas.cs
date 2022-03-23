using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendGilneas{

  
    public static Legend LEGEND_TESS
    public static Legend LEGEND_GENN
    public static Legend LEGEND_DARIUS
    public static Legend LEGEND_GOLDRINN

    public static Legend LEGEND_LIGHTDAWN
    public static Legend LEGEND_GILNEASCASTLE

  

    public static void Setup( ){
      LEGEND_TESS = new Legend();
      LEGEND_TESS.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("Ewar"));

      LEGEND_GOLDRINN = new Legend();
      LEGEND_GOLDRINN.UnitType = FourCC("E01E");
      LEGEND_GOLDRINN.StartingXp = 8800;

      LEGEND_GENN = new Legend();
      LEGEND_GENN.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("Hhkl"));

      LEGEND_DARIUS = new Legend();
      LEGEND_DARIUS.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("Hpb2"));

      LEGEND_LIGHTDAWN = new Legend();
      LEGEND_LIGHTDAWN.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h057"));
      LEGEND_LIGHTDAWN.DeathMessage = "The LightFourCC(s Dawn Capital has been destroyed.";
      LEGEND_LIGHTDAWN.IsCapital = true;

      LEGEND_GILNEASCASTLE = new Legend();
      LEGEND_GILNEASCASTLE.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h04I"));
      LEGEND_GILNEASCASTLE.DeathMessage = "The Gilneas castle has fallen";
      LEGEND_GILNEASCASTLE.IsCapital = true;
    }

  }
}
