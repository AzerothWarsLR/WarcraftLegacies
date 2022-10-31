using System.Collections.Generic;
using System.Linq;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.Libraries;
using WarcraftLegacies.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Instances
{
  /// <summary>
  ///   An instance is a region that is physically seperate from all other instances irrespective of its actual geographical
  ///   location on the Warcraft map.
  /// </summary>
  public sealed class Instance
  {
    private readonly TriggerWrapper _dependencyDiesTrigger = new();
    private readonly List<Gate> _gates = new();
    private readonly string _name;
    private readonly Rectangle[] _rectangles;

    public Instance(string name, IEnumerable<Rectangle> areas)
    {
      Region = CreateRegion();
      _rectangles = areas.ToArray();
      foreach (var rectangle in _rectangles)
        RegionAddRect(Region, rectangle.Rect);
      _name = name;
    }

    public Instance(string name, Rectangle area) : this(name, new[] {area})
    {
    }

    public region Region { get; }

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
      foreach (var rect in _rectangles)
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