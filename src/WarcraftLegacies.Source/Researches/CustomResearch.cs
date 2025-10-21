using System;
using MacroTools.ResearchSystems;

namespace WarcraftLegacies.Source.Researches;

/// <summary>
/// A research that can perform any function.
/// </summary>
public sealed class CustomResearch : Research
{
  /// <summary>
  /// The ability to remove access to.
  /// </summary>
  public required Action<player> ResearchFunc { get; init; }

  /// <inheritdoc />
  public CustomResearch(int researchTypeId, int goldCost) : base(researchTypeId, goldCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    ResearchFunc(researchingPlayer);
  }
}
