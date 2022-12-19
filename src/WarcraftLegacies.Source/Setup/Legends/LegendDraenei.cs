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
      LegendNobundo = new LegendaryHero("Nobundo")
      {
        UnitType = FourCC("E01J"),
        StartingXp = 1800
      };
      LegendaryHeroManager.Register(LegendNobundo);

      LegendExodar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_E01X_EXODAR_REGALIS_DRAENEI)
      };
      CapitalManager.Register(LegendExodar);

      LegendMaraad = new LegendaryHero("Maraad")
      {
        UnitType = FourCC("H09S")
      };
      LegendaryHeroManager.Register(LegendMaraad);

      LegendVelen = new LegendaryHero("Velen")
      {
        UnitType = FourCC("E01I")
      };
      LegendaryHeroManager.Register(LegendVelen);

      Shattrah = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AH_SHATTRAH_DRAENEI)
      };
      CapitalManager.Register(Shattrah);
      
      Farahlon = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AF_FARAHLON_DRAENEI)
      };
      CapitalManager.Register(Farahlon);
      
      Halaar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AE_HALAAR_DRAENEI)
      };
      CapitalManager.Register(Halaar);
    }
  }
}