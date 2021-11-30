using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public static class DummyCast
  {
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