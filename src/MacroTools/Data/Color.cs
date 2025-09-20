namespace MacroTools.Data;

/// <summary>
/// Represents an RGB color.
/// </summary>
public sealed class Color
{
  /// <summary>
  /// How red the color is.
  /// </summary>
  public int Red { get; }

  /// <summary>
  /// How blue the color is.
  /// </summary>
  public int Blue { get; }

  /// <summary>
  /// How green the color is.
  /// </summary>
  public int Green { get; }

  /// <summary>
  /// How transparent the color is.
  /// </summary>
  public int Alpha { get; }

  /// <summary>
  /// Initializes a new instance of the <see cref="Color"/> class.
  /// </summary>
  public Color(int red, int blue, int green, int alpha)
  {
    Red = red;
    Blue = blue;
    Green = green;
    Alpha = alpha;
  }
}
