using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.PreplacedWidgetsSystem;

internal sealed class PreplacedUnits : PreplacedWidgetCollection<unit>
{
  public PreplacedUnits()
  {
    EnumerateUnits();
  }

  private void EnumerateUnits()
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds))
    {
      AddWidget(unit.UnitType, unit);
    }
  }
}
