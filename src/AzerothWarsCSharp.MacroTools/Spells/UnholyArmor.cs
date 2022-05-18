using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class UnholyArmor : Spell
  {
    public float PercentageDamage { get; init; }
    
    public UnholyArmor(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      target.Damage(caster, GetUnitState(target, UNIT_STATE_LIFE) * PercentageDamage);
    }
  }
}