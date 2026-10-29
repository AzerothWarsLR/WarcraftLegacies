using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Burns an enemy for a while. If it dies while branded, it bursts and damages enemies around it.</summary>
public sealed class ShadowflameBrandSpell : Spell
{
  public required float DamagePerSecond { get; init; }
  public required float Duration { get; init; }
  public required float BurstDamage { get; init; }
  public required float BurstRadius { get; init; }
  public required string BurstEffectPath { get; init; }

  public ShadowflameBrandSpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitDies);
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint) =>
    BuffSystem.Add(new ShadowflameBrandBuff(caster, target)
    {
      Duration = Duration,
      Interval = 1,
      DamagePerSecond = DamagePerSecond
    }, StackBehaviour.Stack);

  private void OnUnitDies()
  {
    var dying = @event.Unit;
    if (!ShadowflameBrandBuff.Branded.TryGetValue(dying, out var brand))
    {
      return;
    }

    ShadowflameBrandBuff.Branded.Remove(dying);
    effect.Create(BurstEffectPath, dying.X, dying.Y).Dispose();
    foreach (var victim in GlobalGroup.EnumUnitsInRange(dying.X, dying.Y, BurstRadius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(brand.Caster, victim) || victim.UnitType == DummyCasterManager.UnitTypeId ||
          victim.IsUnitType(unittype.Structure))
      {
        continue;
      }

      brand.Caster.DealDamage(victim, BurstDamage, false, false, attacktype.Magic, damagetype.Fire, weapontype.WhoKnows);
    }
  }
}

/// <summary>The burning from <see cref="ShadowflameBrandSpell"/>.</summary>
public sealed class ShadowflameBrandBuff : TickingBuff
{
  /// <summary>Every unit currently branded, with its brand.</summary>
  public static readonly Dictionary<unit, ShadowflameBrandBuff> Branded = new();

  public required float DamagePerSecond { get; init; }

  public ShadowflameBrandBuff(unit caster, unit target) : base(caster, target)
  {
    IsBeneficial = false;
  }

  /// <inheritdoc />
  public override void OnApply() => Branded[Target] = this;

  /// <inheritdoc />
  public override void OnTick() =>
    Caster.DealDamage(Target, DamagePerSecond, false, false, attacktype.Magic, damagetype.Fire, weapontype.WhoKnows);

  /// <inheritdoc />
  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    if (Branded.TryGetValue(Target, out var brand))
    {
      if (brand == this && Target.Alive)
      {
        Branded.Remove(Target);
      }
    }
  }
}
