using WCSharp.Buffs;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Buffs
{
  /// <summary>
  /// The unit becomes a Spirit of Vengeance when this is applied, heaiing for an amount and gaining bonus damage.
  /// If the unit attacks some number of times before the buff expires, it revives.
  /// Otherwise, it dies.
  /// </summary>
  public sealed class VengeanceBuff : PassiveBuff
  {
    public VengeanceBuff(unit caster, unit target) : base(caster, target)
    {
    }

    public float Heal { private get; init; }
    public int BonusDamage { private get; init; }
    public string? ReviveEffect { private get; set; }
    public int HitsReviveThreshold { private get; set; }
    public int AlternateFormId { private get; set; }

    /// <summary>
    ///   The unit type ID of the unit before it was transformed.
    /// </summary>
    private int OriginalFormId { get; set; }

    /// <summary>
    ///   How many times this unit has struck any other unit since gaining Vengeance.
    /// </summary>
    private int HitsDone { get; set; }

    private void OnInflictsDamage()
    {
      if (BlzGetEventIsAttack() && Caster == GetTriggerUnit())
      {
        HitsDone++;
        if (HitsDone >= HitsReviveThreshold) Dispose();
      }
    }

    public override void OnApply()
    {
      OriginalFormId = GetUnitTypeId(Target);
      BlzSetUnitSkin(Target, AlternateFormId);
      DestroyEffect(AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target)));
      SetUnitState(Target, UNIT_STATE_LIFE, Heal);
      BlzSetUnitBaseDamage(Target, BlzGetUnitBaseDamage(Target, 0) + BonusDamage, 0);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, OnInflictsDamage, OriginalFormId);
    }

    public override void OnDispose()
    {
      BlzSetUnitBaseDamage(Target, BlzGetUnitBaseDamage(Target, 0) - BonusDamage, 0);
      BlzSetUnitSkin(Caster, OriginalFormId);
      PlayerUnitEvents.Unregister(PlayerUnitEvent.UnitTypeDamages, OnInflictsDamage);
      
      if (HitsDone >= HitsReviveThreshold)
        DestroyEffect(AddSpecialEffect(ReviveEffect, GetUnitX(Caster), GetUnitY(Caster)));
      else
        KillUnit(Caster);
    }
  }
}