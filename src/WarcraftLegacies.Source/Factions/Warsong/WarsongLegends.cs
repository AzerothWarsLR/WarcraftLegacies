using MacroTools.Legends;

namespace WarcraftLegacies.Source.Factions.Warsong;

public sealed class WarsongLegends
{
  public LegendaryHero Saurfang { get; }
  public LegendaryHero Gargok { get; }
  public LegendaryHero Mannoroth { get; }

  public WarsongLegends()
  {
    Saurfang = new LegendaryHero("Varok Saurfang")
    {
      UnitType = UNIT_VSWS_HIGH_OVERLORD_OF_THE_KOR_KRON_WARSONG,
      StartingXp = 2800
    };

    Mannoroth = new LegendaryHero("Mannoroth")
    {
      UnitType = UNIT_NMAN_MANNOROTH_THE_DESTROYER_WARSONG_BLOODPACT,
      PermaDies = true,
      DeathMessage =
        "Mannoroth the Corrupter has fallen.",
      StartingXp = 41800
    };

    Gargok = new LegendaryHero("Gargok")
    {
      UnitType = UNIT_O005_WARSONG_BATTLEMASTER_WARSONG
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Saurfang);
    LegendaryHeroManager.Register(Mannoroth);
    LegendaryHeroManager.Register(Gargok);
  }
}
