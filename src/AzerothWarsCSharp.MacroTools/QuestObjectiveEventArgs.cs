using System;

namespace AzerothWarsCSharp.MacroTools
{
  public class QuestObjectiveEventArgs : EventArgs
  {
    public QuestObjectiveEventArgs(QuestObjective objective)
    {
      Objective = objective;
    }

    public QuestObjective Objective { get; }
  }
}