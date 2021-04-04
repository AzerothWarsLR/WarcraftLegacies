using System;
using WCSharp.Utils.Data;
namespace AzerothWarsCSharp.Source.Libraries
{
  /// <summary>
  /// A known objective that can be completed by a particular Faction.
  /// Can either productive a particular outcome or affect the completion status of its parent.
  /// </summary>
  public abstract class Objective
  {
    public Objective(IObjectiveParent parent)
    {
      Parent = parent;
    }

    public QuestProgress Progress { get; protected set; }

    /// <summary>
    /// The data structure reponsible for telling this QuestObjective which Faction can complete it.
    /// </summary>
    public IObjectiveParent Parent { get; }

    /// <summary>
    /// Raised when this objective's progress has changed.
    /// </summary>
    public event EventHandler<ObjectiveEventArgs> ProgressChanged;

    public Action<Faction> OnDiscover;
    public Action<Faction> OnComplete;
    public Action<Faction> OnFail;
    public Action<Faction> OnAdd;

    /// <summary>
    /// Whether or not this can be seen as a bullet point in the quest log.
    /// </summary>
    public virtual bool ShowsInQuestLog { get; } = true;

    /// <summary>
    /// Where on the minimap this objective should be rendered.
    /// </summary>
    public abstract Point Location { get; }

    /// <summary>
    /// A path to a model used to render this QuestObjective.
    /// </summary>
    public string MinimapIconPath { get; } = "MinimapQuestObjectivePrimary";

    /// <summary>
    /// The Faction that can affect the progress of this QuestObjective through some kind of action,
    /// and be rewarded in some way when this QuestObjective (or its parent) is completed.
    /// </summary>
    public Faction Holder { get; }

    public string Description { get; }
  }
}