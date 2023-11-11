using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// When the unit dies, it reanimates nearby friendly units.
  /// </summary>
  public sealed class PersistentSoul : PassiveAbility
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
    public override void OnDeath()
    {
      var caster = GetTriggerUnit();

      foreach (var unit in CreateGroup().EnumUnitsInRange(caster.GetPosition(), Radius)
                 .EmptyToList()
                 .Where(x => IsUnitReanimationCandidate(caster, x))
                 .OrderByDescending(x => x.GetLevel())
                 .Take(ReanimationCountLevel * GetUnitAbilityLevel(caster, _abilityTypeId)))
      {
        Reanimate(caster.OwningPlayer(), unit);
      }
    }

    private static bool IsUnitReanimationCandidate(unit caster, unit target) =>
      !UnitAlive(target)
      && !IsUnitType(target, UNIT_TYPE_MECHANICAL)
      && !IsUnitType(target, UNIT_TYPE_STRUCTURE)
      && !IsUnitType(target, UNIT_TYPE_HERO)
      && !IsUnitType(target, UNIT_TYPE_SUMMONED)
      && !IsUnitType(target, UNIT_TYPE_FLYING)
      && !IsUnitType(target, UNIT_TYPE_RESISTANT)
      && !IsUnitIllusion(target)
      && caster != target;

    private void Reanimate(player castingPlayer, unit whichUnit)
    {
      var whichUnitPosition = whichUnit.GetPosition();

      AddSpecialEffect(@"Abilities\Spells\Undead\AnimateDead\AnimateDeadTarget.mdl", GetUnitX(whichUnit),
          GetUnitY(whichUnit))
        .SetLifespan();

      var reanimatedUnit = CreateUnit(castingPlayer, whichUnit.GetTypeId(), whichUnitPosition.X,
          whichUnitPosition.Y, whichUnit.GetFacing())
        .RemoveAllAbilities(new List<int>{1096905835,1097690998,1112498531})
        .SetTimedLife(Duration, BuffId)
        .SetColor(200, 50, 50, 255)
        .SetExplodeOnDeath(true)
        .AddType(UNIT_TYPE_UNDEAD)
        .AddType(UNIT_TYPE_SUMMONED);
      
      whichUnit.Remove();
      
      reanimatedUnit.SetPosition(whichUnitPosition);
    }
  }
}