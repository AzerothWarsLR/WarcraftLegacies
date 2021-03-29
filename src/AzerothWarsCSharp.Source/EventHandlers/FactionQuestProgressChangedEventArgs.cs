using AzerothWarsCSharp.Source.Libraries;
using System;

namespace AzerothWarsCSharp.Source
{
  public class FactionQuestProgressChangedEventArgs : EventArgs
  {
    public Faction Faction;
    public QuestEx QuestEx;
    public QuestProgress PreviousProgress;
  }
}
