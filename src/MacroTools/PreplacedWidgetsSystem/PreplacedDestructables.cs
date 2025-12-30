using WCSharp.Shared.Data;

namespace MacroTools.PreplacedWidgetsSystem;

internal sealed class PreplacedDestructables : PreplacedWidgetCollection<destructable>
{
  public PreplacedDestructables()
  {
    EnumerateDestructables();
  }

  private void EnumerateDestructables()
  {
    Rectangle.WorldBounds.Rect.EnumerateDestructables(null, () =>
    {
      var destructable = GetEnumDestructable();
      AddWidget(destructable.Type, destructable);
    });
  }
}
