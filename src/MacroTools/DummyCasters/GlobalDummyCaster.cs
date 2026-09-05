using MacroTools.Extensions;
using WCSharp.Shared.Data;

namespace MacroTools.DummyCasters;

/// <summary>A dummy caster that can be used to cast any instant ability.</summary>
public sealed class GlobalDummyCaster
{
  private readonly unit _unit;

  internal GlobalDummyCaster(unit unit) => _unit = unit;

  /// <summary>
  /// Casts specified ability from the specified object at the specified target.
  /// </summary>
  public void CastUnit(unit caster, int abilId, int orderId, int level, unit target, DummyCastOriginType originType)
  {
    if originType == DummyCastOriginType.Caster 
    {
      _unit.X = caster.X;
      _unit.Y = caster.Y;
    }
    else
    {
      _unit.X = target.X;
      _unit.Y = target.Y;
    }
    var owningPlayer = caster.Owner;
    _unit.SetOwner(owningPlayer);
    _unit.AddAbility(abilId);
    _unit.SetAbilityLevel(abilId, level);

    if (originType == DummyCastOriginType.Caster)
    {
      _unit.FacePosition(target.X, target.Y);
    }

    _unit.IssueOrder(orderId, target);
    _unit.RemoveAbility(abilId);
  }

  /// <summary>
  /// Casts the specified spell at the caster's position with no target.
  /// </summary>
  public void CastNoTarget(unit caster, int abilId, int orderId, int level)
  {
    var owningPlayer = caster.Owner;
    _unit.SetOwner(owningPlayer);
    _unit.X = caster.X;
    _unit.Y = caster.Y;
    _unit.AddAbility(abilId);
    _unit.SetAbilityLevel(abilId, level);

    _unit.IssueOrder(orderId);
    _unit.RemoveAbility(abilId);
  }

  /// <summary>
  /// Sets the facing angle of the internal dummy unit before casting a spell.
  /// Useful for directional abilities such as cone attacks, where the dummy's
  /// facing determines the direction of the effect.
  /// </summary>
  public void SetFacing(float angle)
  {
    _unit.SetFacing(angle);
  }
  /// <summary>
  /// Casts the specified spell from the specified point.
  /// </summary>
  public void CastPoint(player whichPlayer, int abilId, int orderId, int level, Point target)
  {
    _unit.SetOwner(whichPlayer);
    _unit.X = target.X;
    _unit.Y = target.Y;
    _unit.AddAbility(abilId);
    _unit.SetAbilityLevel(abilId, level);
    _unit.IssueOrder(orderId, target.X, target.Y);
    _unit.RemoveAbility(abilId);
  }
  public void CastPointFromCaster(unit caster, int abilId, int orderId, int level, float x, float y)
  {
    var whichPlayer = caster.Owner;

    _unit.SetOwner(whichPlayer);
    _unit.X = caster.X;
    _unit.Y = caster.Y;
    _unit.AddAbility(abilId);
    _unit.SetAbilityLevel(abilId, level);

    _unit.FacePosition(x, y);
    _unit.IssueOrder(orderId, x, y);

    _unit.RemoveAbility(abilId);
  }

}
