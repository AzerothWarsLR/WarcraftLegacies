using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
using War3Api;
using WCSharp.Effects;

namespace MacroTools.Spells
{
    public sealed class MassSpellAnySpellAndDamage : Spell
    {
        public float DamageBase { get; init; }
        public float DamageLevel { get; init; }
        public int DurationBase { get; init; }
        public int DurationLevel { get; init; }
        public string SpecialEffect { get; init; } = "";

        public int DummyAbilityId { get; init; }                  // Dummy ability ID
        public int DummyAbilityOrderId { get; init; }            // Order ID of the dummy ability
        public float Radius { get; init; }                       // AoE Radius
        
        public float Chance { get; init; } = 1.0f; // Default to 100% application

        public DummyCasterManager.CastFilter CastFilter { get; init; } // Criteria to filter targets
        public SpellTargetType TargetType { get; init; } = SpellTargetType.None; // Target Type
        public DummyCastOriginType DummyCastOriginType { get; init; } = DummyCastOriginType.Target; // Origin

        public MassSpellAnySpellAndDamage(int id) : base(id)
        {
            DummyAbilityId = 0; // Default to no dummy ability
            DummyAbilityOrderId = 0;
            CastFilter = (c, u) => false; // No targets by default
        }

        public override void OnCast(Common.unit caster, Common.unit target, Point targetPoint)
        {
            base.OnCast(caster, target, targetPoint);

            var center = TargetType == SpellTargetType.None ? new Point(GetUnitX(caster), GetUnitY(caster)) : targetPoint;
            foreach (var unit in GetUnitsInRadius(center, Radius, CastFilter))
            {
                // Apply damage
                var damage = DamageBase + DamageLevel * GetAbilityLevel(caster);
                UnitDamageTarget(caster, unit, damage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);

                // Apply dummy cast
                if (DummyAbilityId != 0 && DurationBase > 0)
                {
                    var duration = DurationBase + DurationLevel * GetAbilityLevel(caster);
                    DummyCasterManager.GetGlobalDummyCaster()
                        .CastUnit(caster, DummyAbilityId, DummyAbilityOrderId, duration, unit, DummyCastOriginType);
                }

                // Add special effect
                if (!string.IsNullOrEmpty(SpecialEffect))
                {
                    EffectSystem.Add(AddSpecialEffect(SpecialEffect, GetUnitX(unit), GetUnitY(unit)));
                }
            }
        }

        private IEnumerable<Common.unit> GetUnitsInRadius(Point center, float radius, DummyCasterManager.CastFilter castFilter)
        {
            var group = CreateGroup();
            GroupEnumUnitsInRange(group, center.X, center.Y, radius, null);
            var units = new List<Common.unit>();
            Common.unit u;

            while ((u = FirstOfGroup(group)) != null)
            {
                GroupRemoveUnit(group, u);
                if (castFilter(null, u))
                {
                    units.Add(u);
                }
            }

            DestroyGroup(group);
            return units;
        }
    }
}