using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sentinels.Spells;

public sealed class LightOfTheGoddessSpell : Spell
{
  public required float Healing { get; init; }

  public required float Damage { get; init; }

  public required string Effect { get; init; }

  public LightOfTheGoddessSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (target.IsAllyTo(caster.Owner))
    {
      target.Life += Healing;
    }
    else
    {
      target.TakeDamage(caster, Damage, false, false, attacktype.Magic, damagetype.Magic);
    }

    effect.Create(Effect, target, "origin").Dispose();
  }
}
