using MacroTools.Extensions;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Shared.UnitTraits;

public sealed class MultishotAttack
{
  public required int ExtraTargets { get; init; }
  public required float Radius { get; init; }
  public required string MissilePath { get; init; }
  public float MissileSpeed { get; init; } = 900;
  public float MissileArc { get; init; } = 0.3f;
  public float SplashRadius { get; init; } = 60;

  public void Register(int unitTypeId)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.Attacks, OnAttack, unitTypeId);
  }

  private void OnAttack()
  {
    var attacker = @event.Attacker;
    var mainTarget = @event.Unit;
    var damage = attacker.GetAverageDamage(0);
    var attackType = attacktype.Convert(attacker.AttackAttackType1);
    var thrown = 0;
    foreach (var target in GlobalGroup.EnumUnitsInRange(mainTarget.X, mainTarget.Y, Radius))
    {
      if (thrown >= ExtraTargets)
      {
        break;
      }

      if (target == mainTarget || !target.Alive || !target.IsEnemyTo(attacker.Owner) ||
          target.IsUnitType(unittype.Flying) || target.IsInvulnerable)
      {
        continue;
      }

      thrown++;
      MissileSystem.Add(new MultishotMissile(attacker, target)
      {
        Damage = damage,
        AttackType = attackType,
        SplashRadius = SplashRadius,
        EffectString = MissilePath,
        Speed = MissileSpeed,
        Arc = MissileArc
      });
    }
  }
}

public sealed class MultishotMissile : BasicMissile
{
  public required float Damage { get; init; }
  public required attacktype AttackType { get; init; }
  public required float SplashRadius { get; init; }

  public MultishotMissile(unit caster, unit target) : base(caster, target)
  {
  }

  public override void OnImpact()
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRange(MissileX, MissileY, SplashRadius))
    {
      if (unit.Alive && unit.IsEnemyTo(Caster.Owner) && !unit.IsUnitType(unittype.Flying))
      {
        Caster.DealDamage(unit, Damage, true, false, AttackType, damagetype.Normal, weapontype.WhoKnows);
      }
    }

    Active = false;
  }
}
