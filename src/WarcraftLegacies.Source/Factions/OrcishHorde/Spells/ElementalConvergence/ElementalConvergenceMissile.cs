using System.Linq;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Spells.ElementalConvergence;

/// <summary>
/// One of the three elemental orbs launched by <see cref="ElementalConvergenceChannel"/>. Travels toward the
/// target point while its lateral offset from the straight-line path shrinks to zero, giving the visual of the
/// three orbs converging into one. Only the first orb to arrive actually triggers the explosion.
/// </summary>
public sealed class ElementalConvergenceMissile : BasicMissile
{
  private const float ImpactRadius = 60f;

  public int EffectRed { get; init; }

  public int EffectGreen { get; init; }

  public int EffectBlue { get; init; }

  public float Damage { get; init; }

  public float Radius { get; init; }

  public int StunAbilityId { get; init; }

  public int Level { get; init; }

  private readonly float _lateralOffset;
  private readonly float _perpX;
  private readonly float _perpY;
  private readonly ElementalConvergenceImpactState _impactState;
  private float _previousOffset;
  private bool _colored;

  public ElementalConvergenceMissile(unit caster, float targetX, float targetY, float lateralOffset,
    ElementalConvergenceImpactState impactState) : base(caster, targetX, targetY)
  {
    _lateralOffset = lateralOffset;
    _previousOffset = lateralOffset;
    _impactState = impactState;

    var directionX = targetX - caster.X;
    var directionY = targetY - caster.Y;
    var length = SquareRoot(directionX * directionX + directionY * directionY);
    if (length <= 0)
    {
      length = 1;
    }

    _perpX = -directionY / length;
    _perpY = directionX / length;

    CollisionRadius = ImpactRadius;
  }

  public override void OnPeriodic()
  {
    if (!_colored && Effect != null)
    {
      Effect.SetColor(EffectRed, EffectGreen, EffectBlue);
      Effect.PlayAnimation(animtype.Stand);
      _colored = true;
    }

    var totalDistanceX = TargetX - CasterX;
    var totalDistanceY = TargetY - CasterY;
    var totalDistance = SquareRoot(totalDistanceX * totalDistanceX + totalDistanceY * totalDistanceY);
    var travelledX = MissileX - CasterX;
    var travelledY = MissileY - CasterY;
    var travelled = SquareRoot(travelledX * travelledX + travelledY * travelledY);
    var progress = totalDistance > 0 ? travelled / totalDistance : 1f;
    if (progress > 1f)
    {
      progress = 1f;
    }

    var offset = _lateralOffset * (1f - progress);
    var deltaOffset = offset - _previousOffset;
    MissileX += _perpX * deltaOffset;
    MissileY += _perpY * deltaOffset;
    _previousOffset = offset;
  }

  public override void OnImpact()
  {
    if (_impactState.Exploded)
    {
      return;
    }

    _impactState.Exploded = true;

    var x = MissileX;
    var y = MissileY;

    var explosionEffect = effect.Create(@"Abilities\Spells\Other\Incinerate\FireLordDeathExplode.mdl", x, y);
    EffectSystem.Add(explosionEffect);

    var dummyCaster = DummyCasterManager.GetGlobalDummyCaster();
    foreach (var target in GlobalGroup.EnumUnitsInRange(x, y, Radius)
               .Where(u => CastFilters.IsTargetEnemyAndAlive(Caster, u)))
    {
      Caster.DealDamage(target, Damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      dummyCaster.CastUnit(Caster, StunAbilityId, ORDER_THUNDERBOLT, Level, target, DummyCastOriginType.Target);
    }
  }
}
