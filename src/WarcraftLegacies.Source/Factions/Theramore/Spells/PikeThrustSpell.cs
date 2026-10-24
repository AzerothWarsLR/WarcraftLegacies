using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>Thrusts a pike forward, damaging enemies in a line and pushing them back, stunning any that slam into something.</summary>
public sealed class PikeThrustSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float Length { get; init; }
  public required float Width { get; init; }
  public required float PushDistance { get; init; }
  public required float PushDuration { get; init; }
  public required int StunAbilityId { get; init; }
  public required string HitEffectPath { get; init; }

  public PikeThrustSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, targetPoint.X, targetPoint.Y);
    var damage = Damage.GetValue(GetAbilityLevel(caster));
    foreach (var victim in GetUnitsInLine(caster, angle))
    {
      effect.Create(HitEffectPath, victim, "chest").Dispose();
      caster.DealDamage(victim, damage, false, false, attacktype.Hero, damagetype.Normal, weapontype.WhoKnows);
      if (!victim.Alive)
      {
        continue;
      }

      Knockback.Push(victim, angle, PushDistance, PushDuration, blocked =>
        DummyCasterManager.GetGlobalDummyCaster()
          .CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, 1, blocked, DummyCastOriginType.Target));
    }
  }

  private List<unit> GetUnitsInLine(unit caster, float angle)
  {
    var victims = new List<unit>();
    for (var distance = Width / 2; distance <= Length; distance += Width / 2)
    {
      var x = MathEx.GetPolarOffsetX(caster.X, distance, angle);
      var y = MathEx.GetPolarOffsetY(caster.Y, distance, angle);
      foreach (var nearby in GlobalGroup.EnumUnitsInRange(x, y, Width / 2))
      {
        if (!victims.Contains(nearby) && nearby.UnitType != DummyCasterManager.UnitTypeId &&
            CastFilters.IsTargetEnemyAliveAndGroundUnits(caster, nearby))
        {
          victims.Add(nearby);
        }
      }
    }

    return victims;
  }
}
