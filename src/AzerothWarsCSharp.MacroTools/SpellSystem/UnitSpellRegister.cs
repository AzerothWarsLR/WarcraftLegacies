using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.SpellSystem
{
  /// <summary>
  /// A register of which units have which Spells.
  /// </summary>
  public class UnitSpellRegister
  {
    private readonly Dictionary<War3Api.Common.unit, HashSet<Spell>> _allUnitSpells = new ();
    
    /// <summary>
    /// Checks whether or not a particular unit has a particular Spell according to this register.
    /// </summary>
    public bool UnitHasSpell(unit unit, int abilityId)
    {
      return _allUnitSpells.ContainsKey(unit) && _allUnitSpells[unit].Contains(SpellSystem.GetSpellByAbilityId(abilityId));
    }
    
    /// <summary>
    /// Registers that a unit has a particular Spell.
    /// </summary>
    public void RegisterSpell(unit unit, int abilityId)
    {
      if (!_allUnitSpells.ContainsKey(unit))
      {
        _allUnitSpells.Add(unit, new HashSet<Spell>());
      }
      _allUnitSpells[unit].Add(SpellSystem.GetSpellByAbilityId(abilityId));
    }

    /// <summary>
    /// Registers that a unit no longer has a particular Spell.
    /// </summary>
    public void DeregisterSpell(unit unit, int abilityId)
    {
      var spell = SpellSystem.GetSpellByAbilityId(abilityId);
      if (!_allUnitSpells.ContainsKey(unit) || _allUnitSpells[unit].Contains(spell))
      {
        return;
      }
      _allUnitSpells[unit].Remove(spell);
    }
  }
}