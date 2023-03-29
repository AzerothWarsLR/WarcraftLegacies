using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendQuelthalas
  {
    public LegendaryHero Anasterian { get; }
    public LegendaryHero Rommath { get; }
    public LegendaryHero Jennalla { get; }
    public LegendaryHero Sylvanas { get; }
    public LegendaryHero Kael { get; }
    public LegendaryHero Lorthemar { get; }
    public LegendaryHero Kiljaeden { get; }
    public LegendaryHero Pathaleon { get; }
    public Capital Silvermoon { get; }
    public Capital Sunwell { get; }

    public LegendQuelthalas(PreplacedUnitSystem preplacedUnitSystem)
    {
      Silvermoon = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h003")),
        DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies."
      };
      Silvermoon.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_TOWER, new Point(20479, 17477)));
      Silvermoon.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_TOWER, new Point(17415, 13196)));

      Sunwell = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_N001_THE_SUNWELL_QUEL_THALAS_OTHER),
        Capturable = true
      };
      Sunwell.AddProtector(Silvermoon.Unit);

      Anasterian = new LegendaryHero("Anasterian Sunstrider")
      {
        UnitType = Constants.UNIT_H00Q_KING_OF_QUEL_THALAS_QUEL_THALAS,
        PlayerColor = PLAYER_COLOR_MAROON,
        StartingXp = 1000,
        StartingArtifactItemTypeIds = new[]
        {
          Constants.ITEM_I00J_FELO_MELORN
        }
      };

      Rommath = new LegendaryHero("Grand Magister Rommath")
      {
        UnitType = Constants.UNIT_H04F_ARCHMAGE_GREEN,
        StartingXp = 1800
      };

      Jennalla = new LegendaryHero("Jennalla")
      {
        UnitType = Constants.UNIT_H02B_ARCANE_PHANTOM_KHADGAR
      };

      Pathaleon = new LegendaryHero("Pathaleon")
      {
        UnitType = Constants.UNIT_H098_SUNFURY_MASTERMIND_HIGH_ELVES,
        StartingXp = 1800
      };

      Sylvanas = new LegendaryHero("Sylvanas Windrunner")
      {
        UnitType = Constants.UNIT_HVWD_RANGER_GENERAL_OF_SILVERMOON_QUEL_THALAS,
        PlayerColor = PLAYER_COLOR_GREEN
      };

      Kael = new LegendaryHero("Kael'thas Sunstrider")
      {
        PlayerColor = PLAYER_COLOR_RED,
        UnitType = Constants.UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUEL_THALAS,
        StartingXp = 1800
      };

      Lorthemar = new LegendaryHero("Lor'themar Theron")
      {
        UnitType = Constants.UNIT_H02E_REGENT_OF_QUEL_THALAS_QUEL_THALAS_VASSAL,
        StartingXp = 2800
      };

      Kiljaeden = new LegendaryHero("Kil'jaeden")
      {
        UnitType = Constants.UNIT_U004_THE_DECEIVER_LEGION,
        PermaDies = true,
        StartingXp = 10800,
        DeathMessage =
          "Kil'jaeden the Deceiver has been annihilated, but it is too late for the Blood Elves, who will continue to live and die with demonic taint coursing through their veins."
      };
    }
    
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Anasterian);
      LegendaryHeroManager.Register(Rommath);
      LegendaryHeroManager.Register(Jennalla);
      LegendaryHeroManager.Register(Sylvanas);
      LegendaryHeroManager.Register(Kael);
      LegendaryHeroManager.Register(Lorthemar);
      LegendaryHeroManager.Register(Kiljaeden);
      LegendaryHeroManager.Register(Pathaleon);
      CapitalManager.Register(Silvermoon);
      CapitalManager.Register(Sunwell);
    }
  }
}