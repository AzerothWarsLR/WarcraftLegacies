using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.UnitEffects
{
  public sealed class Execute : UnitEffect
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
        GetEventDamage() + GeneralHelpers.GetUnitAverageDamage(GetEventDamageSource(), 0) * DAMAGE_MULT)
      {
        BlzSetEventDamage(GetUnitState(triggerUnit, UNIT_STATE_LIFE) + 1);
        DestroyEffect(AddSpecialEffectTarget(EFFECT, triggerUnit, "origin"));
      }
    }
  }
}