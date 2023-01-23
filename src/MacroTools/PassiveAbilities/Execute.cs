using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  public sealed class Execute : PassiveAbility, IAppliesEffectOnDamage
  {
    private const string Effect = "Objects\\Spawnmodels\\Human\\HumanLargeDeathExplode\\HumanLargeDeathExplode.mdl";
    private const int DamageMult = 5;

    public Execute(int unitTypeId) : base(unitTypeId)
    {
    }

    public void OnDealsDamage()
    {
      var triggerUnit = GetTriggerUnit();
      if (!BlzGetEventIsAttack() 
          || !(GetUnitState(triggerUnit, UNIT_STATE_LIFE) < GetEventDamage() + GetEventDamageSource().GetAverageDamage(0) * DamageMult))
        return;
      BlzSetEventDamage(GetUnitState(triggerUnit, UNIT_STATE_LIFE) + 1);
      BlzSetEventDamageType(DAMAGE_TYPE_UNIVERSAL);
      DestroyEffect(AddSpecialEffectTarget(Effect, triggerUnit, "origin"));
    }
  }
}