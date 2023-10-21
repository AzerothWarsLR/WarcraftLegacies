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

    /// <summary>
    /// Sets up all Lordaeron <see cref="Legend"/>s.
    /// </summary>
    public LegendScarlet()
    {

      Saiden = new LegendaryHero("Crusader Lord Saiden Dethrotan")
      {
        UnitType = Constants.UNIT_H08G_SCARLET_CRUSADER_LORD_SCARLET,
        StartingXp = 2800
      };

    }

    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Saiden);

    }
  }
}