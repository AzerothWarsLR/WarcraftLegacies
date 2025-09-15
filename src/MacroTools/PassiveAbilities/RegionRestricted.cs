using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Shared.Data;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  /// Prevents the unit from being created or built outside of particular areas.
  /// </summary>
  public sealed class RegionRestricted : PassiveAbility
  {
    private readonly Rectangle[] _requiredRectangles;

    public RegionRestricted(int unitTypeId, IEnumerable<Rectangle> requiredRectangles) : base(unitTypeId)
    {
      _requiredRectangles = requiredRectangles.ToArray();
    }

    public override void OnCreated(unit createdUnit)
    {
      var pos = createdUnit.GetPosition();
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