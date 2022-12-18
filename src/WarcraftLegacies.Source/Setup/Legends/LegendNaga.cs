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
      LegendIllidan = new LegendaryHero("Illidan")
      {
        UnitType = FourCC("Eill"),
        PlayerColor = PLAYER_COLOR_PURPLE
      };
      LegendaryHeroManager.Register(LegendIllidan);

      LegendVashj = new LegendaryHero("Lady Vashj")
      {
        UnitType = FourCC("Hvsh"),
        StartingXp = 2800,
      };
      LegendaryHeroManager.Register(LegendVashj);

      LegendAzshara = new LegendaryHero("Azshara")
      {
        UnitType = FourCC("H08U")
      };
      LegendaryHeroManager.Register(LegendAzshara);

      LegendNajentus = new LegendaryHero("Warlord Najentus")
      {
        UnitType = FourCC("U00S"),
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(LegendNajentus);

      LegendAltruis = new LegendaryHero("Altruis")
      {
        UnitType = FourCC("E015")
      };
      LegendaryHeroManager.Register(LegendAltruis);

      LegendAkama = new LegendaryHero("Akama")
      {
        UnitType = FourCC("Naka"),
        StartingXp = 4000
      };
      LegendaryHeroManager.Register(LegendAkama);
    }
  }
}