using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Instances
{
  /// <summary>
  ///   An instance is a region that is physically seperate from all other instances irrespective of its actual geographical
  ///   location on the Warcraft map.
  /// </summary>
  public sealed class Instance
  {
    private readonly TriggerWrapper _dependencyDiesTrigger = new();
    private readonly List<Gate> _gates = new();

    public Instance()
    {
      Region = CreateRegion();
      foreach (var rectangle in Rectangles) RegionAddRect(Region, rectangle.Rect);
    }

    public region Region { get; }

    public List<Rectangle> Rectangles { get; } = new();

    public string Name { get; set; }

    public int GateCount => _gates.Count;

    /// <summary>
    ///   Gets the <see cref="Gate" /> nearest the given position, if any.
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

    /// <summary>
    ///   Kills all <see cref="unit" />s in the instance and moves all <see cref="item" />s to the nearest exterior
    ///   <see cref="Gate" />.
    /// </summary>
    private void Destroy()
    {
      foreach (var rect in Rectangles)
      {
        EnumItemsInRect(rect.Rect, null, () =>
        {
          var filterItem = GetFilterItem();
          var exteriorPosition = GetNearestGate(filterItem.GetPosition())?.ExteriorPosition;
          if (exteriorPosition is not null)
            filterItem.SetPosition(exteriorPosition);
        });

        foreach (var unit in new GroupWrapper().EnumUnitsInRect(rect).EmptyToList()) KillUnit(unit);
      }

      foreach (var gate in _gates) gate.Destroy();
    }

    /// <summary>
    ///   Makes the <see cref="Instance" /> dependent on the given <see cref="unit" /> being alive.
    ///   When any of the dependent <see cref="unit" />s die, every unit in the <see cref="Instance" /> is killed.
    /// </summary>
    public void AddDependency(unit dependency)
    {
      _dependencyDiesTrigger.RegisterUnitEvent(dependency, EVENT_UNIT_DEATH);
      _dependencyDiesTrigger.AddAction(Destroy);
    }

    public void AddGate(Gate gate)
    {
      _gates.Add(gate);
    }
  }
}