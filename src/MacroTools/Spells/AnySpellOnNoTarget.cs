using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace MacroTools.Spells;

public sealed class AnySpellNoTarget : Spell
{
  public int DummyAbilityId { get; init; }
  public int DummyAbilityOrderId { get; init; }

  public AnySpellNoTarget(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    DummyCaster.Cast(
        caster,
        DummyAbilityId,
        DummyAbilityOrderId,
        GetAbilityLevel(caster)
    );
  }
}
