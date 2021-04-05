using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;
namespace AzerothWarsCSharp.Source.Libraries
{
  /// <summary>
  /// A known objective that can be completed by a particular Faction.
  /// Can either productive a particular outcome or affect the completion status of its parent.
  /// </summary>
  public abstract class Objective
  {
    public static IEnumerable<Objective> All 
    { 
      get 
      {
        return _all;
      }
    }

    public Objective(Faction holder)
    {
      Holder = holder;
      _all.Add(this);
    }

    public QuestProgress Progress { get; protected set; }

    /// <summary>
    /// Raised when this objective's progress has changed.
    /// </summary>
    public event EventHandler<ObjectiveEventArgs> ProgressChanged;
    public event EventHandler<ObjectiveEventArgs> Destroyed;
    public event EventHandler<ObjectiveEventArgs> FactionChanged;
    public event EventHandler<ObjectiveEventArgs> TeamChanged;
    public static event EventHandler<ObjectiveEventArgs> Created;

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

    public string Description { get; protected set; }

    private static readonly List<Objective> _all = new();
  }
}