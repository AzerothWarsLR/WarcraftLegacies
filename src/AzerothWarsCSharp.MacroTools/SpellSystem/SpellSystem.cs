using System;
using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.SpellSystem
{
  public static class SpellSystem
  {
    private static readonly Dictionary<int, Spell> SpellsByAbilityId = new();

    public static Spell GetSpellByAbilityId(int abilityId)
    {
      if (!SpellsByAbilityId.ContainsKey(abilityId))
      {
        throw new Exception($"There is no Spell with abilityId {abilityId}.");
      }
      return SpellsByAbilityId[abilityId];
    }

    private static void OnCast()
    {
      SpellsByAbilityId[GetSpellAbilityId()].OnCast(GetTriggerUnit(), GetSpellTargetUnit(), GetSpellTargetX(), GetSpellTargetY());
    }

    public static void Register(TakeDamageEffect takeDamageEffect)
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, takeDamageEffect.OnTakesDamage, takeDamageEffect.DamagedUnitTypeId);
    }
    
    /// <summary>
    /// Registers an <see cref="AttackEffect"/> to the <see cref="SpellSystem"/>.
    /// </summary>
    public static void Register(AttackEffect attackEffect)
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, attackEffect.OnDealsDamage, attackEffect.AttackerUnitTypeId);
    }
    
    /// <summary>
    /// Registers a spell to the SpellSystem.
    /// </summary>
    public static void Register(Spell spell)
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEffect, OnCast, spell.Id);
      SpellsByAbilityId.Add(spell.Id, spell);
    }
  }
}