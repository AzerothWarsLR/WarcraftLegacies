using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ResearchSystems;

namespace WarcraftLegacies.Source.Researches
{
  /// <summary>
  /// A <see cref="Research"/> that rewards a <see cref="Power"/> when researched.
  /// </summary>
  public sealed class PowerResearch : Research
  {
    private readonly Power _power;

    /// <inheritdoc />
    public PowerResearch(int researchTypeId, int goldCost, int lumberCost, Power power) : base(researchTypeId, goldCost,
      lumberCost) => _power = power;

    /// <inheritdoc />
    public override void OnResearch(player researchingPlayer) => researchingPlayer.GetFaction()?.AddPower(_power);
  }
}