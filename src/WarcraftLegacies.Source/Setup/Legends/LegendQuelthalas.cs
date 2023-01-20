using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendQuelthalas : IRegistersLegends
  {
    public LegendaryHero LegendAnasterian { get; }
    public LegendaryHero LegendRommath { get; }
    public LegendaryHero LegendJennalla { get; }
    public LegendaryHero LegendSylvanas { get; }
    public LegendaryHero LegendKael { get; }
    public LegendaryHero LegendLorthemar { get; }
    public LegendaryHero LegendKiljaeden { get; }
    public LegendaryHero LegendPathaleon { get; }
    public Capital LegendSilvermoon { get; }
    public Capital LegendSunwell { get; }

    public LegendQuelthalas(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendSilvermoon = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("h003")),
        DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies."
      };
      LegendSilvermoon.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_TOWER, new Point(20479, 17477)));
      LegendSilvermoon.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_TOWER, new Point(17415, 13196)));

      LegendSunwell = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_N001_THE_SUNWELL_QUEL_THALAS_OTHER),
        Capturable = true
      };
      LegendSunwell.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_TOWER, new Point(20479, 17477)));
      LegendSunwell.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_TOWER, new Point(17415, 13196)));

      LegendAnasterian = new LegendaryHero("Anasterian Sunstrider")
      {
        UnitType = Constants.UNIT_H00Q_KING_OF_QUEL_THALAS_QUEL_THALAS,
        PlayerColor = PLAYER_COLOR_MAROON,
        StartingXp = 1000,
        StartingArtifactItemTypeIds = new[]
        {
          Constants.ITEM_I00J_FELO_MELORN
        }
      };

      LegendRommath = new LegendaryHero("Grand Magister Rommath")
      {
        UnitType = Constants.UNIT_H04F_ARCHMAGE_GREEN,
        StartingXp = 1800
      };

      LegendJennalla = new LegendaryHero("Jennalla")
      {
        UnitType = Constants.UNIT_H02B_ARCANE_PHANTOM_KHADGAR
      };

      LegendPathaleon = new LegendaryHero("Pathaleon")
      {
        UnitType = Constants.UNIT_H098_SUNFURY_MASTERMIND_HIGH_ELVES,
        StartingXp = 1800
      };

      LegendSylvanas = new LegendaryHero("Sylvanas Windrunner")
      {
        UnitType = Constants.UNIT_HVWD_RANGER_GENERAL_OF_SILVERMOON_QUEL_THALAS,
        PlayerColor = PLAYER_COLOR_GREEN
      };

      LegendKael = new LegendaryHero("Kael'thas Sunstrider")
      {
        PlayerColor = PLAYER_COLOR_RED,
        UnitType = Constants.UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUEL_THALAS,
        StartingXp = 1800
      };

      LegendLorthemar = new LegendaryHero("Lor'themar Theron")
      {
        UnitType = Constants.UNIT_H02E_REGENT_OF_QUEL_THALAS_QUEL_THALAS_VASSAL,
        StartingXp = 2800
      };

      LegendKiljaeden = new LegendaryHero("Kil'jaeden")
      {
        UnitType = Constants.UNIT_U004_THE_DECEIVER_LEGION,
        PermaDies = true,
        StartingXp = 10800,
        DeathMessage =
          "Kil'jaeden the Deceiver has been annihilated, but it is too late for the Blood Elves, who will continue to live and die with demonic taint coursing through their veins."
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(LegendAnasterian);
      LegendaryHeroManager.Register(LegendRommath);
      LegendaryHeroManager.Register(LegendJennalla);
      LegendaryHeroManager.Register(LegendSylvanas);
      LegendaryHeroManager.Register(LegendKael);
      LegendaryHeroManager.Register(LegendLorthemar);
      LegendaryHeroManager.Register(LegendKiljaeden);
      LegendaryHeroManager.Register(LegendPathaleon);
      CapitalManager.Register(LegendSilvermoon);
      CapitalManager.Register(LegendSunwell);
    }
  }
}