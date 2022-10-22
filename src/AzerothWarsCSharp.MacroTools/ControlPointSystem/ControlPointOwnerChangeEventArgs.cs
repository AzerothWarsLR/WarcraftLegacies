using System;

namespace AzerothWarsCSharp.MacroTools.ControlPointSystem
{
  public sealed class ControlPointOwnerChangeEventArgs : EventArgs
  {
    public ControlPointOwnerChangeEventArgs(ControlPoint controlPoint, player formerOwner)
    {
      ControlPoint = controlPoint;
      FormerOwner = formerOwner;
    }

    public ControlPoint ControlPoint { get; }
    public player FormerOwner { get; }
  }
}