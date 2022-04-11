using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Factions
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