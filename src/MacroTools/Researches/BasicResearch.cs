namespace MacroTools.Researches;

/// <summary>
/// A <see cref="Research"/> that does nothing when researched.
/// </summary>
public sealed class BasicResearch : Research
{
  /// <inheritdoc />
  public BasicResearch(int researchTypeId, int goldCost, int lumberCost = 0)
    : base(researchTypeId, goldCost, lumberCost)
  {
  }


  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
  }
}
