using MacroTools.LegendSystem;

namespace TestMap.Source.Setup
{
  public static class LegendSetup
  {
    public static LegendaryHero Kael { get; private set; }
    public static LegendaryHero Uther { get; private set; }

    public static void Setup()
    {
      Kael = new LegendaryHero("Kael")
      {
        Unit = CreateUnit(Player(12), FourCC("Hkal"), 0, 0, 0),
        PermaDies = true
      };
      LegendaryHeroManager.Register(Kael);
      Uther = new LegendaryHero("Uther")
      {
        UnitType = FourCC("Huth"),
        StartingXp = 3000
      };
      LegendaryHeroManager.Register(Uther);
    }
  }
}