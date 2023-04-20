using MacroTools;
using MacroTools.LegendSystem;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendNzoth
  {
    public LegendaryHero Nzoth { get; }

    public LegendNzoth()
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