using MacroTools;
using MacroTools.Extensions;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendDraenei
  {
    public LegendaryHero LegendVelen { get; }
    public LegendaryHero LegendMaraad { get; }
    public LegendaryHero LegendNobundo { get; }
    public Capital LegendExodar { get; }
    public Capital LegendExodarGenerator { get; }
    public Capital? Shattrah { get; }
    
    public Capital? Farahlon { get; }
    
    public Capital? Halaar { get; }
    
    public LegendDraenei(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendNobundo = new LegendaryHero("Nobundo")
      {
        UnitType = FourCC("E01J"),
        StartingXp = 1800
      };
      LegendaryHeroManager.Register(LegendNobundo);

      LegendExodar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_E01X_EXODAR_REGALIS_DRAENEI_SPACESHIP)
      };
      CapitalManager.Register(LegendExodar);

      LegendExodarGenerator = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_N00E_DIMENSIONAL_GENERATOR_DRAENEI)
      };
      CapitalManager.Register(LegendExodarGenerator);
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10895, -25846)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10625, -26098)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10230, -26110)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-9973, -25856)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-9973, -25460)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10235, -25187)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10625, -25218)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10896, -25456)));

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
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AH_SHATTRAH_DRAENEI_OTHER)
      };
      CapitalManager.Register(Shattrah);
      
      Farahlon = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AF_FARAHLON_DRAENEI_OTHER)
      };
      CapitalManager.Register(Farahlon);
      
      Halaar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AE_HALAAR_DRAENEI_OTHER)
      };
      CapitalManager.Register(Halaar);
    }
  }
}