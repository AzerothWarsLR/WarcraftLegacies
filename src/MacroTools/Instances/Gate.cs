using System;
using WCSharp.Shared.Data;

namespace MacroTools.Instances
{
  public sealed class Gate
  {
    private readonly Func<Point> _exteriorPosition;
    private readonly Func<Point> _interiorPosition;

    public Gate(Func<Point> interiorPosition, Func<Point> exteriorPosition)
    {
      _interiorPosition = interiorPosition;
      _exteriorPosition = exteriorPosition;
    }

    public Point InteriorPosition => _interiorPosition();

    public Point ExteriorPosition => _exteriorPosition();
  }
}