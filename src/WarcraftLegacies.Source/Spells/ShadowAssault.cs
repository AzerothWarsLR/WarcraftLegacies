using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class ShadowAssaultSpell : Spell
{
  // Basic spell attributes
  public float BaseDamage { get; init; }
  public float DamagePerLevel { get; init; }
  public float ChargeSpeed { get; init; } = 1500; // Charge movement speed
  public float MaxChargeDistance { get; init; } = 1800; // Maximum charge distance

  // Special effect paths
  public required string ChargeEffectPath { get; init; } // Effect during charge
  public required string ExecuteEffectPath { get; init; } // Effect when executing target
  public required string ImpactEffectPath { get; init; } // Effect when hitting target

  // Dummy ability IDs (for attack speed boost)
  public int SpeedUpAbilityId { get; init; }
  public int SpeedUpOrderId { get; init; }

  // Execute threshold (percentage of max health)
  public float BaseExecuteThreshold { get; init; } = 0.15f;
  public float ExecuteThresholdPerLevel { get; init; } = 0.05f;

  public ShadowAssaultSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (!target.Alive)
    {
      return;
    }

    var spellLevel = caster.GetAbilityLevel(Id);
    var invulnerabilityBuff = ApplySpeedUpAndInvulnerability(caster, spellLevel);
    StartCharge(caster, target, invulnerabilityBuff);
  }

  private InvulnerabilityBuff ApplySpeedUpAndInvulnerability(unit caster, int level)
  {
    // Apply attack speed boost via dummy ability
    ApplySpeedUp(caster, level);

    // Apply invulnerability buff during charge
    var buff = new InvulnerabilityBuff(caster, caster);
    BuffSystem.Add(buff);
    return buff;
  }

  private void ApplySpeedUp(unit caster, int level)
  {
    // Use dummy caster to apply attack speed ability
    DummyCasterManager.GetGlobalDummyCaster().CastUnit(
        caster, SpeedUpAbilityId, SpeedUpOrderId, level,
        caster, DummyCastOriginType.Caster);
  }

  private void StartCharge(unit caster, unit target, InvulnerabilityBuff invulnerabilityBuff)
  {
    var startPos = caster.GetPosition();
    var targetPos = target.GetPosition();
    var distance = MathEx.GetDistanceBetweenPoints(startPos, targetPos);
    var totalTime = distance / ChargeSpeed; // Calculate charge duration
    var elapsedTime = 0f; // Track elapsed time

    // Create charge visual effect
    var chargeEffect = effect.Create(ChargeEffectPath, startPos.X, startPos.Y);
    timer timer = timer.Create();

    // Timer callback for charge movement
    timer.Start(0.02f, true, () =>
    {
      elapsedTime += 0.02f; // Increment time (50Hz update rate)

      if (elapsedTime >= totalTime)
      {
        EndCharge(caster, target, chargeEffect, timer, invulnerabilityBuff);
        return;
      }

      // Calculate current position using linear interpolation
      var progress = elapsedTime / totalTime;
      var currentPos = new Point(
          startPos.X + (targetPos.X - startPos.X) * progress,
          startPos.Y + (targetPos.Y - startPos.Y) * progress
      );
      caster.SetPosition(currentPos);

      // Update effect position to follow caster
      chargeEffect.SetX(currentPos.X);
      chargeEffect.SetY(currentPos.Y);
    });
  }

  private void EndCharge(unit caster, unit target, effect effect, timer timer, InvulnerabilityBuff invulnerabilityBuff)
  {
    timer.Dispose();
    effect.Dispose();

    invulnerabilityBuff.Dispose();

    DealDamageAndCheckExecute(caster, target);
  }

  private void DealDamageAndCheckExecute(unit caster, unit target)
  {
    var spellLevel = caster.GetAbilityLevel(Id);
    var damage = BaseDamage + DamagePerLevel * spellLevel;

    caster.DealDamage(target, damage, true, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);

    var impactEffect = effect.Create(ImpactEffectPath, target.X, target.Y);
    impactEffect.Dispose();

    if (!target.IsUnitType(unittype.Hero) && CheckExecute(target, spellLevel))
    {
      ExecuteTarget(caster, target);
    }
  }

  private bool CheckExecute(unit target, int level)
  {
    // Calculate execute threshold percentage
    var threshold = BaseExecuteThreshold + ExecuteThresholdPerLevel * level;
    var currentHp = target.Life;
    var maxHp = target.MaxLife;

    // Return true if target's HP is below threshold (without adding 1)
    return currentHp < maxHp * threshold;
  }

  private void ExecuteTarget(unit caster, unit target)
  {

    var currentHp = target.Life;
    caster.DealDamage(target, currentHp + 500, true, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);

    var executeEffect = effect.Create(ExecuteEffectPath, target.X, target.Y);
    executeEffect.Dispose();

    RefreshSpellCooldown(caster);
  }

  private void RefreshSpellCooldown(unit caster)
  {
    var level = caster.GetAbilityLevel(Id);
    caster.RemoveAbility(Id);
    caster.AddAbility(Id);
    caster.SetAbilityLevel(Id, level);
  }

  // Invulnerability buff during charge
  private sealed class InvulnerabilityBuff : PassiveBuff
  {
    private trigger? _damageTrigger;

    public InvulnerabilityBuff(unit caster, unit target) : base(caster, target) { }

    public override void OnApply()
    {
      _damageTrigger = trigger.Create();
      _damageTrigger.RegisterUnitEvent(Target, unitevent.Damaged);
      _damageTrigger.AddAction(() => @event.Damage = 0);
    }

    public override void OnDispose()
    {
      // Cleanup damage trigger
      if (_damageTrigger != null)
      {
        _damageTrigger.Dispose();
      }

      base.OnDispose();
    }
  }
}
