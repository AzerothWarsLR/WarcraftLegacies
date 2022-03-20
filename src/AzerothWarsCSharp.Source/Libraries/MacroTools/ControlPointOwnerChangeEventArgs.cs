using System;

namespace AzerothWarsCSharp.Source.Libraries.MacroTools
{
  public sealed class ControlPointOwnerChangeEventArgs : EventArgs
  {
    public ControlPoint ControlPoint { get; }
    public player FormerOwner { get; }

    public ControlPointOwnerChangeEventArgs(ControlPoint controlPoint, player formerOwner)
    {
      ControlPoint = controlPoint;
      FormerOwner = formerOwner;
    }
  }
}