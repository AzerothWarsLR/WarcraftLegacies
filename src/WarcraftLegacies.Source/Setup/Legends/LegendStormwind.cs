using MacroTools;
using MacroTools.Extensions;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendStormwind : IRegistersLegends
  {
    public LegendaryHero? Varian { get; }
    public LegendaryHero khadgar { get; }
    public LegendaryHero Galen { get; }
    public LegendaryHero Bolvar { get; }
    public Capital Stormwindkeep { get; }
    public Capital Darkshire { get; }
    
    public Capital? ConstructionSiteMartial { get; }

    public Capital? ConstructionSiteMagic { get; }

    public LegendStormwind(PreplacedUnitSystem preplacedUnitSystem)
    {
      Varian = new LegendaryHero("Varian Wrynn")
      {
        UnitType = FourCC("H00R"),
        DeathMessage = "The King of Stormwind dies a warrior’s death, defending hearth and family. The Wrynn Dynasty crumbles with his passing.",
        StartingXp = 1800,
        StartingArtifactItemTypeIds = new[]
        {
          Constants.ITEM_I00D_SHALAMAYNE
        }
      };
      Varian.AddUnitDependency(preplacedUnitSystem.GetUnit(Constants.UNIT_H00X_STORMWIND_KEEP_STORMWIND_OTHER));
      LegendaryHeroManager.Register(Varian);

      Galen = new LegendaryHero("Galen Trollbane")
      {
        UnitType = FourCC("H00Z"),
        StartingXp = 1000,
        StartingArtifactItemTypeIds = new[] { Constants.ITEM_I01O_TROL_KALAR }
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
      Stormwindkeep.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND_TOWER, new Point(9530, -10941)));
      Stormwindkeep.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND_TOWER, new Point(10177, -10952)));

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

    /// <inheritdoc />
    public void RegisterLegends()
    {
      throw new System.NotImplementedException();
    }
  }
}