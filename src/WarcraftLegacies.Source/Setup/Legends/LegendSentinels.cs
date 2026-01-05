using MacroTools.LegendSystem;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

/// <summary>
/// Responsible for setting up and storing all Sentinel <see cref="Legend"/>s.
/// </summary>
public sealed class LegendSentinels
{
  public LegendaryHero Maiev { get; }
  public LegendaryHero Tyrande { get; }
  public LegendaryHero Shandris { get; }
  public LegendaryHero Naisha { get; }
  public Capital Auberdine { get; }
  public Capital Feathermoon { get; }
  public Capital VaultOfTheWardens { get; }

  public LegendSentinels()
  {
    Maiev = new LegendaryHero("Maiev Shadowsong")
    {
      UnitType = UNIT_EWRD_LEADER_OF_THE_WATCHERS_SENTINELS,
      StartingXp = 2800
    };

    Auberdine = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_E00J_AUBERDINE_SENTINELS_OTHER),
      Essential = true
    };

    Feathermoon = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_E00M_FEATHERMOON_STRONGHOLD_SENTINELS_OTHER),
      Essential = true
    };

    Tyrande = new LegendaryHero("Tyrande Whisperwind")
    {
      UnitType = UNIT_ETYR_HIGH_PRIESTESS_OF_ELUNE_SENTINELS,
      PlayerColor = playercolor.Cyan,
      StartingXp = 1000
    };

    Naisha = new LegendaryHero("Naisha")
    {
      UnitType = UNIT_E025_LIEUTENANT_OF_THE_WATCHERS_SENTINELS,
      PlayerColor = playercolor.Pink,
      StartingXp = 1800
    };

    Shandris = new LegendaryHero("Shandris Feathermoon")
    {
      UnitType = UNIT_E002_GENERAL_OF_THE_SENTINEL_ARMY_SENTINELS,
    };

    VaultOfTheWardens = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_N04G_VAULT_OF_THE_WARDENS_SENTINELS)
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Maiev);
    LegendaryHeroManager.Register(Tyrande);
    LegendaryHeroManager.Register(Shandris);
    LegendaryHeroManager.Register(Naisha);
    CapitalManager.Register(Auberdine);
    CapitalManager.Register(Feathermoon);
  }
}
