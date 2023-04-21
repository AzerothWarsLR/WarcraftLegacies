using MacroTools;
using MacroTools.LegendSystem;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendCthun
  {
    public LegendaryHero Cthun { get; }

    public LegendCthun()
    {
      Cthun = new LegendaryHero("C'thun")
      {
        UnitType = Constants.UNIT_U00R_OLD_GOD,
         StartingXp = 10000,
      };
    }
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Cthun);
    }
  }
}