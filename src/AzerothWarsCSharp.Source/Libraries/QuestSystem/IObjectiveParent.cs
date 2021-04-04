namespace AzerothWarsCSharp.Source.Libraries
{
  /// <summary>
  /// A parent of a QuestObjective.
  /// </summary>
  public interface IObjectiveParent
  {
    /// <summary>
    /// The Faction that can affect the progress of this QuestObjective through some kind of action,
    /// and be rewarded in some way when this QuestObjective (or its parent) is completed.
    /// </summary>
    public Faction Holder { get; }

    public void AddObjective(Objective objective);
  }
}