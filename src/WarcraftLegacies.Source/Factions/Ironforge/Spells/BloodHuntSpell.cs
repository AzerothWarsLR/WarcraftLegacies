using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Sends a spirit wolf after an enemy that pins it in place and mauls it.</summary>
public sealed class BloodHuntSpell : Spell
{
  public required LeveledAbilityField<float> BiteDamage { get; init; }
  public required LeveledAbilityField<float> DamagePerSecond { get; init; }
  public required LeveledAbilityField<float> Duration { get; init; }
  public required float BleedDuration { get; init; }
  public required int BleedApplicatorId { get; init; }
  public required int BleedBuffId { get; init; }
  public required float WolfSpeed { get; init; }
  public required int PinAbilityId { get; init; }
  public required string WolfPath { get; init; }

  public BloodHuntSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    MissileSystem.Add(new BloodHuntWolfMissile(caster, target)
    {
      Spell = this,
      Level = GetAbilityLevel(caster),
      EffectString = WolfPath,
      Speed = WolfSpeed,
      Interval = 0.03f,
      Active = true
    });
  }

  /// <summary>Pins and mauls the target once the wolf reaches it.</summary>
  public void Maul(unit caster, unit target, int level)
  {
    if (!target.Alive)
    {
      return;
    }

    var duration = Duration.GetValue(level);
    caster.DealDamage(target, BiteDamage.GetValue(level), false, false, attacktype.Normal, damagetype.Magic,
      weapontype.WhoKnows);
    if (!target.Alive)
    {
      return;
    }

    DummyCasterManager.GetGlobalDummyCaster()
      .CastUnit(caster, PinAbilityId, ORDER_ENTANGLING_ROOTS, level, target, DummyCastOriginType.Target);
    BuffSystem.Add(new BloodHuntBuff(caster, target, BleedApplicatorId, BleedBuffId)
    {
      Duration = BleedDuration,
      Interval = 0.5f,
      DamagePerTick = DamagePerSecond.GetValue(level) * 0.5f
    }, StackBehaviour.Stack);

    var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, target.X, target.Y);
    var wolf = effect.Create(WolfPath, MathEx.GetPolarOffsetX(target.X, -60, angle),
      MathEx.GetPolarOffsetY(target.Y, -60, angle));
    wolf.SetYaw(angle * MathEx.DegToRad);
    wolf.PlayAnimation(animtype.Attack);
    var mauling = timer.Create();
    mauling.Start(duration, false, () =>
    {
      mauling.Dispose();
      wolf.SetZ(-1000f);
      wolf.Dispose();
    });
  }
}

/// <summary>The wolf from <see cref="BloodHuntSpell"/> running down its target.</summary>
public sealed class BloodHuntWolfMissile : BasicMissile
{
  private bool _running;

  public required BloodHuntSpell Spell { get; init; }
  public required int Level { get; init; }

  public BloodHuntWolfMissile(unit caster, unit target) : base(caster, target)
  {
  }

  /// <inheritdoc />
  public override void OnPeriodic()
  {
    if (_running || Effect == null)
    {
      return;
    }

    Effect.PlayAnimation(animtype.Walk);
    _running = true;
  }

  /// <inheritdoc />
  public override void OnImpact() => Spell.Maul(Caster, Target, Level);

  /// <inheritdoc />
  public override void OnDispose()
  {
    if (Effect != null)
    {
      Effect.SetZ(-1000f);
    }
  }
}

/// <summary>The bleed from <see cref="BloodHuntSpell"/>.</summary>
public sealed class BloodHuntBuff : BoundBuff
{
  public required float DamagePerTick { get; init; }

  public BloodHuntBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = false;
    BindAura(buffApplicatorId, buffId);
  }

  /// <inheritdoc />
  public override void OnTick() =>
    Caster.DealDamage(Target, DamagePerTick, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);

  /// <inheritdoc />
  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }
}
