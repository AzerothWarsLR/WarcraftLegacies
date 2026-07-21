using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Setup;
using WCSharp.Effects;
using WCSharp.Events;


namespace WarcraftLegacies.Source.Factions.Frostwolf.Powers;

/// <summary>
/// The player's units have a chance to do bonus damage when they attack.
/// </summary>
public sealed class MaelstromWeapon : Power
{
  private readonly float _damageChance;
  private readonly float _damageDealt;

  /// <summary>
  /// The effect that appears when bonus damage is dealt.
  /// </summary>
  public string Effect { get; init; } = "";

  /// <summary>
  /// The unit types that are affected by this <see cref="Power"/>.
  /// </summary>
  public IEnumerable<int>? ValidUnitTypes;

  /// <summary>
  /// Initializes a new instance of the <see cref="MaelstromWeapon"/> class.
  /// </summary>
  public MaelstromWeapon(float damageChance, float damageDealt)
  {
    _damageChance = damageChance;
    _damageDealt = damageDealt;
    Name = Loc.Get("Maelstrom Spirit");
    Description = Loc.Format(
      "Your Orc units have a {chance}% chance on attack to call down a lightning bolt dealing {damage} magic damage. Thrall instead has a 100% chance.",
      ("{chance}", (damageChance * 100).ToString()),
      ("{damage}", damageDealt.ToString()));
  }

  /// <inheritdoc />
  public override void OnAdd(player whichPlayer) =>
    PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, whichPlayer.Id);

  /// <inheritdoc />
  public override void OnRemove(player whichPlayer) =>
    PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerDealsDamage, OnDamage, whichPlayer.Id);

  private void OnDamage()
  {
    if (!@event.IsAttack || (ValidUnitTypes != null && !ValidUnitTypes.Contains(@event.DamageSource.UnitType)))
    {
      return;
    }

    if (!unit.IsHero(@event.DamageSource.UnitType) && !(GetRandomReal(0, 1) < _damageChance))
    {
      return;
    }

    @event.Unit.TakeDamage(@event.DamageSource, _damageDealt);
    EffectSystem.Add(effect.Create(Effect, @event.Unit.X, @event.Unit.Y), 1);
  }
}
