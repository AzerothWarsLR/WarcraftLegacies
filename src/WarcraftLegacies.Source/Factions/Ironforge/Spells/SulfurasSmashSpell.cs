using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Hurls Sulfuras at an area, damaging enemies and stunning those at the centre for double damage.</summary>
public sealed class SulfurasSmashSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float Radius { get; init; }
  public required float CentreRadius { get; init; }
  public required float LandingTime { get; init; }
  public required float LaunchHeight { get; init; }
  public required int StunAbilityId { get; init; }
  public required string HammerPath { get; init; }
  public required float HammerScale { get; init; }
  public required string ImpactPath { get; init; }
  public required float ImpactScale { get; init; }
  public required float ImpactDuration { get; init; }

  public SulfurasSmashSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = caster.GetAbilityLevel(Id);
    var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, targetPoint.X, targetPoint.Y);
    var startX = MathEx.GetPolarOffsetX(targetPoint.X, -LaunchHeight / 2, angle);
    var startY = MathEx.GetPolarOffsetY(targetPoint.Y, -LaunchHeight / 2, angle);
    MissileSystem.Add(new SulfurasMissile(caster.Owner, startX, startY, targetPoint.X, targetPoint.Y)
    {
      Caster = caster,
      Spell = this,
      Level = level,
      EffectString = HammerPath,
      EffectScale = HammerScale,
      Speed = LaunchHeight / 2 / LandingTime,
      CasterLaunchZ = LaunchHeight,
      Active = true
    });
  }

  /// <summary>Damages enemies around the point where Sulfuras lands.</summary>
  public void Smash(unit caster, int level, float x, float y)
  {
    var damage = Damage.GetValue(level);
    var impact = effect.Create(ImpactPath, x, y);
    impact.Scale = ImpactScale;
    EffectSystem.Add(impact, ImpactDuration);
    var centreSquared = CentreRadius * CentreRadius;
    foreach (var victim in GlobalGroup.EnumUnitsInRange(x, y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, victim) || victim.UnitType == DummyCasterManager.UnitTypeId ||
          victim.IsUnitType(unittype.Structure))
      {
        continue;
      }

      var dx = victim.X - x;
      var dy = victim.Y - y;
      var atCentre = dx * dx + dy * dy <= centreSquared;
      caster.DealDamage(victim, atCentre ? damage * 2 : damage, false, false, attacktype.Normal, damagetype.Magic,
        weapontype.WhoKnows);
      if (atCentre && victim.Alive)
      {
        DummyCasterManager.GetGlobalDummyCaster()
          .CastUnit(caster, StunAbilityId, ORDER_THUNDERBOLT, 1, victim, DummyCastOriginType.Target);
      }
    }
  }
}

/// <summary>Sulfuras falling towards the target of <see cref="SulfurasSmashSpell"/>.</summary>
public sealed class SulfurasMissile : BasicMissile
{
  public required SulfurasSmashSpell Spell { get; init; }
  public required int Level { get; init; }

  public SulfurasMissile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
    base(castingPlayer, casterX, casterY, targetX, targetY)
  {
  }

  /// <inheritdoc />
  public override void OnImpact() => Spell.Smash(Caster, Level, TargetX, TargetY);
}
