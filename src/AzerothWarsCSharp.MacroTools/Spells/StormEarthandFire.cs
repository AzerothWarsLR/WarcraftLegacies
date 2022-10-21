using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;
using AzerothWarsCSharp.MacroTools.Libraries;

namespace AzerothWarsCSharp.MacroTools.Spells
{
    public sealed class StormEarthandFire : Spell
    {
        public int UnitType1 { get; init; } = FourCC("npn4");
        public int UnitType2 { get; init; } = FourCC("npn5");
        public int UnitType3 { get; init; } = FourCC("npn6");
        /// <summary>
        /// How long the summoned units last.
        /// </summary>
        public float Duration { get; init; } = 60.0F;
        public string EffectTarget { get; init; } = "Abilities\\Spells\\Items\\AIil\\AIilTarget.mdl";
        public float EffectScaleTarget { get; init; } = 1.0F;

        public float HealthBonusBase { get; init; } = -0.15F;
        public float HealthBonusLevel { get; init; } = 0.15F;     //The level ones are for each additional hero level, including level 1
        public float DamageBonusBase { get; init; } = -0.15F;
        public float DamageBonusLevel { get; init; } = 0.15F;

        public StormEarthandFire(int id) : base(id)
        {
        }

        public void SummonPanda(player player, int UnitType, float x, float y, float facing, float damageBonus, float hitpointBonus, float Durationunit)
        {
            unit newUnit = CreateUnit(player, UnitType, x, y, facing);
            effect tempEffect;
            UnitAddType(newUnit, UNIT_TYPE_SUMMONED);
            UnitApplyTimedLife(newUnit, 0, Duration);
            UnitExtensions.ScaleBaseDamage(newUnit, 1 + damageBonus, 0);
            UnitExtensions.ScaleMaxHitpoints(newUnit, 1 + hitpointBonus);
            tempEffect = AddSpecialEffect(EffectTarget, GetUnitX(newUnit), GetUnitY(newUnit));
            BlzSetSpecialEffectScale(tempEffect, EffectScaleTarget);
            DestroyEffect(tempEffect);
        }
        public override void OnCast(unit caster, unit target, float targetX, float targetY)
        {
            var triggerPlayer = GetOwningPlayer(caster);
            var level = GetUnitAbilityLevel(caster, Id);
            var x = MathEx.GetPolarOffsetX(GetUnitX(caster), 150, GetUnitFacing(caster));
            var y = MathEx.GetPolarOffsetY(GetUnitY(caster), 150, GetUnitFacing(caster));
            var damageBonus = DamageBonusBase + DamageBonusLevel * level;
            var hitpointBonus = HealthBonusBase + HealthBonusLevel * level;
            SummonPanda(triggerPlayer, UnitType1, x, y, GetUnitFacing(caster), damageBonus, hitpointBonus, Duration);
            SummonPanda(triggerPlayer, UnitType2, x, y, GetUnitFacing(caster), damageBonus, hitpointBonus, Duration);
            SummonPanda(triggerPlayer, UnitType3, x, y, GetUnitFacing(caster), damageBonus, hitpointBonus, Duration);
        }
    }
}