using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells
{
    public sealed class AnySpellNoTarget : Spell
    {
        public int DummyAbilityId { get; init; }
        public int DummyAbilityOrderId { get; init; }

        public AnySpellNoTarget(int id) : base(id)
        {
        }

        public override void OnCast(unit caster, unit target, Point targetPoint)
        {
            DummyCasterManager.GetGlobalDummyCaster().CastNoTarget(
                caster,
                DummyAbilityId,
                DummyAbilityOrderId,
                GetAbilityLevel(caster)
            );
        }
    }
}