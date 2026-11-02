using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Ironforge.Spells;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.FelHorde.Spells;

/// <summary>While the unit has the Forge-Fury buff, its attacks splash fire around the target and set enemies burning.</summary>
public sealed class ForgeFury : UnitTrait, IAppliesEffectOnDamage
{
  public required int AbilityTypeId { get; init; }
  public required int ActiveBuffId { get; init; }
  public required float SplashRadius { get; init; }
  public required LeveledAbilityField<float> SplashDamage { get; init; }
  public required LeveledAbilityField<float> BurnDamagePerSecond { get; init; }
  public required float BurnDuration { get; init; }
  public required int BurnBuffApplicatorId { get; init; }
  public required int BurnBuffId { get; init; }
  public required string SplashEffectPath { get; init; }

  private readonly HashSet<unit> _active = new();

  /// <summary>Marks <paramref name="caster"/> as burning with Forge-Fury for <paramref name="duration"/> seconds.</summary>
  public void Activate(unit caster, float duration)
  {
    _active.Add(caster);
    var expiry = timer.Create();
    expiry.Start(duration, false, () =>
    {
      expiry.Dispose();
      _active.Remove(caster);
    });
  }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var target = @event.Unit;
    if (!@event.IsAttack || (!_active.Contains(attacker) && attacker.GetAbilityLevel(ActiveBuffId) == 0) || target.IsUnitType(unittype.Structure) ||
        !target.IsEnemyTo(attacker.Owner))
    {
      return;
    }

    var level = attacker.GetAbilityLevel(AbilityTypeId);
    if (level == 0)
    {
      return;
    }

    var splashDamage = SplashDamage.GetValue(level);
    var burnDamage = BurnDamagePerSecond.GetValue(level);
    effect.Create(SplashEffectPath, target.X, target.Y).Dispose();
    Burn(attacker, target, burnDamage);
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(target.X, target.Y, SplashRadius))
    {
      if (nearby == target || !CastFilters.IsTargetEnemyAndAliveUnits(attacker, nearby) ||
          nearby.UnitType == DummyCasterManager.UnitTypeId || nearby.IsUnitType(unittype.Structure))
      {
        continue;
      }

      attacker.DealDamage(nearby, splashDamage, false, false, attacktype.Magic, damagetype.Fire, weapontype.WhoKnows);
      Burn(attacker, nearby, burnDamage);
    }
  }

  private void Burn(unit attacker, unit victim, float damagePerSecond)
  {
    if (!victim.Alive)
    {
      return;
    }

    BuffSystem.Add(new FirebrandBuff(attacker, victim, BurnBuffApplicatorId, BurnBuffId)
    {
      Duration = BurnDuration,
      Interval = 1,
      DamagePerSecond = damagePerSecond
    }, StackBehaviour.Stack);
  }
}

/// <summary>Starts <see cref="ForgeFury"/> on the caster.</summary>
public sealed class ForgeFurySpell : Spell
{
  public required ForgeFury Trait { get; init; }
  public required float Duration { get; init; }

  public ForgeFurySpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, WCSharp.Shared.Data.Point targetPoint) => Trait.Activate(caster, Duration);
}
