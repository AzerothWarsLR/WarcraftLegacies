using MacroTools;
using MacroTools.FactionSystem;

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
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_O06E_DRAGONMAW_PORT),
        DeathMessage =
          "The Dragonmaw Port has fallen, the Twilight Highlands are finally liberated"
      };
      Legend.Register(DragonmawPort);

      Legend.Register(Zaela = new LegendaryHero
      {
        Name = "Zaela",
        UnitType = Constants.UNIT_O05S_WARLORD_MAIDEN_DRAGONMAW
      });

      Legend.Register(Nekrosh = new LegendaryHero
      {
        Name = "Nek'rosh Skullcrasher",
        UnitType = Constants.UNIT_O01Q_DRAGONMAW_CHIEFTAIN_FEL_HORDE
      });

      Legend.Register(Gorfax = new LegendaryHero
      {
        Name = "Gorfax Angerfang",
        UnitType = Constants.UNIT_O06F_BLOOD_WARRIOR_DRAGONMAW,
        StartingXp = 5400,
      });

    }
  }
}