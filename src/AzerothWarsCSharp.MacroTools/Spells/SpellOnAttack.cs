using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public class SpellOnAttack : Spell
  {
    public int DummyAbilityId { get; init; }
    public string DummyOrderString { get; init; }
    public float ProcChance { get; init; }
    
    public SpellOnAttack(int id) : base(id)
    {
    }

    private void DoSpellOnTarget(unit caster, unit target)
    {
      DummyCast.CastOnUnit(caster, DummyAbilityId, DummyOrderString, GetAbilityLevel(caster), GetTriggerUnit());
    }
    
    public void OnDealsDamage(unit caster, unit target)
    {
      if (GetRandomReal(0, 1) < ProcChance)
      {
        DoSpellOnTarget(caster, target);
      }
    }
    
    public override void OnCast(unit caster, widget target, float targetX, float targetY)
    {
      throw new System.NotImplementedException();
    }
  }
}