using System;
using System.Collections.Generic;
using MacroTools.Libraries;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.PreplacedWidgetsSystem;

/// <summary>
/// Represents a collection of preplaced <see cref="widget"/> instances of a specific type.
/// </summary>
public abstract class PreplacedWidgetCollection<T> where T : widget
{
  private readonly Dictionary<int, List<T>> _widgetsByTypeId = new();

  /// <summary>
  /// Gets the single preplaced <see cref="widget"/> of the specified type id.
  /// </summary>
  /// <param name="typeId">The type id of the <see cref="widget"/> to retrieve.</param>
  /// <exception cref="KeyNotFoundException">
  /// Thrown when no widget exists with the specified type id.
  /// </exception>
  /// <exception cref="InvalidOperationException">
  /// Thrown when more than one widget exists with the specified type id.
  /// Use <see cref="GetClosest(int, Point)"/> to select by location.
  /// </exception>
  public T Get(int typeId)
  {
    var widgets = GetAll(typeId);

    return widgets.Count == 1
      ? widgets[0]
      : throw new InvalidOperationException($"There are multiple preplaced widgets with id {FourCc.GetString(typeId)}.");
  }

  /// <summary>
  /// Gets all preplaced <see cref="widget"/> instances with the specified type id.
  /// </summary>
  /// <param name="typeId">The type id of the <see cref="widget"/>s to retrieve.</param>
  /// <exception cref="KeyNotFoundException">
  /// Thrown when no widgets exist with the specified type id.
  /// </exception>
  public List<T> GetAll(int typeId)
  {
    return _widgetsByTypeId.TryGetValue(typeId, out var widgets)
      ? widgets
      : throw new KeyNotFoundException($"There are no preplaced widgets with id {FourCc.GetString(typeId)}.");
  }

  /// <summary>
  /// Gets the closest preplaced <see cref="widget"/> with the specified type id to the given location.
  /// </summary>
  /// <param name="typeId">The type id of the <see cref="widget"/>s to retrieve.</param>
  /// <param name="point">The location used to select the closest widget.</param>
  /// <exception cref="KeyNotFoundException">
  /// Thrown when no widgets exist with the specified type id.
  /// </exception>
  public T GetClosest(int typeId, Point point)
  {
    return GetClosest(typeId, point.X, point.Y);
  }

  /// <summary>
  /// Gets the closest preplaced <see cref="widget"/> with the specified type id to the given location.
  /// </summary>
  /// <param name="typeId">The type id of the <see cref="widget"/>s to retrieve.</param>
  /// <param name="x">The X coordinate used to select the closest widget.</param>
  /// <param name="y">The Y coordinate used to select the closest widget.</param>
  /// <exception cref="KeyNotFoundException">
  /// Thrown when no widgets exist with the specified type id.
  /// </exception>
  public T GetClosest(int typeId, float x, float y)
  {
    var widgets = GetAll(typeId);
    var widgetsCount = widgets.Count;

    if (widgetsCount == 0)
    {
      throw new InvalidOperationException("Cannot select closest widget from an empty collection.");
    }

    if (widgetsCount == 1)
    {
      return widgets[0];
    }

    var closest = widgets[0];
    var closestDistance = float.MaxValue;

    foreach (var widget in widgets)
    {
      var distance = MathEx.GetDistanceBetween(x, y, widget);
      if (distance < closestDistance)
      {
        closest = widget;
        closestDistance = distance;
      }
    }

    if (closestDistance > PreplacedWidgets.MaximumDistanceToFind)
    {
      Logger.LogWarning($"No preplaced widgets with id {FourCc.GetString(typeId)} found within {PreplacedWidgets.MaximumDistanceToFind} of {x}, {y}.");
    }

    return closest;
  }

  protected void AddWidget(int typeId, T widget)
  {
    if (!_widgetsByTypeId.TryGetValue(typeId, out var widgets))
    {
      _widgetsByTypeId[typeId] = widgets = new List<T>();
    }

    widgets.Add(widget);
  }
}
