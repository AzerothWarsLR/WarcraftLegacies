namespace MacroTools.ObjectiveSystem
{
  /// <summary>
  /// An <see cref="Objective"/> that has a unit which can be identified as having completed it.
  /// </summary>
  public interface IHasCompletingUnit
  {
    /// <summary>
    /// The unit that completed the <see cref="Objective"/>.
    /// </summary>
    public unit? CompletingUnit { get; }
    
    /// <summary>
    /// The unit that completed the <see cref="Objective"/>'s name.
    /// </summary>
    public string CompletingUnitName { get; }
  }
}