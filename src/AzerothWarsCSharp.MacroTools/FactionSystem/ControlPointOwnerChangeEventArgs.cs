using System;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
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