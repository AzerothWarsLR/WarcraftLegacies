using MacroTools.Extensions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Shared.Researches;

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
  public RemoveAbilityResearch(int researchTypeId, int goldCost, int lumberCost = 0) : base(researchTypeId, goldCost, lumberCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    faction?.ModAbilityAvailability(RemovedAbility, -1);
  }
}
