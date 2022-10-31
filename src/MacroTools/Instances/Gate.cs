using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Instances
{
  public sealed class Gate
  {
    private readonly unit _exteriorWaygate;
    private readonly unit _interiorWaygate;

    private Gate(unit interiorWaygate, unit exteriorWaygate)
    {
      _interiorWaygate = interiorWaygate;
      _exteriorWaygate = exteriorWaygate;
    }

    public Point InteriorPosition => new(GetUnitX(_interiorWaygate), GetUnitY(_interiorWaygate));

    public Point ExteriorPosition => new(GetUnitX(_exteriorWaygate), GetUnitY(_exteriorWaygate));

    public void Destroy()
    {
      KillUnit(_interiorWaygate);
      KillUnit(_exteriorWaygate);
    }
  }
}