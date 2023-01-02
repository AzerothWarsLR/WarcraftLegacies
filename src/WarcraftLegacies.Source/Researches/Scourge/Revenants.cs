using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Researches.Scourge
{
  /// <summary>
  /// When Revenants is researched, the researching player loses the ability to train Abominations,
  /// and gains the ability to train Revenants.
  /// </summary>
  public static class Revenants
  {
    private static void Research()
    {
      if (LordaeronSetup.Lordaeron == null) return;
      LordaeronSetup.Lordaeron.ModObjectLimit(Constants.UNIT_UABO_ABOMINATION_SCOURGE, -Faction.UNLIMITED);
      LordaeronSetup.Lordaeron.ModObjectLimit(Constants.UNIT_N009_REVENANT_SCOURGE, Faction.UNLIMITED);
    }

    /// <summary>
    /// Sets up <see cref="Revenants"/>.
    /// </summary>
    public static void Setup()
    {
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, Constants.UPGRADE_R00B_VETERAN_FOOTMEN_LORDAERON);
    }
  }
}