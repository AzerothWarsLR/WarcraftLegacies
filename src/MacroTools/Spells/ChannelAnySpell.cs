using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace MacroTools.Spells;

public sealed class ChannelAnySpell : Spell
{
  public int DummyAbilityId { get; init; }
  public int DummyAbilityOrderId { get; init; }
  public int Duration { get; init; }

  public ChannelAnySpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    DummyCasterManager.GetLongLivedDummyCaster().ChannelOnPoint(caster, DummyAbilityId, DummyAbilityOrderId,
      GetAbilityLevel(caster), targetPoint, Duration);
  }
}
