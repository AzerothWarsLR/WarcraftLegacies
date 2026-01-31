using MacroTools.Extensions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Researches;

/// <summary>
/// A research that changes the object limit of an object for the researcher.
/// </summary>
public sealed class ChangeObjectLimitResearch : Research
{
  public required int ObjectId { get; init; }

  public required int LimitChange { get; init; }

  /// <inheritdoc />
  public ChangeObjectLimitResearch(int researchTypeId, int goldCost) : base(researchTypeId, goldCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    faction?.ModObjectLimit(ObjectId, LimitChange);
  }
}
