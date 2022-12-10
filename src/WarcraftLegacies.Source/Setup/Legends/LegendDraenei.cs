using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendDraenei
  {
    public static LegendaryHero LegendVelen { get; private set; }
    public static LegendaryHero LegendMaraad { get; private set; }
    public static LegendaryHero LegendNobundo { get; private set; }
    public static Capital LegendExodar { get; private set; }
    public static Capital? Shattrah { get; private set; }
    
    public static Capital? Farahlon { get; private set; }
    
    public static Capital? Halaar { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendNobundo = new LegendaryHero
      {
        UnitType = FourCC("E01J"),
        StartingXp = 1800
      };
      Legend.Register(LegendNobundo);

      LegendExodar = new Capital()
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_O05E_EXODAR_REGALIS_DRAENEI)
      };
      Legend.Register(LegendExodar);

      LegendMaraad = new LegendaryHero
      {
        UnitType = FourCC("H09S")
      };
      Legend.Register(LegendMaraad);

      LegendVelen = new LegendaryHero
      {
        UnitType = FourCC("E01I")
      };
      Legend.Register(LegendVelen);

      Shattrah = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AH_SHATTRAH_DRAENEI)
      };
      Legend.Register(Shattrah);
      
      Farahlon = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AF_FARAHLON_DRAENEI)
      };
      Legend.Register(Farahlon);
      
      Halaar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AE_HALAAR_DRAENEI)
      };
      Legend.Register(Halaar);
    }
  }
}