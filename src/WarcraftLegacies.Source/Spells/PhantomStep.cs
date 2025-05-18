using System;
using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
    /// <summary>
    /// Creates a Mirror Image (Illusion) of the casting unit
    /// </summary>
    public sealed class PhantomStep : Spell
    {

        public string CasterEffect { get; init; } = string.Empty;
        
        public int DummyAbilityId { get; init; }
        
        public int DummyOrderId { get; init; }

        /// <inheritdoc />
        public PhantomStep(int id) : base(id)
        {
        }
        /// <inheritdoc />
        public override void OnCast(unit caster, unit target, Point targetPoint)
        {
            try
            {
                Console.WriteLine($"[{nameof(PhantomStep)}] Spell cast started for caster: {GetUnitName(caster)} (ID: {GetUnitTypeId(caster)}).");
                EffectSystem.Add(AddSpecialEffect(CasterEffect, GetUnitX(caster), GetUnitY(caster)));
                Console.WriteLine($"[{nameof(PhantomStep)}] Played special effect at position ({GetUnitX(caster)}, {GetUnitY(caster)}).");
                DummyCasterManager.GetGlobalDummyCaster()
                    .CastUnit(caster, DummyAbilityId, DummyOrderId, 1, caster, DummyCastOriginType.Target);
                Console.WriteLine($"[{nameof(PhantomStep)}] Dummy ability {DummyAbilityId} cast on caster {GetUnitName(caster)} (ID: {GetUnitTypeId(caster)}).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{nameof(PhantomStep)}] Error during spell execution: {ex}");
            }
        }
    }
}