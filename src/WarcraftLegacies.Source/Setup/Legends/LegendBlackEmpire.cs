using MacroTools;
using MacroTools.LegendSystem;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendBlackEmpire
  {
    public LegendaryHero Nzoth { get; }

    public LegendBlackEmpire()
    {
      Nzoth = new LegendaryHero("N'zoth")
      {
        UnitType = Constants.UNIT_U01Z_OLD_GOD_NZOTH,
         StartingXp = 10000,
      };
    }
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Nzoth);
    }
  }
}