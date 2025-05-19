using MacroTools.Libraries;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using MacroTools.DummyCasters;
using MacroTools.Extensions;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells
{
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
      // Check if target is alive before proceeding
      if (!UnitAlive(target)) return;

      var spellLevel = GetUnitAbilityLevel(caster, Id);
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
      var chargeEffect = AddSpecialEffect(ChargeEffectPath, startPos.X, startPos.Y);
      var timer = CreateTimer();

      // Timer callback for charge movement
      TimerStart(timer, 0.02f, true, () =>
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
        BlzSetSpecialEffectX(chargeEffect, currentPos.X);
        BlzSetSpecialEffectY(chargeEffect, currentPos.Y);
      });
    }

    private void EndCharge(unit caster, unit target, effect effect, timer timer, InvulnerabilityBuff invulnerabilityBuff)
    {
      // Cleanup timer and effect
      DestroyTimer(timer);
      DestroyEffect(effect);

      // Remove invulnerability buff
      invulnerabilityBuff.Dispose();

      // Deal damage and check for execute condition
      DealDamageAndCheckExecute(caster, target);
    }

    private void DealDamageAndCheckExecute(unit caster, unit target)
    {
      var spellLevel = GetUnitAbilityLevel(caster, Id);
      var damage = BaseDamage + DamagePerLevel * spellLevel;

      // Deal base damage to target
      UnitDamageTarget(caster, target, damage, true, false,
          ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);

      // Play impact effect
      var impactEffect = AddSpecialEffect(ImpactEffectPath, GetUnitX(target), GetUnitY(target));
      DestroyEffect(impactEffect);

      // Check if target is non-hero and meets execute threshold
      if (!IsUnitType(target, UNIT_TYPE_HERO) && CheckExecute(target, spellLevel))
      {
        ExecuteTarget(caster, target);
      }
    }

    private bool CheckExecute(unit target, int level)
    {
      // Calculate execute threshold percentage
      var threshold = BaseExecuteThreshold + ExecuteThresholdPerLevel * level;
      var currentHp = GetUnitState(target, UNIT_STATE_LIFE);
      var maxHp = BlzGetUnitMaxHP(target);

      // Return true if target's HP is below threshold (without adding 1)
      return currentHp < maxHp * threshold;
    }

    private void ExecuteTarget(unit caster, unit target)
    {

      var currentHp = GetUnitState(target, UNIT_STATE_LIFE);
      UnitDamageTarget(caster, target, currentHp + 500, true, false,
          ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);

      // Play execute effect
      var executeEffect = AddSpecialEffect(ExecuteEffectPath, GetUnitX(target), GetUnitY(target));
      DestroyEffect(executeEffect);

      // Refresh spell cooldown
      RefreshSpellCooldown(caster);
    }

    private void RefreshSpellCooldown(unit caster)
    {
      var level = GetUnitAbilityLevel(caster, Id);
      // Reset ability to refresh cooldown
      UnitRemoveAbility(caster, Id);
      UnitAddAbility(caster, Id);
      // Restore ability level
      SetUnitAbilityLevel(caster, Id, level);
    }

    // Invulnerability buff during charge
    private sealed class InvulnerabilityBuff : PassiveBuff
    {
      private trigger? _damageTrigger;

      public InvulnerabilityBuff(unit caster, unit target) : base(caster, target) { }

      public override void OnApply()
      {
        // Create trigger to block all incoming damage
        _damageTrigger = CreateTrigger()
           .RegisterUnitEvent(Target, EVENT_UNIT_DAMAGED)
           .AddAction(() => BlzSetEventDamage(0));
      }

      public override void OnDispose()
      {
        // Cleanup damage trigger
        if (_damageTrigger != null) DestroyTrigger(_damageTrigger);
        base.OnDispose();
      }
    }
  }
}