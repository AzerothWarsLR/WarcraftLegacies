using MacroTools.Extensions;

namespace MacroTools.Spells;

public static class CastFilters
{
  public static bool IsTargetOrganicAndAlive(unit caster, unit target)
  {
    return !target.IsUnitType(unittype.Structure) && !target.IsUnitType(unittype.Ancient) &&
           !target.IsUnitType(unittype.Mechanical) && target.Alive;
  }

  public static bool IsTargetAllyAndAlive(unit caster, unit target)
  {
    var casterPlayer = caster.Owner;
    return (target.IsAllyTo(casterPlayer) || target.Owner == player.NeutralPassive) &&
           target.Alive && target.IsInvulnerable == false;
  }

  public static bool IsTargetOwnAliveNonHeroUnit(unit caster, unit target)
  {
    return caster.Owner == target.Owner && target.Alive &&
            target.IsInvulnerable == false && !target.IsResistant() &&
            !target.IsUnitType(unittype.Structure) && !target.IsUnitType(unittype.Ancient);
  }

  public static bool IsTargetEnemyAndAlive(unit caster, unit target)
  {
    var casterPlayer = caster.Owner;
    return caster != target &&
           (target.IsEnemyTo(casterPlayer) || target.Owner == player.NeutralPassive) &&
           target.Alive && target.IsInvulnerable == false;
  }
  
// Used for spells where you only want them to affect enemy ground units. Flying units and structures are not affected
  public static bool IsTargetEnemyAliveAndGroundUnits(unit caster, unit target)
  {
    var casterPlayer = caster.Owner;
    return caster != target &&
           (target.IsEnemyTo(casterPlayer) || target.Owner == player.NeutralPassive) &&
           target.Alive && target.IsInvulnerable == false && !target.IsUnitType(unittype.Structure) && !target.IsUnitType(unittype.Flying);
  }

// Used for spells where you only want them to affect all enemy units (including flying units). Structures are not affected.
  public static bool IsTargetEnemyAndAliveUnits(unit caster, unit target)
  {
    var casterPlayer = caster.Owner;
    return caster != target &&
           (target.IsEnemyTo(casterPlayer) || target.Owner == player.NeutralPassive) &&
           target.Alive && target.IsInvulnerable == false && !target.IsUnitType(unittype.Structure);
  }
}
