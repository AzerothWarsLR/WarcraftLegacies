using MacroTools;
using MacroTools.LegendSystem;
using static War3Api.Common;
#pragma warning disable CS1591

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
      LegendCenarius = new LegendaryHero("Cenarius")
      {
        UnitType = FourCC("Ecen"),
        PermaDies = true,
        DeathMessage =
          "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor.",
        DeathSfx = "Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl",
        PlayerColor = PLAYER_COLOR_CYAN,
      };

      LegendMalfurion = new LegendaryHero("Malfurion")
      {
        UnitType = FourCC("Efur"),
        StartingArtifactItemTypeIds = new[]
        {
          Constants.ITEM_I00C_G_HANIR_THE_MOTHER_TREE
        }
      };

      LegendFandral = new LegendaryHero("Fandral")
      {
        UnitType = FourCC("E00K")
      };

      LegendUrsoc = new LegendaryHero("Ursoc")
      {
        UnitType = FourCC("E00A"),
        StartingXp = 7000
      };

      LegendNordrassil = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("n002")),
        Capturable = true
      };

      LegendTortolla = new LegendaryHero("Tortolla")
      {
        UnitType = FourCC("H04U"),
        StartingXp = 1800
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(LegendCenarius);
      LegendaryHeroManager.Register(LegendMalfurion);
      LegendaryHeroManager.Register(LegendFandral);
      LegendaryHeroManager.Register(LegendUrsoc);
      LegendaryHeroManager.Register(LegendTortolla);
      CapitalManager.Register(LegendNordrassil);
    }
  }
}