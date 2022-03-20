namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public static class DummyCast
  {
    private group TempGroup = CreateGroup();

    public static void DummyChannelInstantFromPoint(player whichPlayer, int abilId, string orderId, int level,
      float x, float y, float duration)
    {
      unit u = CreateUnit(whichPlayer, DUMMY_TYPE, x, y, 0);
      UnitAddAbility(u, abilId);
      IssueImmediateOrder(u, orderId);
      UnitApplyTimedLife(u, FourCC(BTLF), duration);
    }

    public static void DummyCastUnit(player whichPlayer, int abilId, string orderId, int level, unit u)
    {
      SetUnitOwner(DUMMY, whichPlayer, false);
      SetUnitX(DUMMY, GetUnitX(u));
      SetUnitY(DUMMY, GetUnitY(u));
      UnitAddAbility(DUMMY, abilId);
      SetUnitAbilityLevel(DUMMY, abilId, level);
      IssueTargetOrder(DUMMY, orderId, u);
      UnitRemoveAbility(DUMMY, abilId);
    }

    public static void DummyCastPoint(player whichPlayer, int abilId, string orderId, int level, float x, float y)
    {
      SetUnitOwner(DUMMY, whichPlayer, false);
      SetUnitX(DUMMY, x);
      SetUnitY(DUMMY, y);
      UnitAddAbility(DUMMY, abilId);
      SetUnitAbilityLevel(DUMMY, abilId, level);
      IssuePointOrder(DUMMY, orderId, x, y);
      UnitRemoveAbility(DUMMY, abilId);
    }

    public static void DummyCastInstant(player whichPlayer, int abilId, string orderId, int level, float x, float y)
    {
      SetUnitOwner(DUMMY, whichPlayer, false);
      SetUnitX(DUMMY, x);
      SetUnitY(DUMMY, y);
      UnitAddAbility(DUMMY, abilId);
      SetUnitAbilityLevel(DUMMY, abilId, level);
      IssueImmediateOrder(DUMMY, orderId);
      UnitRemoveAbility(DUMMY, abilId);
    }

    public static void DummyCastUnitFromPoint(player whichPlayer, int abilId, string orderId, int level, unit u,
      float originX, float originY)
    {
      SetUnitOwner(DUMMY, whichPlayer, false);
      SetUnitX(DUMMY, originX);
      SetUnitY(DUMMY, originY);
      UnitAddAbility(DUMMY, abilId);
      SetUnitAbilityLevel(DUMMY, abilId, level);
      IssueTargetOrder(DUMMY, orderId, u);
      UnitRemoveAbility(DUMMY, abilId);
    }

    public static void DummyCastFromPointOnUnitsInCircle(unit caster, int abilId, string orderId, int level,
      float targetX, float targetY, float radius, float originX, float originY, CastFilter castFilter)
    {
      unit u;
      GroupEnumUnitsInRange(TempGroup, targetX, targetY, radius, null);
      while (true)
      {
        u = FirstOfGroup(TempGroup);
        if (u == null)
        {
          break;
        }

        if (castFilter.evaluate(caster, u))
        {
          DummyCastUnitFromPoint(GetOwningPlayer(caster), abilId, orderId, level, u, originX, originY);
        }

        GroupRemoveUnit(TempGroup, u);
      }
    }

    public static void DummyCastUnitId(player whichPlayer, int abilId, int orderId, int level, unit u)
    {
      SetUnitOwner(DUMMY, whichPlayer, false);
      SetUnitX(DUMMY, GetUnitX(u));
      SetUnitY(DUMMY, GetUnitY(u));
      UnitAddAbility(DUMMY, abilId);
      SetUnitAbilityLevel(DUMMY, abilId, level);
      IssueTargetOrderById(DUMMY, orderId, u);
      UnitRemoveAbility(DUMMY, abilId);
    }

    public static void DummyCastOnUnitsInCircle(unit caster, int abilId, string orderId, int level, float x, float y,
      float radius, CastFilter castFilter)
    {
      unit u;
      GroupEnumUnitsInRange(TempGroup, x, y, radius, null);
      while (true)
      {
        u = FirstOfGroup(TempGroup);
        if (u == null)
        {
          break;
        }

        if (castFilter.evaluate(caster, u))
        {
          DummyCastUnit(GetOwningPlayer(caster), abilId, orderId, level, u);
        }

        GroupRemoveUnit(TempGroup, u);
      }
    }
  }
}