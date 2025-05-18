using System;
using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
    /// <summary>
    /// Creates a Mirror Image (Illusion) of the casting unit, with level-based scaling.
    /// </summary>
    public sealed class PhantomStep : Spell
    {
        /// <summary>
        /// Visual effect played when the spell is cast.
        /// </summary>
        public string CasterEffect { get; init; } = string.Empty;

        /// <summary>
        /// The dummy ability used to create the illusion.
        /// </summary>
        public int DummyAbilityId { get; init; }

        /// <summary>
        /// Order ID of the dummy ability.
        /// </summary>
        public int DummyOrderId { get; init; }

        // Scaling fields
        /// <summary>
        /// Base number of illusions created by the spell.
        /// </summary>
        public int IllusionCountBase { get; init; } = 1;

        /// <summary>
        /// Additional illusions per level of the spell.
        /// </summary>
        public int IllusionCountPerLevel { get; init; } = 0;

        /// <summary>
        /// Base duration of the created illusions (in seconds).
        /// </summary>
        public float IllusionDurationBase { get; init; } = 5f;

        /// <summary>
        /// Additional duration per level of the spell (in seconds).
        /// </summary>
        public float IllusionDurationPerLevel { get; init; } = 1f;

        /// <summary>
        /// Base scaling factor for the special effect.
        /// </summary>
        public float EffectScaleBase { get; init; } = 1.0f;

        /// <summary>
        /// Additional effect scaling factor per level.
        /// </summary>
        public float EffectScalePerLevel { get; init; } = 0.5f;

        /// <inheritdoc />
        public PhantomStep(int id) : base(id)
        {
        }

        /// <inheritdoc />
        public override void OnCast(unit caster, unit target, Point targetPoint)
        {
            try
            {
                // Get the caster's spell level
                int casterLevel = GetAbilityLevel(caster);

                // Calculate scaling values
                int illusionCount = IllusionCountBase + (IllusionCountPerLevel * (casterLevel - 1));
                float illusionDuration = IllusionDurationBase + (IllusionDurationPerLevel * (casterLevel - 1));
                float effectScale = EffectScaleBase + (EffectScalePerLevel * (casterLevel - 1));

                // Log calculated parameters
                Console.WriteLine($"[{nameof(PhantomStep)}] Spell cast started for caster: {GetUnitName(caster)} (ID: {GetUnitTypeId(caster)}, Level: {casterLevel}).");
                Console.WriteLine($"[{nameof(PhantomStep)}] Illusion count: {illusionCount}, Illusion duration: {illusionDuration}s, Effect scale: {effectScale}.");

                // Play the caster effect
                var effect = AddSpecialEffect(CasterEffect, GetUnitX(caster), GetUnitY(caster));
                BlzSetSpecialEffectScale(effect, effectScale); // Scale the special effect dynamically
                DestroyEffect(effect); // Destroy effect after playing
                Console.WriteLine($"[{nameof(PhantomStep)}] Played special effect at position ({GetUnitX(caster)}, {GetUnitY(caster)}), scale: {effectScale}.");

                // Create illusions
                for (int i = 0; i < illusionCount; i++)
                {
                    DummyCasterManager.GetGlobalDummyCaster()
                        .CastUnit(caster, DummyAbilityId, DummyOrderId, 1, caster, DummyCastOriginType.Target);

                    Console.WriteLine($"[{nameof(PhantomStep)}] Created illusion #{i + 1} with duration {illusionDuration}s.");
                }

                Console.WriteLine($"[{nameof(PhantomStep)}] PhantomStep spell execution completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{nameof(PhantomStep)}] Error during spell execution: {ex}");
            }
        }
    }
}