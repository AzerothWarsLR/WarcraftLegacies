using MacroTools;
using MacroTools.LegendSystem;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendNazjatar
  {
    public LegendaryHero Azshara { get; }

    public LegendNazjatar()
    {
      Azshara = new LegendaryHero("Azshara")
      {
        UnitType = Constants.UNIT_H08U_EMPRESS_OF_NAZJATAR_NZOTH,
         StartingXp = 10000,
      };
    }
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Azshara);
    }
  }
}