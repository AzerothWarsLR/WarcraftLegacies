using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace MacroTools.Spells;

public sealed class GoldOnCast : Spell
{

  public int GoldToGrant { get; init; }
  public GoldOnCast(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    caster.Owner.AdjustPlayerState(playerstate.ResourceGold, GoldToGrant);
  }
}
