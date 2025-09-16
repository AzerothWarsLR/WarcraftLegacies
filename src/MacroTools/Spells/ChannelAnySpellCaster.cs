using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace MacroTools.Spells;

public sealed class ChannelAnySpellCaster : Spell
{
  public int DummyAbilityId { get; init; }
  public required int DummyAbilityOrderId { get; init; }
  public int Duration { get; init; }

  public ChannelAnySpellCaster(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    DummyCaster.Cast(caster, DummyAbilityId, DummyAbilityOrderId, GetAbilityLevel(caster), Duration);
  }
}
