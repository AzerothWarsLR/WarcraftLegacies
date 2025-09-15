using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.DummyCasters
{
  /// <summary>A dummy caster that can be used to cast any instant ability.</summary>
  public sealed class GlobalDummyCaster
  {
    private readonly unit _unit;
    
    internal GlobalDummyCaster(unit unit) => _unit = unit;

    /// <summary>
    /// Causes the specified ability to be cast from the specified object at the specified target.
    /// </summary>
    public void CastUnit(unit caster, int abilId, int orderId, int level, unit target, DummyCastOriginType originType)
    {
      var originPoint = originType == DummyCastOriginType.Caster ? caster.GetPosition() : target.GetPosition();
      var owningPlayer = caster.OwningPlayer();
      SetUnitOwner(_unit, owningPlayer, true);
      _unit.SetPosition(originPoint);
      _unit.AddAbility(abilId);
      SetUnitAbilityLevel(_unit, abilId, level);

      if (originType == DummyCastOriginType.Caster)
        _unit.FacePosition(target.GetPosition());

      _unit.IssueOrder(orderId, target);
      UnitRemoveAbility(_unit, abilId);
    }

    public void CastNoTarget(unit caster, int abilId, int orderId, int level)
    {
      var owningPlayer = caster.OwningPlayer();
      SetUnitOwner(_unit, owningPlayer, true);
      _unit.SetPosition(caster.GetPosition());
      _unit.AddAbility(abilId);
      SetUnitAbilityLevel(_unit, abilId, level);

      _unit
        .IssueOrder(orderId);
      UnitRemoveAbility(_unit, abilId);
    }

    /// <summary>
    /// Causes the specified spell to be cast on a particular point.
    /// </summary>
    public void CastNoTargetOnUnit(unit caster, int abilId, int orderId, int level, unit target)
    {
      var owningPlayer = caster.OwningPlayer();
      SetUnitOwner(_unit, owningPlayer, true);
      _unit.SetPosition(target.GetPosition());
      _unit.AddAbility(abilId);
      SetUnitAbilityLevel(_unit, abilId, level);

      _unit.IssueOrder(orderId);
      UnitRemoveAbility(_unit, abilId);
    }

    /// <summary>
    /// Causes the specified spell to be cast at a particular point.
    /// </summary>
    public void CastPoint(player whichPlayer, int abilId, int orderId, int level, Point target)
    {
      SetUnitOwner(_unit, whichPlayer, true);
      _unit.SetPosition(target);
      _unit.AddAbility(abilId);
      SetUnitAbilityLevel(_unit, abilId, level);
      _unit.IssueOrder(orderId, target);
      UnitRemoveAbility(_unit, abilId);
    }

    /// <summary>
    /// Causes the specified spell to be cast on all units in a circle.
    /// </summary>
    public void CastOnUnitsInCircle(unit caster, int abilId, int orderId, int level, Point center,
      float radius, DummyCasterManager.CastFilter castFilter, DummyCastOriginType originType)
    {
      foreach (var target in GlobalGroup
                 .EnumUnitsInRange(center, radius)
                 .FindAll(unit => castFilter(caster, unit)))
      {
        CastUnit(caster, abilId, orderId, level, target, originType);
      }
    }
    
    /// <summary>
    /// Causes the specified spell to be cast on all units in a group.
    /// </summary>
    public void CastOnTargets(unit caster, int abilId, int orderId, int level, IEnumerable<unit> targets,
      DummyCastOriginType originType)
    {
      foreach (var target in targets) 
        CastUnit(caster, abilId, orderId, level, target, originType);
    }
  }
}