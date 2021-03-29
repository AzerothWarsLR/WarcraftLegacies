using AzerothWarsCSharp.Source.Libraries;
using System;

namespace AzerothWarsCSharp.Source
{
  public class FactionQuestAddedEventArgs : EventArgs
  {
    public Faction Faction;
    public QuestEx QuestEx;
  }
}
