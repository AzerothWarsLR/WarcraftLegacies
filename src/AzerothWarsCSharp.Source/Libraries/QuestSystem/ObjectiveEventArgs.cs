using System;

namespace AzerothWarsCSharp.Source.Libraries
{
  public class ObjectiveEventArgs : EventArgs
  {
    public Objective Objective { get; }

    public ObjectiveEventArgs(Objective objective)
    {
      Objective = objective;
    }
  }
}
