using System;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Setup;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Shared.Powers;

/// <summary>
/// Makes some of a player's units deal more damage and survive longer. Extra health is applied as reduced damage
/// taken, so it works on units that already exist as well as new ones.
/// </summary>
public sealed class EmpoweredUnits : Power
{
  private readonly Func<unit, bool> _affectsUnit;
  private readonly float _bonus;

  /// <param name="affectsUnit">Which of the player's units get the bonus.</param>
  /// <param name="bonus">The damage and health bonus, as a fraction, like 0.15 for 15%.</param>
  public EmpoweredUnits(Func<unit, bool> affectsUnit, float bonus)
  {
    _affectsUnit = affectsUnit;
    _bonus = bonus;
  }

  /// <summary>The power's description; {bonus} is replaced with the bonus percentage.</summary>
  public required string DescriptionTemplate
  {
    init => Description = Loc.Format(value, ("{bonus}", ((int)(_bonus * 100 + 0.5f)).ToString()));
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer)
  {
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealingDamage, OnDealingDamage, whichPlayer.Id);
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakingDamage, OnTakingDamage, whichPlayer.Id);
  }

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer)
  {
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealingDamage, OnDealingDamage, whichPlayer.Id);
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerTakingDamage, OnTakingDamage, whichPlayer.Id);
  }

  private void OnDealingDamage()
  {
    var source = @event.DamageSource;
    if (source != null && _affectsUnit(source))
    {
      @event.Damage *= 1 + _bonus;
    }
  }

  private void OnTakingDamage()
  {
    if (_affectsUnit(@event.Unit))
    {
      @event.Damage /= 1 + _bonus;
    }
  }
}
