using System.Collections;
using System.Numerics;
using War3Net.Build.Widget;

namespace Warcraft.Cartographer.IO;

/// <summary>
/// Stores <see cref="WidgetData"/> objects organized into position-based chunks.
/// </summary>
/// <typeparam name="T">The type of widget stored, derived from <see cref="WidgetData"/>.</typeparam>
public sealed class ChunkedWidgetSet<T> : IEnumerable<KeyValuePair<(int X, int Y), HashSet<T>>>
  where T : WidgetData
{
  /// <summary>The size of each square chunk.</summary>
  private const int ChunkSize = 512;

  private readonly Dictionary<(int X, int Y), HashSet<T>> _widgetsByChunk = new();

  /// <summary>
  /// Initializes a new instance of the <see cref="ChunkedWidgetSet{T}"/> class.
  /// </summary>
  public ChunkedWidgetSet()
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="ChunkedWidgetSet{T}"/> class
  /// that contains widgets copied from the specified <see cref="IEnumerable{T}"/>
  /// and organizes them into position-based chunks.
  /// </summary>
  /// <param name="widgets">The sequence of widgets whose elements are copied to the new set.</param>
  public ChunkedWidgetSet(IEnumerable<T> widgets)
  {
    AddRange(widgets);
  }

  /// <summary>
  /// Adds a widget to the chunk that contains its position.
  /// </summary>
  /// <param name="widget">The widget to add.</param>
  public void Add(T widget)
  {
    var chunk = GetChunkPosition(widget.Position);

    if (!_widgetsByChunk.TryGetValue(chunk, out var widgets))
    {
      _widgetsByChunk[chunk] = widgets = [];
    }

    widgets.Add(widget);
  }

  /// <summary>
  /// Adds multiple widgets to their respective chunks.
  /// </summary>
  /// <param name="widgets">The widgets to add.</param>
  public void AddRange(IEnumerable<T> widgets)
  {
    foreach (var widget in widgets)
    {
      Add(widget);
    }
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  public IEnumerator<KeyValuePair<(int X, int Y), HashSet<T>>> GetEnumerator() => _widgetsByChunk.GetEnumerator();

  private static (int X, int Y) GetChunkPosition(Vector3 position) =>
  (
    RoundToNearestMultipleOf(position.X, ChunkSize),
    RoundToNearestMultipleOf(position.Y, ChunkSize)
  );

  private static int RoundToNearestMultipleOf(float val, float multiple)
  {
    var rem = val % multiple;
    var result = val - rem;
    if (rem >= multiple / 2)
    {
      result += multiple;
    }

    return (int)result;
  }
}
