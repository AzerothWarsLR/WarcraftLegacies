using MacroTools;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendDruids : IRegistersLegends
  {
    public LegendaryHero LegendCenarius { get; }
    public LegendaryHero LegendMalfurion { get; }
    public LegendaryHero LegendFandral { get; }
    public LegendaryHero LegendUrsoc { get; }
    public LegendaryHero LegendTortolla { get; }
    public Capital LegendNordrassil { get; }
    public static int UnittypeCenariusAlive { get; } = FourCC("Ecen");
    public static int UnittypeCenariusGhost { get; } = FourCC("E00H");

    public LegendDruids(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendaryHeroManager.Register(LegendCenarius = new LegendaryHero("Cenarius")
      {
        UnitType = FourCC("Ecen"),
        PermaDies = true,
        DeathMessage =
          "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor.",
        DeathSfx = "Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl",
        PlayerColor = PLAYER_COLOR_CYAN,
      });

      LegendaryHeroManager.Register(LegendMalfurion = new LegendaryHero("Malfurion")
      {
        UnitType = FourCC("Efur"),
        StartingArtifactItemTypeIds = new[]
        {
          Constants.ITEM_I00C_G_HANIR_THE_MOTHER_TREE
        }
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