using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Researches;

/// <summary>
/// A <see cref="Research"/> that rewards a <see cref="Power"/> when researched.
/// </summary>
public sealed class PowerResearch : Research
{
  private readonly Power _power;

  /// <inheritdoc />
  public PowerResearch(int researchTypeId, int goldCost, Power power) : base(researchTypeId, goldCost) => _power = power;

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer) => researchingPlayer.GetPlayerData().Faction?.AddPower(_power);
}
