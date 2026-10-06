using MacroTools.DummyCasters;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class ChallengingTaunt : Spell
{
  public required int ArmorAbilityId { get; init; }

  public ChallengingTaunt(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    DummyCasterManager.GetGlobalDummyCaster()
      .CastUnit(caster, ArmorAbilityId, ORDER_INNER_FIRE, 1, caster, DummyCastOriginType.Target);
  }
}
