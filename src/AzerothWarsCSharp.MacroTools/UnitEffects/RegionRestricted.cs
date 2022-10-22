using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.UnitEffects
{
  /// <summary>
  /// Prevents the unit from being created or built outside of particular areas.
  /// </summary>
  public sealed class RegionRestricted : UnitEffect
  {
    private readonly Rectangle[] _requiredRectangles;

    public RegionRestricted(int unitTypeId, IEnumerable<Rectangle> requiredRectangles) : base(unitTypeId)
    {
      _requiredRectangles = requiredRectangles.ToArray();
    }

    public override void OnCreated()
    {
      var pos = GetTriggerUnit().GetPosition();
      var inValidRectangle = false;
      foreach (var rectangle in _requiredRectangles)
      {
        if (rectangle.Contains(pos))
        {
          inValidRectangle = true;
          break;
        }
      }

      if (!inValidRectangle)
      {
        KillUnit(GetTriggerUnit());
      }
    }
  }
}