using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Utils;
using WCSharp.Effects;

namespace MacroTools.PassiveAbilities;

/// <summary>
/// When the unit dies, it reanimates nearby friendly units.
/// </summary>
public sealed class PersistentSoul : PassiveAbility, IEffectOnDeath
{
  private readonly int _abilityTypeId;

  /// <summary>
  /// Initializes a new instance of the <see cref="PersistentSoul"/> class.
  /// </summary>
  /// <param name="unitTypeId"><inheritdoc /></param>
  /// <param name="abilityTypeId">The ability ID that determines the effect's level.</param>
  public PersistentSoul(int unitTypeId, int abilityTypeId) : base(unitTypeId) => _abilityTypeId = abilityTypeId;

  /// <summary>
  /// How many units this ability reanimates per level.
  /// </summary>
  public int ReanimationCountLevel { get; init; }

  /// <summary>
  /// How long the reanimated units should last.
  /// </summary>
  public float Duration { get; init; }

  /// <summary>
  /// Used to determine the reanimation buff's name.
  /// </summary>
  public int BuffId { get; init; }

  /// <summary>
  /// How far away corpses can be to be a candidate for reanimation.
  /// </summary>
  public float Radius { get; init; }

  /// <inheritdoc/>
  public void OnDeath()
  {
    var caster = @event.Unit;

    foreach (var unit in GlobalGroup.EnumUnitsInRange(caster.GetPosition(), Radius)
               .Where(x => IsUnitReanimationCandidate(caster, x))
               .OrderByDescending(x => x.GetLevel())
               .ThenBy(x => MathEx.GetDistanceBetweenPoints(caster.GetPosition(), x.GetPosition()))
               .Take(ReanimationCountLevel * caster.GetAbilityLevel(_abilityTypeId)))
    {
      Reanimate(caster.Owner, unit);
    }
  }

  private static bool IsUnitReanimationCandidate(unit caster, unit target) =>
    !target.Alive
    && !target.IsUnitType(unittype.Mechanical)
    && !target.IsUnitType(unittype.Structure)
    && !target.IsUnitType(unittype.Hero)
    && !target.IsUnitType(unittype.Summoned)
    && !target.IsUnitType(unittype.Flying)
    && !target.IsUnitType(unittype.Resistant)
    && !target.IsIllusion
    && caster != target;

  private void Reanimate(player castingPlayer, unit whichUnit)
  {
    var whichUnitPosition = whichUnit.GetPosition();

    EffectSystem.Add(effect.Create(@"Abilities\Spells\Undead\AnimateDead\AnimateDeadTarget.mdl", whichUnit.X, whichUnit.Y));

    var reanimatedUnit = unit.Create(castingPlayer, whichUnit.UnitType, whichUnitPosition.X, whichUnitPosition.Y, whichUnit.Facing);
    reanimatedUnit.RemoveAllAbilities(new List<int> { 1096905835, 1097690998, 1112498531 });
    reanimatedUnit.SetTimedLife(Duration, BuffId);
    reanimatedUnit.SetVertexColor(200, 50, 50, 255);
    reanimatedUnit.SetExploded(true);
    reanimatedUnit.AddType(unittype.Undead);
    reanimatedUnit.AddType(unittype.Summoned);

    whichUnit.Dispose();

    reanimatedUnit.SetPosition(whichUnitPosition);
  }
}
