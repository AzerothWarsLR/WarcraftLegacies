using MacroTools.Extensions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Shared.Researches;

/// <summary>
/// Replaces an ability with another ability.
/// </summary>
public sealed class ReplaceAbilityResearch : Research
{
  /// <inheritdoc />
  public ReplaceAbilityResearch(int researchTypeId, int goldCost, int lumberCost = 0) : base(researchTypeId, goldCost, lumberCost)
  {
  }

  /// <summary>
  /// The ability to remove from the player.
  /// </summary>
  public required int OldResearchTypeId { get; init; }

  /// <summary>
  /// The ability to add to the player.
  /// </summary>
  public required int NewAbilityTypeId { get; init; }

  /// <inheritdoc />
  public override void OnResearch(player player)
  {
    var faction = player.GetPlayerData().Faction;
    if (faction == null)
    {
      return;
    }

    faction.ModAbilityAvailability(OldResearchTypeId, -1);
    faction.ModAbilityAvailability(NewAbilityTypeId, 1);
  }
}
