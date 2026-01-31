using System;
using MacroTools.Quests;

namespace MacroTools.Factions;

public sealed class FactionQuestProgressChangedEventArgs : EventArgs
{
  public Faction Faction { get; }

  public QuestData Quest { get; }

  public QuestProgress FormerProgress { get; }

  public FactionQuestProgressChangedEventArgs(Faction faction, QuestData quest, QuestProgress formerProgress)
  {
    Faction = faction;
    Quest = quest;
    FormerProgress = formerProgress;
  }
}
