using System.Linq;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class Sunstrike : Spell
{
  public required float Damage { get; init; }

  public required float Healing { get; init; }

  public required float HealRadius { get; init; }

  public string StrikeEffect { get; init; } = @"war3mapImported\HolyLightBeam.mdx";

  public float StrikeEffectDuration { get; init; } = 1.5f;

  public string HealEffect { get; init; } = @"Abilities\Spells\Human\HolyBolt\HolyBoltSpecialArt.mdl";

  public Sunstrike(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    EffectSystem.Add(effect.Create(StrikeEffect, target.X, target.Y), StrikeEffectDuration);
    caster.DealDamage(target, Damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);

    var alliesToHeal = GlobalGroup
      .EnumUnitsInRange(target.X, target.Y, HealRadius)
      .Where(x => IsValidHealTarget(caster, x));

    foreach (var ally in alliesToHeal)
    {
      ally.Life += Healing;
      effect.Create(HealEffect, ally, "origin").Dispose();
    }
  }

  private static bool IsValidHealTarget(unit caster, unit target) =>
    target.IsAllyTo(caster.Owner) &&
    target.Alive &&
    !target.IsUnitType(unittype.Structure) &&
    !target.IsUnitType(unittype.Mechanical);
}
