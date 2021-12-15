using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public static class DummyCast
  {
    public delegate bool CastFilter(unit caster, unit target);

    public static void ChannelOnPoint(unit caster, int abilityId, string orderId, int level, float x, float y, float duration)
    {
      var u = CreateUnit(GetOwningPlayer(caster), DummyCaster.UnitTypeId, x, y, 0);
      UnitAddAbility(u, abilityId);
      IssueImmediateOrder(u, orderId);
      UnitApplyTimedLife(u, FourCC("BLTF"), duration);
    }
    
    public static void CastOnUnitsInRadius(unit caster, int abilityId, string orderId, int level, float x, float y, float radius, CastFilter castFilter)
    {
      var group = new GroupWrapper();
      group.EnumUnitsInRange(x, y, radius);
      foreach (var target in group.EmptyToList())
      {
        if (castFilter(caster, target))
        {
          CastOnUnit(caster, abilityId, orderId, level, target);
        }
      }
    }
    
    public static void CastOnUnit(unit caster, int abilityId, string orderId, int level, unit target)
    {
      var dummy = DummyCaster.DummyUnit;
      SetUnitOwner(dummy, GetOwningPlayer(caster), false);
      SetUnitX(dummy, GetUnitX(caster));
      SetUnitY(dummy, GetUnitY(caster));
      UnitAddAbility(dummy, abilityId);
      SetUnitAbilityLevel(dummy, abilityId, level);
      IssueTargetOrder(dummy, orderId, target);
      UnitRemoveAbility(dummy, abilityId);
    }
  }
}