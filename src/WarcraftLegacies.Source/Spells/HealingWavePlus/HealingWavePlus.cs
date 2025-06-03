using System;
using System.Linq;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using War3Api;
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
        public int MaxBounces { get; init; }
        public float BounceRadius { get; init; }
        public float SecondaryWaveRadius { get; init; }
        public string HealingEffect { get; init; }
        public string TargetMarkEffect { get; init; } = "Abilities\\Spells\\Other\\Charm\\CharmTarget.mdl";

        public HealingWavePlus(int id) : base(id) { }

        public override void OnCast(unit caster, unit target, Point targetPoint)
        {
            unit? lastTarget = null;
            var healedUnits = new HashSet<unit>();
            Console.WriteLine($"[HealingWavePlus] Spell cast by {GetUnitName(caster)} on {GetUnitName(target)}.");
            PerformHealingWave(caster, target, ref lastTarget, healedUnits);
            if (lastTarget != null)
            {
                var triggerEffect = AddSpecialEffectTarget(TargetMarkEffect, lastTarget, "overhead");
                triggerEffect.SetLifespan(DeathTriggerDuration);
                Console.WriteLine($"[HealingWavePlus] Last healed unit marked for death trigger: {GetUnitName(lastTarget)}.");
                StartDeathTriggerTimer(lastTarget, caster, healedUnits);
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
                .Where(u => IsValidAlly(caster, u) && !excludedUnits.Contains(u))
                .OrderBy(u => MathEx.GetDistanceBetweenPoints(currentTarget.GetPosition(), u.GetPosition()))
                .FirstOrDefault();
        }

        private void HealTarget(unit caster, unit target, bool isSecondaryWave = false)
        {
            float healAmount = isSecondaryWave
                ? SecondWaveHealAmount
                : HealAmountBase + (HealAmountLevel * GetAbilityLevel(caster));

            target.Heal(healAmount);

            if (!string.IsNullOrEmpty(HealingEffect))
            {
                var effect = AddSpecialEffectTarget(HealingEffect, target, "origin");
                effect.SetLifespan();
            }
        }

        private void StartDeathTriggerTimer(unit trackedTarget, unit caster, HashSet<unit> healedUnits)
        {
            var buff = new HealingWaveBuff(caster, trackedTarget, DeathTriggerDuration)
            {
                Active = true,
                Duration = DeathTriggerDuration,
                IsBeneficial = true
            };
            BuffSystem.Add(buff);

            var hasTriggeredWave = false;

            TimerStart(CreateTimer(), 0.1f, true, () =>
            {
                if (trackedTarget != null && GetUnitState(trackedTarget, UNIT_STATE_LIFE) <= 0 && !hasTriggeredWave)
                {
                    Console.WriteLine($"[HealingWavePlus] Unit {GetUnitName(trackedTarget)} is dead, triggering secondary wave.");
                    PerformSecondaryWave(caster, trackedTarget, healedUnits);
                    hasTriggeredWave = true;

                    DestroyTimer(GetExpiredTimer());
                }
                else if (trackedTarget == null)
                {
                    Console.WriteLine($"[HealingWavePlus] Timer stopped as tracked target is null.");
                    DestroyTimer(GetExpiredTimer());
                }
            });

            TimerStart(CreateTimer(), DeathTriggerDuration, false, () =>
            {
                if (!hasTriggeredWave)
                {
                    Console.WriteLine($"[HealingWavePlus] Buff expired for unit {GetUnitName(trackedTarget)}, no wave triggered.");
                }

                DestroyTimer(GetExpiredTimer());
            });
        }

        private void PerformSecondaryWave(unit caster, unit triggerPointUnit, HashSet<unit> healedUnits)
        {
            var triggerPoint = triggerPointUnit.GetPosition();
            var lightningEffects = new List<Common.lightning>();
            unit lastHealedUnit = null;

            foreach (var unit in GlobalGroup.EnumUnitsInRange(triggerPoint, SecondaryWaveRadius))
            {
                if (IsValidAlly(caster, unit) && !healedUnits.Contains(unit))
                {
                    HealTarget(caster, unit, isSecondaryWave: true);
                    var lightning = AddLightning("DRAL", true, triggerPoint.X, triggerPoint.Y, GetUnitX(unit), GetUnitY(unit));
                    SetLightningColor(lightning, 0.0f, 1.0f, 0.0f, 1.0f);
                    lightningEffects.Add(lightning);
                    lastHealedUnit = unit;
                }
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