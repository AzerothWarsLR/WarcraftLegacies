using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendStormwind
  {
    public static LegendaryHero Varian { get; private set; }
    public static LegendaryHero khadgar { get; private set; }
    public static LegendaryHero Galen { get; private set; }
    public static LegendaryHero Bolvar { get; private set; }
    public static Capital Stormwindkeep { get; private set; }
    public static Capital Darkshire { get; private set; }
    
    public static Capital? ConstructionSiteMartial { get; private set; }

    public static Capital? ConstructionSiteMagic { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Varian = new LegendaryHero("Varian Wrynn")
      {
        UnitType = FourCC("H00R")
      };
      Varian.AddUnitDependency(preplacedUnitSystem.GetUnit(FourCC("h00X")));
      Varian.DeathMessage =
        "The King of Stormwind dies a warrior’s death, defending hearth and family. The Wrynn Dynasty crumbles with his passing.";
      Varian.StartingXp = 1800;
      LegendaryHeroManager.Register(Varian);

      Galen = new LegendaryHero("Galen Trollbane")
      {
        UnitType = FourCC("H00Z"),
        StartingXp = 1000
      };
      LegendaryHeroManager.Register(Galen);

      Bolvar = new LegendaryHero("Bolvar Fordragon")
      {
        UnitType = FourCC("H017")
      };
      LegendaryHeroManager.Register(Bolvar);

      khadgar = new LegendaryHero("Khadgar")
      {
        UnitType = FourCC("H05Y"),
        StartingXp = 7000
      };
      LegendaryHeroManager.Register(khadgar);

      Stormwindkeep = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h00X")),
        DeathMessage = "Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!"
      };
      CapitalManager.Register(Stormwindkeep);
      Stormwindkeep.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND, new Point(9530, -10941)));
      Stormwindkeep.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND, new Point(10177, -10952)));

      Darkshire = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h03Y"))
      };
      CapitalManager.Register(Darkshire);

      ConstructionSiteMagic = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H053_CONSTRUCTION_SITE_STORMWIND_WIZARD_S_SANCTUM)
      };
      ConstructionSiteMagic.Unit.SetInvulnerable(true);
      CreateTrigger()
        .RegisterUnitEvent(Stormwindkeep.Unit, EVENT_UNIT_DEATH)
        .AddAction(() => ConstructionSiteMagic.Unit.Kill());

      ConstructionSiteMartial = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H055_CONSTRUCTION_SITE_STORMWIND_CHAMPION_S_HALL)
      };
      ConstructionSiteMartial.Unit.SetInvulnerable(true);
      CreateTrigger()
        .RegisterUnitEvent(Stormwindkeep.Unit, EVENT_UNIT_DEATH)
        .AddAction(() => ConstructionSiteMartial.Unit.Kill());
    }
  }
}