using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  public sealed class Execute : PassiveAbility
  {
    private const string EFFECT = "Objects\\Spawnmodels\\Human\\HumanLargeDeathExplode\\HumanLargeDeathExplode.mdl";
    private const int DAMAGE_MULT = 5;

    public Execute(int unitTypeId) : base(unitTypeId)
    {
    }

    public override void OnDealsDamage()
    {
      unit triggerUnit = GetTriggerUnit();
      if (BlzGetEventIsAttack() && GetUnitState(triggerUnit, UNIT_STATE_LIFE) <
        GetEventDamage() + GetEventDamageSource().GetAverageDamage(0) * DAMAGE_MULT)
      {
        BlzSetEventDamage(GetUnitState(triggerUnit, UNIT_STATE_LIFE) + 1);
        DestroyEffect(AddSpecialEffectTarget(EFFECT, triggerUnit, "origin"));
      }
    }
  }
}