using System.Collections.Generic;
using MacroTools.Shared;
using MacroTools.UnitTypes;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Responsible for preventing Shipyards from being constructed in specific areas.
/// </summary>
public static class ShipyardBanZones
{
  /// <summary>
  /// Prevents Shipyards from being constructed in the provided areas.
  /// </summary>
  public static void Setup(IEnumerable<Rectangle> banZones)
  {
    foreach (var unitType in UnitType.GetAll())
    {
      if (unitType.Categories.Contains(UnitCategory.Shipyard))
      {
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesConstruction, () =>
        {
          var constructedStructure = @event.ConstructedStructure;
          foreach (var banZone in banZones)
          {
            if (!banZone.Contains(constructedStructure.X, constructedStructure.Y))
            {
              continue;
            }

            constructedStructure.Owner.Gold += unitType.GoldCost;
            constructedStructure.Kill();
          }
        }, unitType.Id);
      }
    }
  }
}
