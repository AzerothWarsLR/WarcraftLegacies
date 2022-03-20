//Allows exactly two Waygates to be built on the map. These Waygates can teleport units between themselves.

public sealed class BuildableWaygate
{
  private const int WAYGATE_UNITTYPE = FourCC(n0AO);
  private static thistype waygateA = 0;
  private static thistype waygateB = 0;
  private bool _constructed;

  private bool Constructed
  {
    get { return _constructed; }
    set
    {
      _constructed = value;
      if (waygateA.Constructed && waygateB.Constructed)
      {
        LinkWaygates();
      }
    }
  }

  private static void UnlinkWaygates()
  {
    WaygateActivate(waygateA.unit, false);
    WaygateActivate(waygateB.unit, false);
  }

  private static void LinkWaygates()
  {
    WaygateSetDestination(waygateA.unit, GetUnitX(waygateB.unit), GetUnitY(waygateB.unit));
    WaygateSetDestination(waygateB.unit, GetUnitX(waygateA.unit), GetUnitY(waygateA.unit));
    WaygateActivate(waygateA.unit, true);
    WaygateActivate(waygateB.unit, true);
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
    if (waygateA == 0)
    {
      waygateA = this;
    }
    else if (waygateB == 0)
    {
      waygateB = this;
    }
    else
    {
      BJDebugMsg("ERROR: can!have more than 2 BuildableWaygates on the map");
    }
  }

  private void AIDS_onDestroy()
  {
    if (this == waygateA)
    {
      waygateA = 0;
    }
    else if (this == waygateB)
    {
      waygateB = 0;
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