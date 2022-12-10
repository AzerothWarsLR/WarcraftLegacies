using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendDruids
  {
    public static LegendaryHero LegendCenarius { get; private set; }
    public static LegendaryHero LegendMalfurion { get; private set; }
    public static LegendaryHero LegendFandral { get; private set; }
    public static LegendaryHero LegendUrsoc { get; private set; }
    public static LegendaryHero LegendTortolla { get; private set; }
    public static Capital LegendNordrassil { get; private set; }
    public static int UnittypeCenariusAlive { get; } = FourCC("Ecen");
    public static int UnittypeCenariusGhost { get; } = FourCC("E00H");

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendaryHeroManager.Register(LegendCenarius = new LegendaryHero("Cenarius")
      {
        UnitType = FourCC("Ecen"),
        PermaDies = true,
        DeathMessage =
          "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor.",
        DeathSfx = "Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl",
        PlayerColor = PLAYER_COLOR_CYAN,
        StartingXp = 1000
      });

      LegendaryHeroManager.Register(LegendMalfurion = new LegendaryHero("Malfurion")
      {
        UnitType = FourCC("Efur")
      });

      LegendaryHeroManager.Register(LegendFandral = new LegendaryHero("Fandral")
      {
        UnitType = FourCC("E00K")
      });

      LegendaryHeroManager.Register(LegendUrsoc = new LegendaryHero("Ursoc")
      {
        UnitType = FourCC("E00A"),
        StartingXp = 7000
      });

      CapitalManager.Register(LegendNordrassil = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("n002")),
        Capturable = true
      });

      LegendaryHeroManager.Register(LegendTortolla = new LegendaryHero("Tortolla")
      {
        UnitType = FourCC("H04U"),
        StartingXp = 1800
      });
    }
  }
}