using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>Shoots a target, stunning it, and the shot carries on into the enemies behind it for part of the damage.</summary>
public sealed class PistolShotSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float PassThroughFraction { get; init; }
  public required float PassThroughLength { get; init; }
  public required float PassThroughWidth { get; init; }
  public required int StunAbilityId { get; init; }
  public required string HitEffectPath { get; init; }

  public PistolShotSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var damage = Damage.GetValue(GetAbilityLevel(caster));
    var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, target.X, target.Y);
    effect.Create(HitEffectPath, target, "chest").Dispose();
    caster.DealDamage(target, damage, false, false, attacktype.Hero, damagetype.Normal, weapontype.WhoKnows);
    if (target.Alive)
    {
      DummyCasterManager.GetGlobalDummyCaster()
        .CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, 1, target, DummyCastOriginType.Target);
    }

    foreach (var victim in GetUnitsBehind(caster, target, angle))
    {
      effect.Create(HitEffectPath, victim, "chest").Dispose();
      caster.DealDamage(victim, damage * PassThroughFraction, false, false, attacktype.Hero, damagetype.Normal,
        weapontype.WhoKnows);
    }
  }

  private List<unit> GetUnitsBehind(unit caster, unit target, float angle)
  {
    var victims = new List<unit>();
    for (var distance = PassThroughWidth / 2; distance <= PassThroughLength; distance += PassThroughWidth / 2)
    {
      var x = MathEx.GetPolarOffsetX(target.X, distance, angle);
      var y = MathEx.GetPolarOffsetY(target.Y, distance, angle);
      foreach (var nearby in GlobalGroup.EnumUnitsInRange(x, y, PassThroughWidth / 2))
      {
        if (nearby != target && !victims.Contains(nearby) && nearby.UnitType != DummyCasterManager.UnitTypeId &&
            CastFilters.IsTargetEnemyAndAliveUnits(caster, nearby))
        {
          victims.Add(nearby);
        }
      }
    }

    return victims;
  }
}
