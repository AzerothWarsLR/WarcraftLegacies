using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Ahnqiraj.UnitTraits.SpellConduction;

public sealed class SpellConductionTrait : UnitTrait, IEffectOnCreated
{
  private readonly List<unit> _conductors = new();

  /// <summary>
  /// The research required for this ability to work.
  /// </summary>
  public required int RequiredResearch { get; init; }

  /// <summary>
  /// How much damage to redirect to the caster.
  /// </summary>
  public required float RedirectionPercentage { get; init; }

  /// <summary>
  /// Attack types that can be redirected.
  /// </summary>
  public required attacktype[] RedirectableAttackTypes { get; init; }

  /// <summary>
  /// Units this far away will get damage redirected from them.
  /// </summary>
  public required int Radius { get; init; }

  public SpellConductionTrait()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, OnDamageTaken);
  }

  /// <inheritdoc />
  public void OnCreated(unit createdUnit)
  {
    if (!_conductors.Contains(createdUnit))
    {
      _conductors.Add(createdUnit);
    }
  }

  private void OnDamageTaken()
  {
    var target = @event.Unit;
    var attackType = @event.AttackType;
    if (_conductors.Count == 0 ||
        !RedirectableAttackTypes.Contains(attackType) ||
        UnitTypeTraitRegistry.UnitHasTrait(target, typeof(SpellConductionTrait)))
    {
      return;
    }

    var damageSource = @event.DamageSource;
    var damageType = @event.DamageType;
    var weaponType = @event.WeaponType;
    var eventDamage = @event.Damage;

    for (var i = 0; i < _conductors.Count;)
    {
      var conductor = _conductors[i];
      if (!conductor.Alive)
      {
        _conductors.RemoveAt(i);
        continue;
      }

      i++;
      if (conductor.Owner.GetTechResearched(RequiredResearch, false) <= 0 ||
          !CastFilters.IsTargetAllyAndAlive(conductor, target) ||
          !IsInRange(conductor, target))
      {
        continue;
      }

      var redirectedDamage = eventDamage * RedirectionPercentage;
      eventDamage *= 1 - RedirectionPercentage;
      @event.Damage = eventDamage;
      conductor.TakeDamage(damageSource, redirectedDamage, false, true,
        attackType, damageType, weaponType);
    }
  }

  private bool IsInRange(unit conductor, unit target)
  {
    var deltaX = conductor.X - target.X;
    var deltaY = conductor.Y - target.Y;
    return deltaX * deltaX + deltaY * deltaY <= Radius * Radius;
  }
}
