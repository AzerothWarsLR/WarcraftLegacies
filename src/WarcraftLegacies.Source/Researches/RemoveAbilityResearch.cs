using MacroTools.Extensions;
using MacroTools.ResearchSystems;

namespace WarcraftLegacies.Source.Researches
{
  /// <summary>
  /// A research that removes access to an ability when researched.
  /// </summary>
  public sealed class RemoveAbilityResearch : Research
  {
    /// <summary>
    /// The ability to remove access to.
    /// </summary>
    public required int RemovedAbility { get; init; }
    
    /// <inheritdoc />
    public RemoveAbilityResearch(int researchTypeId, int goldCost) : base(researchTypeId, goldCost)
    {
    }

    /// <inheritdoc />
    public override void OnResearch(player researchingPlayer)
    {
      var faction = researchingPlayer.GetFaction();
      faction?.ModAbilityAvailability(RemovedAbility, -1);
    }
  }
}