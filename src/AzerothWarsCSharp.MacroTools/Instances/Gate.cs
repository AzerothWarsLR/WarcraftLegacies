using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools
{
  public sealed class Gate
  {
    public Point InteriorPosition;
    public Point ExteriorPosition;

    private Gate(Point interiorPosition, Point exteriorPosition)
    {
      InteriorPosition = interiorPosition;
      ExteriorPosition = exteriorPosition;
    }
  }
}