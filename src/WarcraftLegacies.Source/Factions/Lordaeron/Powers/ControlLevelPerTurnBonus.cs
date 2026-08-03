using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Powers;

/// <summary>
/// The holder gains extra Control Levels for their Control Points each turn.
/// </summary>
public sealed class ControlLevelPerTurnBonus : Power
{
  private readonly float _bonus;

  /// <summary>
  /// Initializes a new instance of the <see cref="ControlLevelPerTurnBonus"/> class.
  /// </summary>
  public ControlLevelPerTurnBonus(float bonus)
  {
    _bonus = bonus;
    Description = bonus == 1
      ? Loc.Get("Your Control Points gain an additional level each turn.")
      : Loc.Format("Your Control Points gain {bonus} additional levels each turn.", ("{bonus}", bonus.ToString()));
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer) =>
    whichPlayer.SetControlLevelPerTurnBonus(whichPlayer.GetControlLevelPerTurnBonus() + _bonus);

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer) =>
    whichPlayer.SetControlLevelPerTurnBonus(whichPlayer.GetControlLevelPerTurnBonus() - _bonus);
}
