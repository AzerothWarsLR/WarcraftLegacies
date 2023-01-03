using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ResearchSystems;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Researches
{
  /// <summary>
  /// When Revenants is researched, the researching player loses the ability to train Abominations,
  /// and gains the ability to train Revenants.
  /// </summary>
  public sealed class Revenants : Research
  {
    /// <inheritdoc />
    public Revenants(int researchTypeId) : base(researchTypeId)
    {
    }
    
    /// <inheritdoc />
    public override void OnResearch(player researchingPlayer)
    {
      GetTriggerPlayer().GetFaction()?.ModObjectLimit(Constants.UNIT_UABO_ABOMINATION_SCOURGE, -Faction.UNLIMITED);
      GetTriggerPlayer().GetFaction()?.ModObjectLimit(Constants.UNIT_N009_REVENANT_SCOURGE, Faction.UNLIMITED);
      SetPlayerAbilityAvailable(GetTriggerPlayer(), Constants.ABILITY_S006_CHAOS_SCOURGE_ABOMINATION, false);
    }

    /// <inheritdoc />
    public override void OnUnresearch(player researchingPlayer)
    {
      GetTriggerPlayer().GetFaction()?.ModObjectLimit(Constants.UNIT_UABO_ABOMINATION_SCOURGE, Faction.UNLIMITED);
      GetTriggerPlayer().GetFaction()?.ModObjectLimit(Constants.UNIT_N009_REVENANT_SCOURGE, -Faction.UNLIMITED);
      SetPlayerAbilityAvailable(GetTriggerPlayer(), Constants.ABILITY_S006_CHAOS_SCOURGE_ABOMINATION, true);
    }
  }
}