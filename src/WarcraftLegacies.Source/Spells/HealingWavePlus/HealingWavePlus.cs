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
        /// <summary>
        /// Duration within which the last target must die to trigger secondary waves.
        /// </summary>
        public float DeathTriggerDuration { get; init; }

        /// <summary>
        /// Healing amount per wave.
        /// </summary>
        public float HealAmountBase { get; init; }

        /// <summary>
        /// Additional healing per spell level.
        /// </summary>
        public float HealAmountLevel { get; init; }

        /// <summary>
        /// Maximum bounces for the initial wave.
        /// </summary>
        public int MaxBounces { get; init; }

        /// <summary>
        /// Radius within which healing will bounce to other units.
        /// </summary>
        public float BounceRadius { get; init; }

        /// <summary>
        /// Radius for secondary healing wave triggered on death.
        /// </summary>
        public float SecondaryWaveRadius { get; init; }

        /// <summary>
        /// Effect that plays when healing is applied.
        /// </summary>
        public string HealingEffect { get; init; }

        /// <summary>
        /// Special effect to mark units that are tracked for death.
        /// </summary>
        public string TargetMarkEffect { get; init; } = "Abilities\\Spells\\Other\\Charm\\CharmTarget.mdl";

        public HealingWavePlus(int id) : base(id)
        {
        }

        /// <summary>
        /// Called when the spell is cast.
        /// </summary>
        public override void OnCast(unit caster, unit target, Point targetPoint)
        {
            unit? lastTarget = null;
            var healedUnits = new HashSet<unit>();

            Console.WriteLine($"[HealingWavePlus] Spell cast by {GetUnitName(caster)} on {GetUnitName(target)}.");

            // Perform the initial healing wave
            PerformHealingWave(caster, target, ref lastTarget, healedUnits);

            // If there's a valid last target, mark it and monitor its death
            if (lastTarget != null)
            {
                // Apply a visual effect to mark the unit for tracking
                var triggerEffect = AddSpecialEffectTarget(TargetMarkEffect, lastTarget, "overhead");
                triggerEffect.SetLifespan(DeathTriggerDuration);

                Console.WriteLine($"[HealingWavePlus] Last healed unit marked for death trigger: {GetUnitName(lastTarget)}.");

                // Start the death trigger timer and apply the buff
                StartDeathTriggerTimer(lastTarget, caster, healedUnits);
            }
        }

        /// <summary>
        /// Handles the main healing wave, bouncing between nearby allies.
        /// </summary>
        private void PerformHealingWave(unit caster, unit currentTarget, ref unit lastTarget, HashSet<unit> healedUnits)
        {
            var bouncesRemaining = MaxBounces;

            Console.WriteLine($"[HealingWavePlus] Starting initial healing wave from {GetUnitName(currentTarget)}.");

            while (bouncesRemaining > 0 && currentTarget != null)
            {
                // Heal the target and log details
                HealTarget(caster, currentTarget);

                healedUnits.Add(currentTarget);
                lastTarget = currentTarget;

                Console.WriteLine($"[HealingWavePlus] Bounce {MaxBounces - bouncesRemaining + 1}: Healed {GetUnitName(currentTarget)}.");
                bouncesRemaining--;

                // Find the next target within BounceRadius
                currentTarget = FindNearestAlly(caster, currentTarget, healedUnits);
            }

            Console.WriteLine("[HealingWavePlus] Initial healing wave ended.");
        }

        /// <summary>
        /// Finds the nearest valid ally to continue the healing wave.
        /// </summary>
        private unit? FindNearestAlly(unit caster, unit currentTarget, HashSet<unit> excludedUnits)
        {
            return GlobalGroup.EnumUnitsInRange(currentTarget.GetPosition(), BounceRadius)
                .Where(u => IsValidAlly(caster, u) && !excludedUnits.Contains(u))
                .OrderBy(u => MathEx.GetDistanceBetweenPoints(currentTarget.GetPosition(), u.GetPosition()))
                .FirstOrDefault();
        }

        /// <summary>
        /// Heals a specific unit and plays the healing effect.
        /// </summary>
        private void HealTarget(unit caster, unit target)
        {
            var healAmount = HealAmountBase + (HealAmountLevel * GetAbilityLevel(caster));
            target.Heal(healAmount);

            Console.WriteLine($"[HealingWavePlus] {GetUnitName(target)} healed for {healAmount:F2} HP by {GetUnitName(caster)}.");

            // Apply effect on healed unit
            if (!string.IsNullOrEmpty(HealingEffect))
            {
                var effect = AddSpecialEffectTarget(HealingEffect, target, "origin");
                effect.SetLifespan();
            }
        }

        /// <summary>
        /// Starts a death-tracking timer for the last healed unit.
        /// </summary>
        private void StartDeathTriggerTimer(unit trackedTarget, unit caster, HashSet<unit> healedUnits)
        {
          // Apply the Healing Wave Buff with full configuration
          BuffSystem.Add(new HealingWaveBuff(caster, trackedTarget, DeathTriggerDuration)
          {
            Active = true,                                 // Mark as an active buff
            Duration = DeathTriggerDuration,              // Use DeathTriggerDuration for the buff's lifespan
            IsBeneficial = true                           // Indicate it's beneficial
          });

          // Example: Add logic to handle when the unit dies to trigger the secondary wave
          Console.WriteLine($"[HealingWavePlus] Buff applied to {GetUnitName(trackedTarget)} for {DeathTriggerDuration:F2} seconds.");
    
          // Start your existing death detection logic
          TimerStart(CreateTimer(), DeathTriggerDuration, false, () =>
          {
            if (!UnitAlive(trackedTarget))
            {
              Console.WriteLine($"[HealingWavePlus] Unit {GetUnitName(trackedTarget)} is dead, triggering secondary wave.");
              PerformSecondaryWave(caster, trackedTarget, healedUnits);
            }
            else
            {
              Console.WriteLine($"[HealingWavePlus] Buff expired, unit {GetUnitName(trackedTarget)} survived.");
            }
            DestroyTimer(GetExpiredTimer());
          });
        }


        /// <summary>
        /// Performs a secondary wave of healing after the tracked unit's death.
        /// </summary>
        private void PerformSecondaryWave(unit caster, unit triggerPointUnit, HashSet<unit> healedUnits)
        {
            var triggerPoint = triggerPointUnit.GetPosition();
            var lightningEffects = new List<Common.lightning>(); // Track lightning effects for cleanup
            unit lastHealedUnit = null; // Track the last healed unit

            Console.WriteLine($"[HealingWavePlus] Starting secondary healing wave at {triggerPoint}.");

            foreach (var unit in GlobalGroup.EnumUnitsInRange(triggerPoint, SecondaryWaveRadius))
            {
                if (IsValidAlly(caster, unit) && !healedUnits.Contains(unit))
                {
                    HealTarget(caster, unit);

                    Console.WriteLine($"[HealingWavePlus] Secondary wave healed: {GetUnitName(unit)}.");

                    // Create lightning effect
                    var lightning = AddLightning("DRAL", true, triggerPoint.X, triggerPoint.Y, GetUnitX(unit), GetUnitY(unit));
                    SetLightningColor(lightning, 0.0f, 1.0f, 0.0f, 1.0f); // Green with full opacity
                    lightningEffects.Add(lightning);

                    lastHealedUnit = unit;
                }
            }

            // Cleanup lightning effects
            TimerStart(CreateTimer(), 0.5f, false, () =>
            {
                foreach (var lightning in lightningEffects)
                {
                    DestroyLightning(lightning);
                }
                DestroyTimer(GetExpiredTimer());
            });

            // Apply a buff to the last healed unit of the secondary wave
            if (lastHealedUnit != null)
            {
                var healingWaveBuff = new HealingWaveBuff(caster, lastHealedUnit, DeathTriggerDuration);
                Console.WriteLine($"[HealingWavePlus] Applying buff to last healed unit: {GetUnitName(lastHealedUnit)}.");
                BuffSystem.Add(healingWaveBuff);
            }

            Console.WriteLine("[HealingWavePlus] Secondary healing wave ended.");
        }

        /// <summary>
        /// Checks if a target is a valid ally for healing.
        /// </summary>
        private static bool IsValidAlly(unit caster, unit target)
        {
            return target != null &&
                   IsUnitAlly(target, GetOwningPlayer(caster)) &&
                   UnitAlive(target) &&
                   !IsUnitType(target, UNIT_TYPE_STRUCTURE);
        }
    }
}