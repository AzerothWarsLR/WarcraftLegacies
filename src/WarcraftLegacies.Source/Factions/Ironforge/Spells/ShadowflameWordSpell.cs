using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Curses a target with shadowflame. If it dies while cursed, the curse jumps to the nearest enemy.</summary>
public sealed class ShadowflameWordSpell : Spell
{
  public required LeveledAbilityField<float> DamagePerSecond { get; init; }
  public required float Duration { get; init; }
  public required int Jumps { get; init; }
  public required float JumpRange { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }
  public required string TickEffectPath { get; init; }
  public int BonusJumpResearchId { get; init; }

  public ShadowflameWordSpell(int id) : base(id)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitDies);
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var jumps = Jumps;
    if (BonusJumpResearchId != 0 && caster.Owner.GetTechResearched(BonusJumpResearchId, false) > 0)
    {
      jumps++;
    }

    Curse(caster, target, DamagePerSecond.GetValue(caster.GetAbilityLevel(Id)), jumps);
  }

  private void Curse(unit caster, unit target, float damagePerSecond, int jumpsLeft) =>
    BuffSystem.Add(new ShadowflameWordBuff(caster, target, BuffApplicatorId, BuffId)
    {
      Duration = Duration,
      Interval = 1,
      DamagePerSecond = damagePerSecond,
      JumpsLeft = jumpsLeft,
      TickEffectPath = TickEffectPath
    }, StackBehaviour.Stack);

  private void OnUnitDies()
  {
    var dying = @event.Unit;
    if (!ShadowflameWordBuff.Cursed.TryGetValue(dying, out var curse))
    {
      return;
    }

    ShadowflameWordBuff.Cursed.Remove(dying);
    if (curse.JumpsLeft <= 0)
    {
      return;
    }

    var next = FindNearestEnemy(curse.Caster, dying.X, dying.Y);
    if (next != null)
    {
      Curse(curse.Caster, next, curse.DamagePerSecond, curse.JumpsLeft - 1);
    }
  }

  private unit? FindNearestEnemy(unit caster, float x, float y)
  {
    unit? nearest = null;
    var nearestDistance = float.MaxValue;
    foreach (var candidate in GlobalGroup.EnumUnitsInRange(x, y, JumpRange))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, candidate) || candidate.UnitType == DummyCasterManager.UnitTypeId ||
          candidate.IsUnitType(unittype.Structure) || ShadowflameWordBuff.Cursed.ContainsKey(candidate))
      {
        continue;
      }

      var dx = candidate.X - x;
      var dy = candidate.Y - y;
      var distance = dx * dx + dy * dy;
      if (distance < nearestDistance)
      {
        nearestDistance = distance;
        nearest = candidate;
      }
    }

    return nearest;
  }
}

/// <summary>The curse from <see cref="ShadowflameWordSpell"/>.</summary>
public sealed class ShadowflameWordBuff : BoundBuff
{
  /// <summary>Every unit currently cursed, with its curse.</summary>
  public static readonly Dictionary<unit, ShadowflameWordBuff> Cursed = new();

  public required float DamagePerSecond { get; set; }
  public required int JumpsLeft { get; set; }
  public required string TickEffectPath { get; init; }

  public ShadowflameWordBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = false;
    BindAura(buffApplicatorId, buffId);
  }

  /// <inheritdoc />
  public override void OnApply() => Cursed[Target] = this;

  /// <inheritdoc />
  public override void OnTick()
  {
    Caster.DealDamage(Target, DamagePerSecond, false, false, attacktype.Magic, damagetype.Magic, weapontype.WhoKnows);
    AddSpecialEffectTarget(TickEffectPath, Target, "origin").Dispose();
  }

  /// <inheritdoc />
  public override StackResult OnStack(Buff newStack)
  {
    var refresh = (ShadowflameWordBuff)newStack;
    Duration = refresh.Duration;
    DamagePerSecond = refresh.DamagePerSecond;
    if (refresh.JumpsLeft > JumpsLeft)
    {
      JumpsLeft = refresh.JumpsLeft;
    }

    return StackResult.Stack;
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    if (Cursed.TryGetValue(Target, out var curse))
    {
      if (curse == this)
      {
        Cursed.Remove(Target);
      }
    }

    base.OnDispose();
  }
}
