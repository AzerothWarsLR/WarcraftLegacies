using System;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives;

public sealed class QuestProgressChangedEventArgs : EventArgs
{
  public QuestProgressChangedEventArgs(QuestData quest, QuestProgress formerProgress)
  {
    Quest = quest;
    FormerProgress = formerProgress;
  }

  public QuestData Quest { get; }
  public QuestProgress FormerProgress { get; }
}
