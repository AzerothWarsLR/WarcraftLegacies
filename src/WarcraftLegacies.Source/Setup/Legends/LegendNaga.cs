using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendNaga
  {
    public static LegendaryHero LegendIllidan { get; private set; }
    public static LegendaryHero LegendVashj { get; private set; }
    public static LegendaryHero LegendNajentus { get; private set; }
    public static LegendaryHero LegendAzshara { get; private set; }
    public static LegendaryHero LegendAltruis { get; private set; }
    public static LegendaryHero LegendAkama { get; private set; }

    public static void Setup()
    {
      LegendIllidan = new LegendaryHero
      {
        UnitType = FourCC("Eill"),
        PlayerColor = PLAYER_COLOR_PURPLE,
        Name = "Illidan"
      };
      LegendaryHeroManager.Register(LegendIllidan);

      LegendVashj = new LegendaryHero
      {
        UnitType = FourCC("Hvsh"),
        StartingXp = 2800,
        Name = "Lady Vashj"
      };
      LegendaryHeroManager.Register(LegendVashj);

      LegendAzshara = new LegendaryHero
      {
        UnitType = FourCC("H08U"),
        Name = "Azshara"
      };
      LegendaryHeroManager.Register(LegendAzshara);

      LegendNajentus = new LegendaryHero
      {
        UnitType = FourCC("U00S"),
        StartingXp = 2800,
        Name = "Warlord Najentus"
      };
      LegendaryHeroManager.Register(LegendNajentus);

      LegendAltruis = new LegendaryHero
      {
        UnitType = FourCC("E015"),
        Name = "Altruis"
      };
      LegendaryHeroManager.Register(LegendAltruis);

      LegendAkama = new LegendaryHero
      {
        UnitType = FourCC("Naka"),
        StartingXp = 4000,
        Name = "Akama"
      };
      LegendaryHeroManager.Register(LegendAkama);
    }
  }
}