using System.Linq;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.HealingWavePlus
{
    public sealed class HealingWavePlus : Spell
    {
        public float DeathTriggerDuration { get; init; }
        public float HealAmountBase { get; init; }
        public float HealAmountLevel { get; init; }
        public float SecondWaveHealAmount { get; init; }
        public float HealingReductionFactor { get; init; } = 0.9f;
        public int MaxBounces { get; init; }
        public float BounceRadius { get; init; }
        public float SecondaryWaveRadius { get; init; }
        public string HealingEffect { get; init; }
        public float HealingEffectScale { get; init; } = 0.5f;
        public string TargetMarkEffect { get; init; }

        private float _currentHealingModifier = 1.0f;

        public HealingWavePlus(int id) : base(id) { }

        public override void OnCast(unit caster, unit target, Point targetPoint)
        {
            _currentHealingModifier = 1.0f;

            unit? lastTarget = null;
            var healedUnits = new HashSet<unit>();
            PerformHealingWave(caster, target, ref lastTarget, healedUnits);

            if (lastTarget != null)
            {
                var triggerEffect = AddSpecialEffectTarget(TargetMarkEffect, lastTarget, "overhead");
                triggerEffect.SetLifespan(DeathTriggerDuration);
                StartDeathTriggerTimer(lastTarget, caster, healedUnits, triggerEffect);
            }
        }

        private void PerformHealingWave(unit caster, unit currentTarget, ref unit lastTarget, HashSet<unit> healedUnits)
        {
            var bouncesRemaining = MaxBounces;
            while (bouncesRemaining > 0 && currentTarget != null)
            {
                HealTarget(caster, currentTarget);
                healedUnits.Add(currentTarget);
                lastTarget = currentTarget;
                bouncesRemaining--;
                currentTarget = FindNearestAlly(caster, currentTarget, healedUnits);
            }
        }

        private unit? FindNearestAlly(unit caster, unit currentTarget, HashSet<unit> excludedUnits)
        {
            return GlobalGroup.EnumUnitsInRange(currentTarget.GetPosition(), BounceRadius)
                .Where(u => HealingWavePlus.IsValidAlly(caster, u) && !excludedUnits.Contains(u))
                .OrderBy(u => MathEx.GetDistanceBetweenPoints(currentTarget.GetPosition(), u.GetPosition()))
                .FirstOrDefault();
        }

        private void HealTarget(unit caster, unit target, bool isSecondaryWave = false)
        {
            float healAmount = (isSecondaryWave
                ? SecondWaveHealAmount
                : HealAmountBase + (HealAmountLevel * GetAbilityLevel(caster))) * _currentHealingModifier;

            target.Heal(healAmount);

            if (!string.IsNullOrEmpty(HealingEffect))
            {
                var effect = AddSpecialEffectTarget(HealingEffect, target, "origin");
                effect.SetScale(HealingEffectScale);
                effect.SetLifespan();
            }
            _currentHealingModifier *= HealingReductionFactor;
        }

        private void StartDeathTriggerTimer(unit trackedTarget, unit caster, HashSet<unit> healedUnits, effect triggerEffect = null)
        {
            var buff = new HealingWaveBuff(caster, trackedTarget, DeathTriggerDuration)
            {
                Active = true,
                Duration = DeathTriggerDuration,
                IsBeneficial = true
            };
            BuffSystem.Add(buff);

            var hasTriggeredWave = false;
            
            var deathCheckTimer = CreateTimer();
            TimerStart(deathCheckTimer, 0.1f, true, () =>
            {
                if (trackedTarget != null && GetUnitState(trackedTarget, UNIT_STATE_LIFE) <= 0 && !hasTriggeredWave)
                {
                    PerformSecondaryWave(caster, trackedTarget, healedUnits);
                    hasTriggeredWave = true;
                    if (triggerEffect != null)
                    {
                        DestroyEffect(triggerEffect);
                    }
                    DestroyTimer(deathCheckTimer);
                }
                else if (trackedTarget == null)
                {
                    DestroyTimer(deathCheckTimer);
                }
            });
          
            var timeoutTimer = CreateTimer();
            TimerStart(timeoutTimer, DeathTriggerDuration, false, () =>
            {
                DestroyTimer(deathCheckTimer);
                DestroyTimer(timeoutTimer);
            });
        }

        private void PerformSecondaryWave(unit caster, unit triggerPointUnit, HashSet<unit> healedUnits)
        {
            var triggerPoint = triggerPointUnit.GetPosition();
            var lightningEffects = new List<lightning>();
            unit lastHealedUnit = null;

            var nearbyAllies = GlobalGroup.EnumUnitsInRange(triggerPoint, SecondaryWaveRadius)
                .Where(ally => HealingWavePlus.IsValidAlly(caster, ally) && !healedUnits.Contains(ally))
                .OrderBy(ally => MathEx.GetDistanceBetweenPoints(triggerPoint, ally.GetPosition()))
                .Take(MaxBounces)
                .ToList();

            foreach (var ally in nearbyAllies)
            {
                HealTarget(caster, ally, isSecondaryWave: true);
                var lightning = AddLightning("DRAL", true, triggerPoint.X, triggerPoint.Y, GetUnitX(ally), GetUnitY(ally));
                SetLightningColor(lightning, 0.0f, 1.0f, 0.0f, 1.0f);
                lightningEffects.Add(lightning);
                lastHealedUnit = ally;
            }
            TimerStart(CreateTimer(), 0.5f, false, () =>
            {
                foreach (var lightning in lightningEffects)
                {
                    DestroyLightning(lightning);
                }
                DestroyTimer(GetExpiredTimer());
            });

            if (lastHealedUnit != null)
            {
                var healingWaveBuff = new HealingWaveBuff(caster, lastHealedUnit, DeathTriggerDuration);
                BuffSystem.Add(healingWaveBuff);
                StartDeathTriggerTimer(lastHealedUnit, caster, healedUnits);
            }
        }

        private static bool IsValidAlly(unit caster, unit target)
        {
            return target != null
                && IsUnitAlly(target, GetOwningPlayer(caster))
                && UnitAlive(target)
                && !IsUnitType(target, UNIT_TYPE_STRUCTURE);
        }
    }
}