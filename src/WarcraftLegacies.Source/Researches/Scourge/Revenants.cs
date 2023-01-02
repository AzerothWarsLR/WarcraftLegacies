using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

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
      GetTriggerPlayer().GetFaction()?.ModObjectLimit(Constants.UNIT_UABO_ABOMINATION_SCOURGE, -Faction.UNLIMITED);
      GetTriggerPlayer().GetFaction()?.ModObjectLimit(Constants.UNIT_N009_REVENANT_SCOURGE, Faction.UNLIMITED);
    }

    /// <summary>
    /// Sets up <see cref="Revenants"/>.
    /// </summary>
    public static void Setup() =>
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research, Constants.UPGRADE_R08T_REVENANTS_SCOURGE);
  }
}