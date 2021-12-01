using System;
using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries.SpellSystem
{
  public static class SpellSystem
  {
    private static readonly Dictionary<int, Spell> SpellsByAbilityId = new();
    private static readonly UnitSpellRegister UnitSpellRegister = new ();

    public static bool SpellWithAbilityIdExists(int abilityId)
    {
      return SpellsByAbilityId.ContainsKey(abilityId);
    }
    
    public static Spell GetSpellByAbilityId(int abilityId)
    {
      if (!SpellsByAbilityId.ContainsKey(abilityId))
      {
        throw new Exception($"There is no Spell with abilityId {abilityId}.");
      }
      return SpellsByAbilityId[abilityId];
    }
    
    /// <summary>
    /// Removes a spell from a unit. This is distinct from Blizzard's UnitAddAbility in that it also records that the
    /// unit no longer has that spell, thereby de-registering it from custom triggers like OnDamage and OnAttack.
    /// </summary>
    public static void UnitRemoveSpell(unit unit, int abilityId)
    {
      UnitRemoveAbility(unit, abilityId);
      if (SpellWithAbilityIdExists(abilityId))
      {
        UnitSpellRegister.DeregisterSpell(unit, abilityId);
      }
    }
    
    /// <summary>
    /// Adds a spell to a unit. This is distinct from Blizzard's UnitAddAbility in that it also records that the unit
    /// has that spell, which is necessary for custom spells with custom triggers like OnDamage and OnAttack.
    /// </summary>
    public static void UnitAddSpell(unit unit, int abilityId)
    {
      UnitAddAbility(unit, abilityId);
      if (SpellWithAbilityIdExists(abilityId))
      {
        UnitSpellRegister.RegisterSpell(unit, abilityId);
      }
    }
    
    private static void OnCast()
    {
      SpellsByAbilityId[GetSpellAbilityId()].OnCast(GetTriggerUnit(), GetSpellTargetUnit(), GetSpellTargetX(), GetSpellTargetY());
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