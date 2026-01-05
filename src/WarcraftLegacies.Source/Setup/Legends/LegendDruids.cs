using MacroTools.LegendSystem;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendDruids
{
  public LegendaryHero Cenarius { get; }
  public LegendaryHero Malfurion { get; }
  public LegendaryHero Ursoc { get; }
  public LegendaryHero Tortolla { get; }
  public Capital Nordrassil { get; }
  public Capital Vordrassil { get; }
  public Capital TempleOfTheMoon { get; }
  public Capital CenarionHold { get; }

  public static int UnittypeCenariusGhost => UNIT_E00H_DEMIGOD_OF_THE_NIGHT_ELVES_DRUIDS_GHOST;

  public LegendDruids()
  {
    Cenarius = new LegendaryHero("Cenarius")
    {
      UnitType = UNIT_ECEN_DEMIGOD_OF_THE_NIGHT_ELVES_DRUIDS,
      PermaDies = true,
      DeathMessage =
        "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor.",
      DeathSfx = @"Objects\Spawnmodels\NightElf\EntBirthTarget\EntBirthTarget.mdl",
      PlayerColor = playercolor.Cyan,
    };

    Malfurion = new LegendaryHero("Malfurion")
    {
      UnitType = UNIT_EFUR_ARCHDRUID_DRUIDS,
      StartingArtifacts = new()
      {
        new(item.Create(ITEM_I00C_G_HANIR_THE_MOTHER_TREE, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    Ursoc = new LegendaryHero("Ursoc")
    {
      UnitType = UNIT_E00A_ANCIENT_GUARDIAN_DRUIDS,
      StartingXp = 7000
    };

    Nordrassil = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_N002_NORDRASSIL_DRUIDS_OTHER),
      Capturable = true,
      Essential = true
    };

    Vordrassil = new Capital
    {
      Capturable = true,
      Essential = true
    };

    CenarionHold = new Capital
    {
      Capturable = true,
      Essential = true,
      Unit = PreplacedWidgets.Units.Get(UNIT_N06D_CENARION_HOLD_SENTINELS_OTHER)
    };

    TempleOfTheMoon = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_O029_TEMPLE_OF_THE_MOON_SENTINELS_OTHER),
    };

    Tortolla = new LegendaryHero("Tortolla")
    {
      UnitType = UNIT_H04U_DEMIGOD_DRUIDS,
      StartingXp = 4000
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Cenarius);
    LegendaryHeroManager.Register(Malfurion);
    LegendaryHeroManager.Register(Ursoc);
    LegendaryHeroManager.Register(Tortolla);
    CapitalManager.Register(Nordrassil);
    CapitalManager.Register(Vordrassil);
    CapitalManager.Register(TempleOfTheMoon);
    CapitalManager.Register(CenarionHold);
  }
}
