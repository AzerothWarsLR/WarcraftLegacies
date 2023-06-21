using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells
{
  public sealed class AnySpellOnTarget : Spell
  {
    public int DummyAbilityId { get; init; }
    public string DummyAbilityOrderString { get; init; }
    public int Duration { get; init; }

    public AnySpellOnTarget(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      DummyCast.DummyCastNoTargetOnUnit(caster, DummyAbilityId, DummyAbilityOrderString, GetAbilityLevel(caster), target);
    }
  }
}