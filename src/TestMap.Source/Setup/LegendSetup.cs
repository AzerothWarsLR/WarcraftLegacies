using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace TestMap.Source.Setup
{
  public static class LegendSetup
  {
    public static Legend Kael { get; private set; }
    public static Legend Uther { get; private set; }

    public static void Setup()
    {
      Kael = new Legend
      {
        Unit = CreateUnit(Player(12), FourCC("Hkal"), 0, 0, 0),
        PermaDies = true
      };
      LegendaryHeroManager.Register(Kael);
      Uther = new Legend
      {
        UnitType = FourCC("Huth"),
        StartingXp = 3000
      };
      LegendaryHeroManager.Register(Uther);
    }
  }
}