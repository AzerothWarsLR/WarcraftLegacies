using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>The unit's attacks also strike the enemy directly behind its target.</summary>
public sealed class PikeReach : UnitTrait, IAppliesEffectOnDamage
{
  public required int AbilityTypeId { get; init; }
  public required LeveledAbilityField<float> DamageFraction { get; init; }
  public required float Reach { get; init; }
  public required float SearchRadius { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var target = @event.Unit;
    var level = attacker.GetAbilityLevel(AbilityTypeId);
    if (!@event.IsAttack || level == 0)
    {
      return;
    }

    var angle = MathEx.GetAngleBetweenPoints(attacker.X, attacker.Y, target.X, target.Y);
    var x = MathEx.GetPolarOffsetX(target.X, Reach, angle);
    var y = MathEx.GetPolarOffsetY(target.Y, Reach, angle);
    unit? behind = null;
    var closest = SearchRadius;
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(x, y, SearchRadius))
    {
      if (nearby == target || nearby.UnitType == DummyCasterManager.UnitTypeId ||
          !CastFilters.IsTargetEnemyAliveAndGroundUnits(attacker, nearby))
      {
        continue;
      }

      var distance = MathEx.GetDistanceBetweenPoints(new Point(x, y), new Point(nearby.X, nearby.Y));
      if (distance <= closest)
      {
        closest = distance;
        behind = nearby;
      }
    }

    if (behind != null)
    {
      behind.Damage(attacker, @event.Damage * DamageFraction.GetValue(level), attacktype.Hero);
    }
  }
}
