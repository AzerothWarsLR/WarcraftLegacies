using System.Collections.Generic;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class GenericBuilding : GenericUnit
  {
    public IEnumerable<Unit> UnitsTrained
    {
      set
      {
        _unit.TechtreeUnitsTrained = value;
      }
    }

    public IEnumerable<PathingRequire> PathingPrevent
    {
      set
      {
        _unit.PathingPlacementPreventedBy = value;
      }
    }

    public IEnumerable<PathingPrevent> PathingRequire
    {
      set
      {
        _unit.PathingPlacementRequires = value;
      }
    }

    public GenericBuilding(UnitType baseType, string newRawCode) : base(baseType, newRawCode)
    {
    }
  }
}