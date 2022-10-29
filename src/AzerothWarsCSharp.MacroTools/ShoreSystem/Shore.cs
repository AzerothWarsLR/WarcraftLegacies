using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.ShoreSystem
{
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
    /// Initializes a new instance of the <see cref="Shore"/> class.
    /// </summary>
    /// <param name="x">The x position of the <see cref="Shore"/>.</param>
    /// <param name="y">The y position of the <see cref="Shore"/>.</param>
    public Shore(float x, float y)
    {
      Position = new Point(x, y);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shore"/> class.
    /// </summary>
    /// <param name="position">The position of the <see cref="Shore"/>.</param>
    public Shore(Point position)
    {
      Position = position;
    }
  }
}