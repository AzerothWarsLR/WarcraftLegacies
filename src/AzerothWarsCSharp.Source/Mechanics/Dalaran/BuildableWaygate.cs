//Allows exactly two Waygates to be built on the map. These Waygates can teleport units between themselves.

namespace AzerothWarsCSharp.Source.Mechanics.Dalaran
{
  public sealed class BuildableWaygate
  {
    private const int WAYGATE_UNITTYPE = FourCC(n0AO);
    private static thistype _waygateA = 0;
    private static thistype _waygateB = 0;
    private bool _constructed;

    private bool Constructed
    {
      get { return _constructed; }
      set
      {
        _constructed = value;
        if (_waygateA.Constructed && _waygateB.Constructed)
        {
          LinkWaygates();
        }
      }
    }

    private static void UnlinkWaygates()
    {
      WaygateActivate(_waygateA.unit, false);
      WaygateActivate(_waygateB.unit, false);
    }

    private static void LinkWaygates()
    {
      WaygateSetDestination(_waygateA.unit, GetUnitX(_waygateB.unit), GetUnitY(_waygateB.unit));
      WaygateSetDestination(_waygateB.unit, GetUnitX(_waygateA.unit), GetUnitY(_waygateA.unit));
      WaygateActivate(_waygateA.unit, true);
      WaygateActivate(_waygateB.unit, true);
    }

    private static bool AIDS_filter(unit u)
    {
      if (GetUnitTypeId(u) == WAYGATE_UNITTYPE)
      {
        return true;
      }

      return false;
    }

    private void AIDS_onCreate()
    {
      if (_waygateA == 0)
      {
        _waygateA = this;
      }
      else if (_waygateB == 0)
      {
        _waygateB = this;
      }
      else
      {
        BJDebugMsg("ERROR: can!have more than 2 BuildableWaygates on the map");
      }
    }

    private void AIDS_onDestroy()
    {
      if (this == _waygateA)
      {
        _waygateA = 0;
      }
      else if (this == _waygateB)
      {
        _waygateB = 0;
      }

      public void UnlinkWaygates()
      {
      }

      private static void OnWaygateDeath()
      {
        RemoveUnit(GetTriggerUnit());
      }

      public static void Setup()
      {
        RegisterUnitTypeDiesAction(WAYGATE_UNITTYPE, OnWaygateDeath);
      }
    }
  }
}