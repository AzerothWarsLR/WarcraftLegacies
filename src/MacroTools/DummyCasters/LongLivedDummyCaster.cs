using MacroTools.Extensions;
using WCSharp.Shared.Data;

namespace MacroTools.DummyCasters
{
  /// <summary>
  /// A dummy caster that needs to last longer than an instant, usually so it can finish casting spells with cast times
  /// or channeling durations.
  /// </summary>
  public sealed class LongLivedDummyCaster
  {
    private readonly int _unitTypeId;

    internal LongLivedDummyCaster(int unitTypeId) => _unitTypeId = unitTypeId;

    /// <summary>
    /// Causes the specified spell to be channeled at a particular point.
    /// </summary>
    public void ChannelOnPoint(unit caster, int abilityId, int orderId, int level, Point targetPoint, float duration)
    {
      var newUnit = CreateUnit(GetOwningPlayer(caster), _unitTypeId, targetPoint.X, targetPoint.Y, 0);
      newUnit.AddAbility(abilityId);
      SetUnitAbilityLevel(newUnit, abilityId, level);
      IssueImmediateOrderById(newUnit, orderId);
      newUnit.SetTimedLife(duration);
    }

    /// <summary>
    /// Causes the specified spell to be channeled at the caster's point.
    /// </summary>
    public void ChannelAtCaster(unit caster, int abilityId, int orderId, int level, float duration)
    {
      var newUnit = CreateUnit(GetOwningPlayer(caster), _unitTypeId, caster.GetPosition().X, caster.GetPosition().Y, 0);
      newUnit.AddAbility(abilityId);
      SetUnitAbilityLevel(newUnit, abilityId, level);
      IssueImmediateOrderById(newUnit, orderId);
      newUnit.SetTimedLife(duration);
    }
  }
}