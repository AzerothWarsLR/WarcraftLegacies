using System;

namespace AzerothWarsCSharp.MacroTools
{
  public class QuestObjectiveEventArgs : EventArgs
  {
    public QuestObjective Objective { get; private set; }
    
    public QuestObjectiveEventArgs(QuestObjective objective)
    {
      Objective = objective;
    }
  }
}