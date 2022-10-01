using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;
using AzerothWarsCSharp.MacroTools.Libraries;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class StormEarthandFire : Spell
  {
    private int ABIL_ID { get; init; } = FourCC("A0HM");

    private int UNIT_TYPE_1 { get; init; } = FourCC("npn4");
    private int UNIT_TYPE_2 { get; init; } = FourCC("npn5");
    private int UNIT_TYPE_3 { get; init; } = FourCC("npn6");
    private float DURATION { get; init; } = 60.0F;    //Summoned unit duration

    private string EFFECT { get; init; } = "war3mapImported\\Soul Discharge Blue.mdx";
    private float EFFECT_SCALE { get; init; } = 1.1F;
    private string EFFECT_TARGET { get; init; } = "Abilities\\Spells\\Items\\AIil\\AIilTarget.mdl";
    private float EFFECT_SCALE_TARGET { get; init; } = 1.0F;

    private float HEALTH_BONUS_BASE { get; init; } = -0.15F;   //These refer to the % extra amount of that stat a Simulacrum gets
    private float HEALTH_BONUS_LEVEL { get; init; } = 0.15F;     //The level ones are for each additional hero level, including level 1
    private float DAMAGE_BONUS_BASE { get; init; } = -0.15F;
    private float DAMAGE_BONUS_LEVEL { get; init; } = 0.15F;
    public StormEarthandFire(int id) : base(id)
    {
    }

    public unit SummonPanda(War3Api.Common.player player, int UnitType, float x, float y, float facing, float damageBonus, float hitpointBonus, float durationunit)
    {
        unit newUnit = CreateUnit(player, UnitType, x, y, facing);
        effect tempEffect;
        UnitAddType(newUnit, UNIT_TYPE_SUMMONED);
        UnitApplyTimedLife(newUnit, 0, DURATION);
        UnitExtensions.ScaleBaseDamage(newUnit, 1 + damageBonus, 0);
        UnitExtensions.ScaleMaxHitpoints(newUnit, 1 + hitpointBonus);
        tempEffect = AddSpecialEffect(EFFECT_TARGET, GetUnitX(newUnit), GetUnitY(newUnit));
        BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_TARGET);
        DestroyEffect(tempEffect);
        return newUnit;
    }
    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      var triggerPlayer = GetOwningPlayer(caster);
      var level = GetUnitAbilityLevel(caster, ABIL_ID);
      var x = MathEx.GetPolarOffsetX(GetUnitX(caster), 150, GetUnitFacing(caster));
      var y = MathEx.GetPolarOffsetY(GetUnitY(caster), 150, GetUnitFacing(caster));
      var damageBonus = DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL * level;
      var hitpointBonus = HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL * level;
      SummonPanda(triggerPlayer, UNIT_TYPE_1, x, y, GetUnitFacing(caster), damageBonus, hitpointBonus, DURATION);
      SummonPanda(triggerPlayer, UNIT_TYPE_2, x, y, GetUnitFacing(caster), damageBonus, hitpointBonus, DURATION);
      SummonPanda(triggerPlayer, UNIT_TYPE_3, x, y, GetUnitFacing(caster), damageBonus, hitpointBonus, DURATION);
    }
  }
}