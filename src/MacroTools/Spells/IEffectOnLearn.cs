namespace MacroTools.Spells;

/// <summary>
/// An effect that occurs when a particular spell is learned.
/// </summary>
public interface IEffectOnLearn
{
  /// <summary>
  /// Invoked when the ability is learned.
  /// </summary>
  public void OnLearn(unit learner);
}
