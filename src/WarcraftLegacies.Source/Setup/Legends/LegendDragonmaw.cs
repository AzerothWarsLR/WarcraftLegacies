using MacroTools;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendDragonmaw
  {
    public static Capital? DragonmawPort { get; private set; }
    public static LegendaryHero? Zaela { get; private set; }
    public static LegendaryHero? Nekrosh { get; private set; }
    public static LegendaryHero? Gorfax { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      DragonmawPort = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(UNIT_O06E_DRAGONMAW_PORT_DRAGONMAW),
        DeathMessage =
          "The Dragonmaw Port has fallen, the Twilight Highlands are finally liberated"
      };
      CapitalManager.Register(DragonmawPort);

      LegendaryHeroManager.Register(Zaela = new LegendaryHero("Zaela")
      {
        UnitType = UNIT_O05S_WARSONG_BATTLEMASTER_DRAGONMAW
      });

      LegendaryHeroManager.Register(Nekrosh = new LegendaryHero("Nek'rosh Skullcrasher")
      {
        UnitType = UNIT_O01Q_OVERLORD_FEL_HORDE
      });

      LegendaryHeroManager.Register(Gorfax = new LegendaryHero("Gorfax")
      {
        UnitType = UNIT_O06F_CHIEFTAIN_OF_THE_BONECHEWER_CLAN_DRAGONMAW,
        StartingXp = 5400,
      });

    }
  }
}