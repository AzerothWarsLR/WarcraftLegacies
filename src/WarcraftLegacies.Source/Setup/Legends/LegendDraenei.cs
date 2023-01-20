using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendDraenei : IRegistersLegends
  {
    public LegendaryHero Velen { get; }
    public LegendaryHero Maraad { get; }
    public LegendaryHero LegendNobundo { get; }
    public Capital LegendExodar { get; }
    public Capital LegendExodarGenerator { get; }
    public Capital Shattrah { get; }
    
    public Capital Farahlon { get; }
    
    public Capital Halaar { get; }
    
    public LegendDraenei(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendNobundo = new LegendaryHero("Nobundo")
      {
        UnitType = Constants.UNIT_E01J_HIGH_SHAMAN_DRUIDS,
        StartingXp = 1800
      };

      LegendExodar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_E01X_EXODAR_REGALIS_DRAENEI_SPACESHIP)
      };

      LegendExodarGenerator = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_N00E_DIMENSIONAL_GENERATOR_DRAENEI)
      };
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10895, -25846)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10625, -26098)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10230, -26110)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-9973, -25856)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-9973, -25460)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10235, -25187)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10625, -25218)));
      LegendExodarGenerator.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10896, -25456)));

      Maraad = new LegendaryHero("Maraad")
      {
        UnitType = FourCC("H09S")
      };

      Velen = new LegendaryHero("Velen")
      {
        UnitType = FourCC("E01I")
      };

      Shattrah = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AH_SHATTRAH_DRAENEI_OTHER)
      };

      Farahlon = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AF_FARAHLON_DRAENEI_OTHER)
      };

      Halaar = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H0AE_HALAAR_DRAENEI_OTHER)
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Velen);
      LegendaryHeroManager.Register(Maraad);
      LegendaryHeroManager.Register(LegendNobundo);
      CapitalManager.Register(LegendExodar);
      CapitalManager.Register(LegendExodarGenerator);
      CapitalManager.Register(Shattrah);
      CapitalManager.Register(Farahlon);
      CapitalManager.Register(Halaar);
    }
  }
}