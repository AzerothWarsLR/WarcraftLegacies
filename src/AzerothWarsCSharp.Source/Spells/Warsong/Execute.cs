using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Spells.Warsong
{
  /// <summary>
  /// When a Ravager reduces an enemy units hit points such that it ends up with less than 500% of the Ravager's damage, it dies instantly.
  /// </summary>
  public static class Execute
  {
    private const string EFFECT = "Objects\\Spawnmodels\\Human\\HumanLargeDeathExplode\\HumanLargeDeathExplode.mdl";
    private const int DAMAGE_MULT = 5;
    
    private static void OnDamage()
    {
      unit triggerUnit = GetTriggerUnit();
      if (BlzGetEventIsAttack() && GetUnitState(triggerUnit, UNIT_STATE_LIFE) <
        GetEventDamage() + GeneralHelpers.GetUnitAverageDamage(GetEventDamageSource(), 0) * DAMAGE_MULT)
      {
        BlzSetEventDamage(GetUnitState(triggerUnit, UNIT_STATE_LIFE) + 1);
        DestroyEffect(AddSpecialEffectTarget(EFFECT, triggerUnit, "origin"));
      }
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, OnDamage, FourCC("o021"));
    }
  }
}