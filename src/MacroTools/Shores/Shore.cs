using WCSharp.Shared.Data;

namespace MacroTools.Shores;

/// <summary>
/// A position where the beach meets the shore.
/// </summary>
public sealed class Shore
{
  /// <summary>
  /// Where the <see cref="Shore"/> is on the map.
  /// </summary>
  public Point Position { get; }

  /// <summary>
  /// A user-friendly name for the <see cref="Shore"/>.
  /// </summary>
  public string Name { get; }

  /// <summary>
  /// Initializes a new instance of the <see cref="Shore"/> class.
  /// </summary>
  /// <param name="position">The position of the <see cref="Shore"/>.</param>
  /// <param name="name">A user-friendly name for the <see cref="Shore"/>.</param>
  public Shore(Point position, string name)
  {
    Position = position;
    Name = name;
  }
}
