using MacroTools.Spells;
using WCSharp.Buffs;
using WCSharp.Effects;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Factions.Druids.Spells;

public sealed class SeedOfRebirthSpell : Spell
{
  public required float[] InitialDamage { get; init; }
  public required LeveledAbilityField<float> DamagePerSecond { get; init; }
  public required float Duration { get; init; }
  public required float TickPeriod { get; init; }
  public required float VisionRadius { get; init; }
  public required int TreantUnitTypeId { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required string SeedEffectPath { get; init; }
  public required float SeedEffectScale { get; init; }
  public required string SproutEffectPath { get; init; }

  public SeedOfRebirthSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    BuffSystem.Add(new SeedOfRebirthBuff(caster, target)
    {
      Duration = Duration,
      Interval = TickPeriod,
      DamagePerTick = DamagePerSecond.GetValue(level) * TickPeriod,
      VisionRadius = VisionRadius,
      TreantUnitTypeId = TreantUnitTypeId,
      BuffApplicatorId = BuffApplicatorId,
      SproutEffectPath = SproutEffectPath,
      EffectString = SeedEffectPath,
      EffectScale = SeedEffectScale
    }, StackBehaviour.Stack);
    target.Damage(caster, InitialDamage[level - 1], attacktype.Magic);
  }
}

public sealed class SeedOfRebirthBuff : TickingBuff
{
  private fogmodifier? _vision;

  public float DamagePerTick { get; init; }
  public float VisionRadius { get; init; }
  public int TreantUnitTypeId { get; init; }
  public int BuffApplicatorId { get; init; }
  public string? SproutEffectPath { get; init; }

  public SeedOfRebirthBuff(unit caster, unit target) : base(caster, target)
  {
    IsBeneficial = false;
  }

  public override void OnApply()
  {
    Target.AddAbility(BuffApplicatorId);
    BlzUnitHideAbility(Target, BuffApplicatorId, true);
    UpdateVision();
  }

  public override void OnTick()
  {
    UpdateVision();
    Target.Damage(Caster, DamagePerTick, attacktype.Magic);
  }

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }

  public override int OnDispel(unit dispeller, int dispelCount)
  {
    return 0;
  }

  public override void OnDeath(bool killingBlow)
  {
    if (!Target.IsIllusion)
    {
      var treant = unit.Create(CastingPlayer, TreantUnitTypeId, Target.X, Target.Y, Target.Facing);
      if (SproutEffectPath != null)
      {
        EffectSystem.Add(effect.Create(SproutEffectPath, treant.X, treant.Y));
      }
    }

    base.OnDeath(killingBlow);
  }

  public override void OnDispose()
  {
    Target.RemoveAbility(BuffApplicatorId);
    _vision?.Dispose();
    _vision = null;
    base.OnDispose();
  }

  private void UpdateVision()
  {
    var vision = fogmodifier.Create(Target.X, Target.Y, VisionRadius, CastingPlayer, fogstate.Visible, true, false);
    vision.Start();
    _vision?.Dispose();
    _vision = vision;
  }
}
