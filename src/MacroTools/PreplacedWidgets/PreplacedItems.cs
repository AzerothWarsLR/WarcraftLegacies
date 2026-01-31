using WCSharp.Shared.Data;

namespace MacroTools.PreplacedWidgets;

internal sealed class PreplacedItems : PreplacedWidgetCollection<item>
{
  public PreplacedItems()
  {
    EnumerateItems();
  }

  private void EnumerateItems()
  {
    Rectangle.WorldBounds.Rect.EnumerateItems(null, () =>
    {
      var item = GetEnumItem();
      AddWidget(item.TypeId, item);
    });
  }
}
