using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class UnholyArmor : Spell
{
  public float PercentageDamage { get; init; }

  public UnholyArmor(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint) =>
    target.TakeDamage(caster, target.Life * PercentageDamage);
}
