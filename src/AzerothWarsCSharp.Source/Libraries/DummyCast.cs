using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public static class DummyCast
  {
    public delegate bool CastFilter(unit caster, unit target);
    
    public static void CastOnUnitsInRadius(unit caster, int abilityId, string orderId, int level, float x, float y, float radius, CastFilter castFilter)
    {
      var group = new GroupEx();
      group.EnumUnitsInRange(x, y, radius);
      foreach (var target in group.ToList())
      {
        if (castFilter(caster, target))
        {
          CastOnUnit(GetOwningPlayer(caster), abilityId, orderId, level, target);
        }
      }
    }
    
    public static void CastOnUnit(player whichPlayer, int abilityId, string orderId, int level, unit target)
    {
      var dummy = DummyCaster.DummyUnit;
      SetUnitOwner(dummy, whichPlayer, false);
      SetUnitX(dummy, GetUnitX(target));
      SetUnitY(dummy, GetUnitY(target));
      UnitAddAbility(dummy, abilityId);
      SetUnitAbilityLevel(dummy, abilityId, level);
      IssueTargetOrder(dummy, orderId, target);
      UnitRemoveAbility(dummy, abilityId);
    }
  }
}