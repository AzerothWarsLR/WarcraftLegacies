using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendNaga : IRegistersLegends
  {
    public LegendaryHero LegendIllidan { get; }
    public LegendaryHero LegendVashj { get; }
    public LegendaryHero LegendNajentus { get; }
    public LegendaryHero LegendAzshara { get; }
    public LegendaryHero LegendAltruis { get; }
    public LegendaryHero LegendAkama { get; }

    public LegendNaga()
    {
      LegendIllidan = new LegendaryHero("Illidan")
      {
        UnitType = Constants.UNIT_EEVI_BETRAYER_ILLIDARI,
        PlayerColor = PLAYER_COLOR_PURPLE
      };

      LegendVashj = new LegendaryHero("Lady Vashj")
      {
        UnitType = FourCC("Hvsh"),
      };

      LegendAzshara = new LegendaryHero("Azshara")
      {
        UnitType = FourCC("H08U")
      };

      LegendNajentus = new LegendaryHero("Warlord Najentus")
      {
        UnitType = FourCC("U00S"),
        StartingXp = 2800
      };

      LegendAltruis = new LegendaryHero("Altruis")
      {
        UnitType = FourCC("E015")
      };

      LegendAkama = new LegendaryHero("Akama")
      {
        UnitType = FourCC("Naka"),
        StartingXp = 4000
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(LegendIllidan);
      LegendaryHeroManager.Register(LegendVashj);
      LegendaryHeroManager.Register(LegendNajentus);
      LegendaryHeroManager.Register(LegendAzshara);
      LegendaryHeroManager.Register(LegendAltruis);
      LegendaryHeroManager.Register(LegendAkama);
    }
  }
}