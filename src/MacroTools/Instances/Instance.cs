using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Libraries;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Instances
{
  /// <summary>
  ///   An instance is a region that is physically seperate from all other instances irrespective of its actual geographical
  ///   location on the Warcraft map.
  /// </summary>
  public sealed class Instance
  {
    public region Region { get; }

    public int GateCount => _gates.Count;
    
    private readonly trigger _dependencyDiesTrigger;
    private readonly List<Gate> _gates = new();
    private readonly string _name;
    private readonly Rectangle[] _rectangles;
    private readonly List<unit> _dependencies = new();
    
    public Instance(string name, IEnumerable<Rectangle> areas)
    {
      Region = CreateRegion();
      _rectangles = areas.ToArray();
      foreach (var rectangle in _rectangles)
        RegionAddRect(Region, rectangle.Rect);
      _name = name;
      _dependencyDiesTrigger = CreateTrigger()
        .AddAction(Destroy);
    }

    public Instance(string name, Rectangle area) : this(name, new[] {area})
    {
    }
    
    /// <summary>
    /// Adds a <see cref="Gate"/> to the <see cref="Instance"/>, indicating where it can be entered and exited.
    /// </summary>
    public void AddGate(Gate gate)
    {
      _gates.Add(gate);
    }
    
    /// <summary>
    ///   Gets the <see cref="Gate" /> nearest the given position, if any.
    /// </summary>
    public Gate GetNearestGate(Point position)
    {
      float distanceToNearestGate = 0;
      Gate? nearestGate = null;
      
      foreach (var gate in _gates)
      {
        var distance = MathEx.GetDistanceBetweenPoints(position, gate.InteriorPosition);
        if (!(distance > distanceToNearestGate)) 
          continue;
        nearestGate = gate;
        distanceToNearestGate = distance;
      }

      if (nearestGate == null)
        throw new InvalidOperationException(
          $"Could not find the nearest {nameof(Gate)} for {nameof(Instance)} {_name} at position {position}.");
      
      return nearestGate;
    }

    /// <summary>
    ///   Kills all <see cref="unit" />s in the instance and moves all <see cref="item" />s to the nearest exterior
    ///   <see cref="Gate" />.
    /// </summary>
    private void Destroy()
    {
      try
      {
        _dependencyDiesTrigger.Destroy();
        foreach (var rect in _rectangles)
        {
          foreach (var unit in CreateGroup().EnumUnitsInRect(rect).EmptyToList())
            KillUnit(unit);

          EnumItemsInRect(rect.Rect, null, () =>
          {
            try
            {
              var enumItem = GetEnumItem();
              var exteriorPosition = GetNearestGate(enumItem.GetPosition()).ExteriorPosition;
              enumItem.SetPosition(exteriorPosition);
            }
            catch (Exception ex)
            {
              Logger.LogError(ex.ToString());
            }
          });
        }

        foreach (var unit in _dependencies)
          unit.Kill();
      }
      catch (Exception ex)
      {
        Logger.LogError(ex.ToString());
      }
    }

    /// <summary>
    ///   Makes the <see cref="Instance" /> dependent on the given <see cref="unit" /> being alive.
    ///   When any of the dependent <see cref="unit" />s die, every unit in the <see cref="Instance" /> is killed.
    /// </summary>
    public void AddDependency(unit dependency)
    {
      _dependencies.Add(dependency);
      _dependencyDiesTrigger.RegisterUnitEvent(dependency, EVENT_UNIT_DEATH);
    }
  }
}