using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.UnitTraits;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Ironforge.UnitTraits;

public sealed class AvatarOfTheMountain : UnitTrait, IEffectOnSpellEffect, IEffectOnDeath, IAppliesEffectOnDamage
{
  private readonly int _avatarAbilityId;
  private readonly float _duration;
  private readonly float _cleaveFraction;
  private readonly float _cleaveRadius;

  private readonly Dictionary<unit, float> _remaining = new();

  public AvatarOfTheMountain(int avatarAbilityId, float duration, float cleaveFraction, float cleaveRadius)
  {
    _avatarAbilityId = avatarAbilityId;
    _duration = duration;
    _cleaveFraction = cleaveFraction;
    _cleaveRadius = cleaveRadius;

    AvatarOfTheMountainSystem.Traits.Add(this);
  }

  public void Tick(float dt)
  {
    var toRemove = new List<unit>();

    foreach (var kv in _remaining)
    {
      var u = kv.Key;
      var time = kv.Value - dt;

      if (time <= 0 || !u.Alive)
      {
        toRemove.Add(u);
      }
      else
      {
        _remaining[u] = time;
      }
    }

    foreach (var u in toRemove)
    {
      _remaining.Remove(u);
    }
  }

  public void OnSpellEffect()
  {
    var caster = @event.Unit;
    if (@event.SpellAbilityId != _avatarAbilityId)
    {
      return;
    }

    _remaining[caster] = _duration;
  }

  public void OnDeath()
  {
    var dead = @event.Unit;
    _remaining.Remove(dead);
  }

  public void OnDealsDamage()
  {
    var caster = @event.DamageSource;
    if (!_remaining.TryGetValue(caster, out var time))
    {
      return;
    }

    if (!@event.IsAttack)
    {
      return;
    }

    var target = @event.Unit;
    var damage = @event.Damage * _cleaveFraction;

    foreach (var u in GlobalGroup.EnumUnitsInRange(target.X, target.Y, _cleaveRadius))
    {
      if (u == target)
      {
        continue;
      }

      if (!u.Alive)
      {
        continue;
      }

      if (u.IsInvulnerable)
      {
        continue;
      }

      if (u.IsAllyTo(caster.Owner))
      {
        continue;
      }

      if (u.IsUnitType(unittype.Structure))
      {
        continue;
      }

      if (u.IsUnitType(unittype.Ancient))
      {
        continue;
      }

      u.TakeDamage(caster, damage, false, false, attacktype.Normal, damagetype.Normal);
    }
  }
}
