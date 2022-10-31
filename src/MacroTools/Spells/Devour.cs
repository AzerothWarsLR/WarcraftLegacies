using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells
{
  public sealed class Devour : Spell
  {
    public float PercentageOfMaxHealth { get; init; } = 0.5f;
    
    public Devour(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      SetUnitState(caster, UNIT_STATE_LIFE, GetUnitState(caster, UNIT_STATE_LIFE) + GetUnitState(caster, UNIT_STATE_MAX_LIFE)*PercentageOfMaxHealth);
    }
  }
}