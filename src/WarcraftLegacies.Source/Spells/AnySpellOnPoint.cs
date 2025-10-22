using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class AnySpellOnTarget : Spell
{
  public int DummyAbilityId { get; init; }
  public int DummyAbilityOrderId { get; init; }

  public AnySpellOnTarget(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    DummyCasterManager.GetGlobalDummyCaster().CastNoTargetOnUnit(caster, DummyAbilityId, DummyAbilityOrderId, GetAbilityLevel(caster), target);
  }
}
