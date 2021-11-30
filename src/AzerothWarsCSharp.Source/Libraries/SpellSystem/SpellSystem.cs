using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries.SpellSystem
{
  public static class SpellSystem
  {
    private static readonly Dictionary<int, Spell> Spells = new();

    private static void OnCast()
    {
      Spells[GetSpellAbilityId()].OnCast(GetTriggerUnit());
    }
    
    /// <summary>
    /// Registers a spell to the SpellSystem.
    /// </summary>
    public static void Register(Spell spell)
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEffect, OnCast, spell.Id);
      Spells.Add(spell.Id, spell);
    }
  }
}