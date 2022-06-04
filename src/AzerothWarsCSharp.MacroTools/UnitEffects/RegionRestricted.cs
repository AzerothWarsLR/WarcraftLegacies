using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

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
      foreach (var rectangle in _requiredRectangles)
      {
        if (rectangle.Contains(pos))
        {
          KillUnit(GetTriggerUnit());
          return;
        }
      }
    }
  }
}