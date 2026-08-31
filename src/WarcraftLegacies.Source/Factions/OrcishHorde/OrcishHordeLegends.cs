using MacroTools.Legends;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

/// <summary>
/// Responsible for setting up all Orcish Horde <see cref="Legend"/>s.
/// </summary>
public sealed class OrcishHordeLegends
{
  public LegendaryHero Thrall { get; }

  public OrcishHordeLegends()
  {
    Thrall = new LegendaryHero("Thrall")
    {
      UnitType = UNIT_TP52_WARCHIEF_OF_THE_HORDE_ORCISH_HORDE
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Thrall);
  }
}
