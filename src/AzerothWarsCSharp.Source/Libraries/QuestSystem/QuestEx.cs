using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public class QuestEx : IObjectiveParent
  {
    public Action<Faction> OnDiscover;
    public Action<Faction> OnComplete;
    public Action<Faction> OnFail;
    public Action<Faction> OnAdd;

    public QuestEx()
    {
      throw new NotImplementedException();
    }

    public string Title;
    public string Icon;
    public bool Global;
    public string CompletionDescription;
    public string FailureDescription;
    public string CompletionPopup;
    public string FailurePopup;
    public string Description;
    public bool ProgressLocked;
    public QuestProgress Progress;
    public Faction Owner;
    public List<Objective> QuestObjectives;

    public List<Objective> Objectives { get; }

    public Message MessageByProgress(QuestProgress progress)
    {
      throw new NotImplementedException();
    }
  }
}