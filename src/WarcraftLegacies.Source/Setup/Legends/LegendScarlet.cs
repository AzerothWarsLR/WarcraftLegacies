using System.Collections.Generic;
using MacroTools;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for creating and storing all Lordaeron <see cref="Legend"/>s.
  /// </summary>
  public sealed class LegendScarlet
  {
    public LegendaryHero Saiden { get; }
    public LegendaryHero Renault { get; }
    public LegendaryHero Brigitte { get; }
    public LegendaryHero Sally { get; }

    /// <summary>
    /// Sets up all Lordaeron <see cref="Legend"/>s.
    /// </summary>
    public LegendScarlet()
    {

      Saiden = new LegendaryHero("Saiden Dethrotan")
      {
        UnitType = Constants.UNIT_H08G_SCARLET_CRUSADER_LORD_SCARLET,
        StartingXp = 4000
      };

      Renault = new LegendaryHero("Renault Mograine")
      {
        UnitType = Constants.UNIT_H0A2_MONASTERY_COMMANDER_SCARLET,
        StartingXp = 4000
      };

      Brigitte = new LegendaryHero("Brigitte Abendis")
      {
        UnitType = Constants.UNIT_H00Y_COMMANDER_OF_THE_SCARLET_CRUSADE_SCARLET,
        StartingXp = 4000
      };

      Sally = new LegendaryHero("Sally Whitemane")
      {
        UnitType = Constants.UNIT_H08H_HIGH_INQUISITOR_SCARLET,
        StartingXp = 8800
      };

    }

    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Saiden);
      LegendaryHeroManager.Register(Renault);
      LegendaryHeroManager.Register(Brigitte);
      LegendaryHeroManager.Register(Sally);

    }
  }
}