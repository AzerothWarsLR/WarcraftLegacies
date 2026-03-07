using MacroTools.ControlPoints;

namespace MacroTools.GoldMines;

/// <summary>
/// A fixture to a <see cref="ControlPoint"/> that grants bonus income with a limited capacity.
/// </summary>
internal sealed class GoldMine
{
  private float _remaining;

  /// <summary>
  /// How much gold the mine gives per turn.
  /// </summary>
  public int Income { get; }

  /// <summary>
  /// How much gold the mine has left.
  /// </summary>
  public float Remaining
  {
    get
    {
      return _remaining;
    }
    set
    {
      _remaining = value;
      ControlPoint.Unit.ResourceAmount = (int)_remaining;
    }
  }

  /// <summary>
  /// The effect representing this mine.
  /// </summary>
  public effect Effect { get; }

  /// <summary>
  /// The <see cref="ControlPoint"/> this <see cref="GoldMine"/> sits atop.
  /// </summary>
  public ControlPoint ControlPoint { get; }

  internal GoldMine(effect effect, int income, float remaining, ControlPoint controlPoint)
  {
    ControlPoint = controlPoint;
    Effect = effect;
    Income = income;
    Remaining = remaining;
  }
}
