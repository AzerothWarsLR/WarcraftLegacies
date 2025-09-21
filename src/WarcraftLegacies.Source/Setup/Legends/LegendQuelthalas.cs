using MacroTools.LegendSystem;
using MacroTools.Systems;
using WCSharp.Shared.Data;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendQuelthalas
{
  public LegendaryHero Anasterian { get; }
  public LegendaryHero Rommath { get; }
  public LegendaryHero Sylvanas { get; }
  public LegendaryHero Lorthemar { get; }
  public Capital Silvermoon { get; }
  public Capital Sunwell { get; }
  public Capital Spire { get; }

  public LegendQuelthalas(PreplacedUnitSystem preplacedUnitSystem)
  {
    Silvermoon = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(FourCC("h003")),
      DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies.",
      Essential = true
    };
    Silvermoon.AddProtector(preplacedUnitSystem.GetUnit(UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_OTHER, new Point(20479, 17477)));
    Silvermoon.AddProtector(preplacedUnitSystem.GetUnit(UNIT_H00D_ELVEN_RUNESTONE_QUEL_THALAS_OTHER, new Point(17415, 13196)));

    Sunwell = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_N001_THE_SUNWELL_QUEL_THALAS_OTHER),
      Capturable = true,
      Essential = true,
      DeathMessage = "The Sunwell, once a source of great magical energy, is no more. Its corruption has ended, and the land is free from its dark influence."
    };
    Sunwell.AddProtector(Silvermoon.Unit);

    Anasterian = new LegendaryHero("Anasterian Sunstrider")
    {
      UnitType = UNIT_H00Q_KING_OF_QUEL_THALAS_QUEL_THALAS,
      PlayerColor = playercolor.Maroon,
      StartingXp = 1000,
      StartingArtifacts = new()
      {
        new(item.Create(ITEM_I00J_FELO_MELORN, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    Rommath = new LegendaryHero("Grand Magister Rommath")
    {
      UnitType = UNIT_H04F_ARCHMAGE_GREEN,
      StartingXp = 4000
    };



    Sylvanas = new LegendaryHero("Sylvanas Windrunner")
    {
      UnitType = UNIT_HVWD_RANGER_GENERAL_OF_SILVERMOON_QUEL_THALAS,
      PlayerColor = playercolor.Green
    };


    Lorthemar = new LegendaryHero("Lor'themar Theron")
    {
      UnitType = UNIT_H02E_REGENT_OF_QUEL_THALAS_QUEL_THALAS_VASSAL,
      StartingXp = 2800
    };


    Spire = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_H0C2_WINDRUNNER_SPIRE_QUELTHALAS),
      Capturable = true
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Anasterian);
    LegendaryHeroManager.Register(Rommath);
    LegendaryHeroManager.Register(Sylvanas);
    LegendaryHeroManager.Register(Lorthemar);
    CapitalManager.Register(Silvermoon);
    CapitalManager.Register(Sunwell);
    CapitalManager.Register(Spire);
  }
}
