using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzerothWarsCSharp.Source.Libraries
{
  public class ObjectiveEventArgs : EventArgs
  {
    public Objective QuestObjective { get; }

    public ObjectiveEventArgs(Objective questObjective)
    {
      QuestObjective = questObjective;
    }
  }
}
