using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace MacroTools.Spells
{
  public sealed class GrantMana : Spell
  {
    public float ManaToGrant { get; init; }
    
    public GrantMana(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      SetUnitState(target, UNIT_STATE_MANA, GetUnitState(target, UNIT_STATE_MANA) + ManaToGrant);
    }
  }
}