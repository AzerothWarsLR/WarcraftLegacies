using System.Collections.Generic;
using MacroTools.Extensions;
using WarcraftLegacies.Source.Extensions;

namespace WarcraftLegacies.Source.Shared;

/// <summary>A preplaced base waiting to be rescued, which can later be handed to a new owner with its lost structures rebuilt.</summary>
public sealed class RescueBase
{
  private readonly List<unit> _units;
  private readonly List<BaseStructure> _structures = new();
  private readonly bool _unburrow;

  /// <param name="units">The base's units, already prepared for rescue.</param>
  /// <param name="unburrow">Whether burrowed units should unburrow when rescued.</param>
  public RescueBase(List<unit> units, bool unburrow = false)
  {
    _units = units;
    _unburrow = unburrow;
    foreach (var whichUnit in units)
    {
      if (whichUnit.IsUnitType(unittype.Structure))
      {
        _structures.Add(new BaseStructure(whichUnit));
      }
    }
  }

  /// <summary>Whether the base has been given to anyone yet.</summary>
  public bool Rescued { get; private set; }

  /// <summary>Gives the base to <paramref name="newOwner"/>, or to Neutral Aggressive if there is none, if nobody has had it yet.</summary>
  public void Rescue(player? newOwner)
  {
    if (Rescued)
    {
      return;
    }

    Rescued = true;
    newOwner ??= player.NeutralAggressive;
    if (_unburrow)
    {
      newOwner.RescueGroupWithUnburrow(_units);
    }
    else
    {
      newOwner.RescueGroup(_units);
    }
  }

  /// <summary>Gives the base to <paramref name="newOwner"/>, rebuilding any of its structures that have been destroyed.</summary>
  public void HandOver(player newOwner)
  {
    if (!Rescued)
    {
      Rescue(newOwner);
      return;
    }

    foreach (var structure in _structures)
    {
      if (structure.Unit.Alive)
      {
        if (structure.Unit.Owner != newOwner)
        {
          structure.Unit.SetOwner(newOwner);
        }

        continue;
      }

      var rebuilt = PathBase.CreateStructure(newOwner, structure.UnitTypeId, structure.X, structure.Y);
      if (rebuilt != null)
      {
        structure.Unit = rebuilt;
      }
    }
  }

  private sealed class BaseStructure
  {
    public BaseStructure(unit structure)
    {
      Unit = structure;
      UnitTypeId = structure.UnitType;
      X = structure.X;
      Y = structure.Y;
    }

    public unit Unit { get; set; }
    public int UnitTypeId { get; }
    public float X { get; }
    public float Y { get; }
  }
}
