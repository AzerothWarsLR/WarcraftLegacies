using MacroTools;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendDraenei
  {
    public static Legend LegendVelen { get; private set; }
    public static Legend LegendMaraad { get; private set; }
    public static Legend LegendNobundo { get; private set; }
    public static Legend LegendExodar { get; private set; }
    public static Legend LegendExodarship { get; private set; }
    
    public static Legend? Shattrah { get; private set; }
    
    public static Legend? Farahlon { get; private set; }
    
    public static Legend? Halaar { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendNobundo = new Legend
      {
        UnitType = FourCC("E01J"),
        StartingXp = 1800
      };
      Legend.Register(LegendNobundo);

      LegendExodar = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_O05E_EXODAR_REGALIS_DRAENEI)
      };
      Legend.Register(LegendExodar);

      LegendExodarship = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H09W_THE_EXODAR)
      };
      Legend.Register(LegendExodarship);

      LegendMaraad = new Legend
      {
        UnitType = FourCC("H09S")
      };
      Legend.Register(LegendMaraad);

      LegendVelen = new Legend
      {
        UnitType = FourCC("E01I")
      };
      LegendVelen.AddUnitDependency(LegendExodar.Unit);
      LegendVelen.AddUnitDependency(LegendExodarship.Unit);
      Legend.Register(LegendVelen);

      Shattrah = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AH_SHATTRAH_DRAENEI)
      };
      Legend.Register(Shattrah);
      
      Farahlon = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AF_FARAHLON_DRAENEI)
      };
      Legend.Register(Farahlon);
      
      Halaar = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AE_HALAAR_DRAENEI)
      };
      Legend.Register(Halaar);
    }
  }
}