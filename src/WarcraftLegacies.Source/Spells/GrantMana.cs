using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class GrantMana : Spell
{
  public float ManaToGrant { get; init; }

  public GrantMana(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    target.Mana += ManaToGrant;
  }
}
