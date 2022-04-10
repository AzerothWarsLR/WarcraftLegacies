using AzerothWarsCSharp.MacroTools.SpellSystem;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class Execute : AttackEffect
  {
    private const string EFFECT = "Objects\\Spawnmodels\\Human\\HumanLargeDeathExplode\\HumanLargeDeathExplode.mdl";
    private const int DAMAGE_MULT = 5;

    public override void OnDealsDamage()
    {
      unit triggerUnit = GetTriggerUnit();
      if (BlzGetEventIsAttack() && GetUnitState(triggerUnit, UNIT_STATE_LIFE) <
        GetEventDamage() + GeneralHelpers.GetUnitAverageDamage(GetEventDamageSource(), 0) * DAMAGE_MULT)
      {
        BlzSetEventDamage(GetUnitState(triggerUnit, UNIT_STATE_LIFE) + 1);
        DestroyEffect(AddSpecialEffectTarget(EFFECT, triggerUnit, "origin"));
      }
    }
    
    public Execute(int attackerUnitTypeId) : base(attackerUnitTypeId)
    {
    }
  }
}