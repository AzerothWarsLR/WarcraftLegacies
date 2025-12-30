namespace MacroTools.PreplacedWidgetsSystem;

/// <summary>
/// Provides access to preplaced <see cref="widget"/>s in the map.
/// </summary>
public static class PreplacedWidgets
{
  /// <summary>
  /// The maximum distance used when searching for the closest widget.
  /// </summary>
  public static float MaximumDistanceToFind { get; set; } = 1000f;

  /// <summary>
  /// Gets the collection of preplaced <see cref="unit"/> instances.
  /// </summary>
  public static PreplacedWidgetCollection<unit> Units { get; } = new PreplacedUnits();

  /// <summary>
  /// Gets the collection of preplaced <see cref="destructable"/> instances.
  /// </summary>
  public static PreplacedWidgetCollection<destructable> Destructables { get; } = new PreplacedDestructables();

  /// <summary>
  /// Gets the collection of preplaced <see cref="item"/> instances.
  /// </summary>
  public static PreplacedWidgetCollection<item> Items { get; } = new PreplacedItems();
}

