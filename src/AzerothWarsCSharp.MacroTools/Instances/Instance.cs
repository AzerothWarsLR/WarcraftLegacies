using System.Collections.Generic;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Instances
{
  /// <summary>
  /// An instance is a region that is physically seperate from all other instances irrespective of its actual geographical location on the Warcraft map.
  /// </summary>
  public sealed class Instance
  {
    public region Region { get; }
    private readonly List<Gate> _gates = new();

    public List<Rectangle> Rectangles { get; init; }

    public string Name { get; set; }

    public int GateCount => _gates.Count;
    
    /// <summary>
    /// Gets the <see cref="Gate"/> nearest the given position, if any.
    /// </summary>
    public Gate? GetNearestGate(Point position)
    {
      float distanceToNearestGate = 0;
      Gate? nearestGate = null;

      foreach (var gate in _gates)
      {
        var distance = MathEx.GetDistanceBetweenPoints(position, gate.InteriorPosition);
        if (distance > distanceToNearestGate)
        {
          nearestGate = gate;
          distanceToNearestGate = distance;
        }
      }

      return nearestGate;
    }

    public void AddGate(Gate gate)
    {
      _gates.Add(gate);
    }

    public void AddRect(rect whichRect)
    {
      RegionAddRect(Region, whichRect);
    }

    public Instance()
    {
      Region = CreateRegion();
    }
  }
}