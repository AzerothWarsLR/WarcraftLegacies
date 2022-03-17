using AzerothWarsCSharp.Source.Main.Libraries;

namespace AzerothWarsCSharp.Source.Main.Spells
{
  public static class ElectricStrike
  {
    private static readonly int AbilId = FourCC("A0RC");
    private static readonly int StunId = FourCC("A0RD"); //The ability that gets cast on each unit in the radius
    private static readonly int PurgeId = FourCC("Aprg"); //The ability that gets cast on each unit in the radius
    private const string PURGE_ORDER = "purge";
    private const string STUN_ORDER = "firebolt";
    private const float RADIUS = 50000;
    private static readonly group TempGroup = CreateGroup();
    
    private static void Cast()
    {
      unit u;
      unit caster;
      caster = GetTriggerUnit();
      GroupEnumUnitsInRange(TempGroup, GetSpellTargetX(), GetSpellTargetY(), RADIUS, null);
      while (true)
      {
        u = FirstOfGroup(TempGroup);
        if (u == null)
        {
          break;
        }

        if (IsUnitType(u, UNIT_TYPE_STRUCTURE) == false && UnitAlive(u) == true)
        {
          DummyCast.DummyCastUnit(GetOwningPlayer(caster), StunId, STUN_ORDER, 1, u);
          DummyCast.DummyCastUnit(GetOwningPlayer(caster), PurgeId, PURGE_ORDER, 1, u);
        }

        GroupRemoveUnit(TempGroup, u);
      }
    }

    private static void OnInit()
    {
      RegisterSpellEffectAction(AbilId, Cast);
    }
  }
}