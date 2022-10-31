using System;
using static War3Api.Common;

namespace MacroTools.ControlPointSystem
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