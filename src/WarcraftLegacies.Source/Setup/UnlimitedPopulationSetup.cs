using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup;

/// <summary>Prevents units from consuming food while preserving all other unit limits.</summary>
public static class UnlimitedPopulationSetup
{
  /// <summary>Disables food usage for existing and subsequently created units.</summary>
  public static void Setup()
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds))
    {
      SetUnitUseFood(unit, false);
    }

    var worldRegion = CreateRegion();
    RegionAddRect(worldRegion, Rectangle.WorldBounds.Rect);

    var enterWorldTrigger = CreateTrigger();
    TriggerRegisterEnterRegion(enterWorldTrigger, worldRegion, null);
    TriggerAddAction(enterWorldTrigger, () => SetUnitUseFood(GetEnteringUnit(), false));
  }
}
