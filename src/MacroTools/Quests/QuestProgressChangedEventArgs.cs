using System;

namespace MacroTools.Quests;

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
