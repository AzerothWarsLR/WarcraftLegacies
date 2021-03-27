using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public sealed class QuestObjectiveKillUnit : QuestObjective
  {
    public QuestObjectiveKillUnit(unit target)
    {
      if (target == null)
      {
        throw new ArgumentException("Target cannot be null");
      }
      throw new NotImplementedException();
    }
  }
}
