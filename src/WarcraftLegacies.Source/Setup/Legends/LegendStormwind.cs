using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendStormwind
  {
    public static Legend LegendVarian { get; private set; }
    public static Legend LegendKhadgar { get; private set; }
    public static Legend LegendGalen { get; private set; }
    public static Legend LegendBolvar { get; private set; }
    public static Legend LegendStormwindkeep { get; private set; }
    public static Legend LegendDarkshire { get; private set; }
    
    public static Legend? ConstructionSiteMartial { get; private set; }

    public static Legend? ConstructionSiteMagic { get; private set; }

    public static void Setup()
    {
      LegendVarian = new Legend
      {
        UnitType = FourCC("H00R")
      };
      LegendVarian.AddUnitDependency(PreplacedUnitSystem.GetUnit(FourCC("h00X")));
      LegendVarian.DeathMessage =
        "The King of Stormwind dies a warrior’s death, defending hearth and family. The Wrynn Dynasty crumbles with his passing.";
      LegendVarian.StartingXp = 1800;
      Legend.Register(LegendVarian);

      LegendGalen = new Legend
      {
        UnitType = FourCC("H00Z"),
        StartingXp = 1000
      };
      Legend.Register(LegendGalen);

      LegendBolvar = new Legend
      {
        UnitType = FourCC("H017")
      };
      Legend.Register(LegendBolvar);

      LegendKhadgar = new Legend
      {
        UnitType = FourCC("H05Y"),
        StartingXp = 7000
      };
      Legend.Register(LegendKhadgar);

      LegendStormwindkeep = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h00X")),
        DeathMessage = "Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!"
      };
      Legend.Register(LegendStormwindkeep);
      LegendStormwindkeep.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND, new Point(9530, -10941)));
      LegendStormwindkeep.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND, new Point(10177, -10952)));
      
      LegendDarkshire = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h03Y"))
      };
      Legend.Register(LegendDarkshire);

      ConstructionSiteMagic = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H053_CONSTRUCTION_SITE_ARATHOR_CATHEDRAL_WIZARD)
      };
      ConstructionSiteMagic.Unit.SetInvulnerable(true);

      ConstructionSiteMartial = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_H055_CONSTRUCTION_SITE_ARATHOR_SI_7_CHAMPION_S_HALL)
      };
      ConstructionSiteMartial.Unit.SetInvulnerable(true);
    }
  }
}