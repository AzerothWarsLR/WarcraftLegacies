using AzerothWarsCSharp.Source.Libraries;
using System;
using WCSharp.Utils.Data;

namespace AzerothWarsCSharp.Source.QuestObjectives
{
  public class ObjectiveEitherOf : Objective, IObjectiveParent, SubquestLogInfo
  {
    public ObjectiveEitherOf(IObjectiveParent parent, Objective questObjectiveA, Objective questObjectiveB) : base(parent)
    {
      Description = questObjectiveA.Description + " or " + questObjectiveB.Description;
      _questObjectiveA = questObjectiveA;
      _questObjectiveB = questObjectiveB;
      _questObjectiveA.ProgressChanged += OnChildQuestProgressChanged;
      _questObjectiveB.ProgressChanged += OnChildQuestProgressChanged;
    }

    public override Point Location
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public string Description { get; }

    private void OnChildQuestProgressChanged(object sender, ObjectiveEventArgs e)
    {
      if (_questObjectiveA.Progress == QuestProgress.Complete || _questObjectiveB.Progress == QuestProgress.Complete)
      {
        Progress = QuestProgress.Complete;
      }
    }

    private readonly Objective _questObjectiveA;
    private readonly Objective _questObjectiveB;
  }
}