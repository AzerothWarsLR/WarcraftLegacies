using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
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

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendVarian = new Legend
      {
        UnitType = FourCC("H00R")
      };
      LegendVarian.AddUnitDependency(preplacedUnitSystem.GetUnit(FourCC("h00X")));
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
        Unit = preplacedUnitSystem.GetUnit(FourCC("h00X")),
        DeathMessage = "Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!"
      };
      Legend.Register(LegendStormwindkeep);
      LegendStormwindkeep.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND, new Point(9530, -10941)));
      LegendStormwindkeep.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND, new Point(10177, -10952)));

      LegendDarkshire = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h03Y"))
      };
      Legend.Register(LegendDarkshire);

      ConstructionSiteMagic = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H053_CONSTRUCTION_SITE_STORMWIND_WIZARD_S_SANCTUM)
      };
      ConstructionSiteMagic.Unit.SetInvulnerable(true);
      CreateTrigger()
        .RegisterUnitEvent(LegendStormwindkeep.Unit, EVENT_UNIT_DEATH)
        .AddAction(() => ConstructionSiteMagic.Unit.Kill());

      ConstructionSiteMartial = new Legend
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H055_CONSTRUCTION_SITE_STORMWIND_CHAMPION_S_HALL)
      };
      ConstructionSiteMartial.Unit.SetInvulnerable(true);
      CreateTrigger()
        .RegisterUnitEvent(LegendStormwindkeep.Unit, EVENT_UNIT_DEATH)
        .AddAction(() => ConstructionSiteMartial.Unit.Kill());
    }
  }
}