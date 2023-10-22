using MacroTools.Extensions;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.DummyCasters
{
  /// <summary>A dummy caster that can be used to cast any instant ability.</summary>
  public sealed class GlobalDummyCaster
  {
    private readonly unit _unit;

    public GlobalDummyCaster(unit unit)
    {
      _unit = unit;
    }
    
    /// <summary>
    /// Causes the specified ability to be cast from the specified object at the specified target.
    /// </summary>
    public void DummyCastUnit(unit caster, int abilId, string orderId, int level, unit target, DummyCastOriginType originType)
    {
      var originPoint = originType == DummyCastOriginType.Caster ? caster.GetPosition() : target.GetPosition();
      _unit
        .SetOwner(caster.OwningPlayer())
        .SetPosition(originPoint)
        .AddAbility(abilId)
        .SetAbilityLevel(abilId, level);

      if (originType == DummyCastOriginType.Caster)
        _unit.FacePosition(target.GetPosition());

      _unit
        .IssueOrder(orderId, target)
        .RemoveAbility(abilId);
    }

    public void DummyCastNoTarget(unit caster, int abilId, int orderId, int level)
    {
      _unit
        .SetOwner(caster.OwningPlayer())
        .SetPosition(caster.GetPosition())
        .AddAbility(abilId)
        .SetAbilityLevel(abilId, level);

      _unit
        .IssueOrder(orderId)
        .RemoveAbility(abilId);
    }

    /// <summary>
    /// Causes the specified spell to be cast on a particular point.
    /// </summary>
    public void DummyCastNoTargetOnUnit(unit caster, int abilId, string orderId, int level, unit target)
    {
      _unit
        .SetOwner(caster.OwningPlayer())
        .SetPosition(target.GetPosition())
        .AddAbility(abilId)
        .SetAbilityLevel(abilId, level);

      _unit
        .IssueOrder(orderId)
        .RemoveAbility(abilId);
    }

    /// <summary>
    /// Causes the specified spell to be cast at a particular point.
    /// </summary>
    public void DummyCastPoint(player whichPlayer, int abilId, string orderId, int level, Point target)
    {
      _unit
        .SetOwner(whichPlayer)
        .SetPosition(target)
        .AddAbility(abilId)
        .SetAbilityLevel(abilId, level)
        .IssueOrder(orderId, target)
        .RemoveAbility(abilId);
    }

    /// <summary>
    /// Causes the specified spell to be cast on all units in a circle.
    /// </summary>
    public void DummyCastOnUnitsInCircle(unit caster, int abilId, string orderId, int level, Point center,
      float radius, DummyCast.CastFilter castFilter, DummyCastOriginType originType)
    {
      foreach (var target in CreateGroup()
                 .EnumUnitsInRange(center, radius).EmptyToList()
                 .FindAll(unit => castFilter(caster, unit)))
      {
        DummyCastUnit(caster, abilId, orderId, level, target, originType);
      }
    }
  }
}