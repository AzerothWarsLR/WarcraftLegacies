using System;
using MacroTools.FactionSystem;

namespace MacroTools.ControlPointSystem;

public sealed class ControlPointTeamChangedEventArgs : EventArgs
{
  public ControlPoint ControlPoint { get; }

  public Team? FormerOwner { get; }

  public ControlPointTeamChangedEventArgs(ControlPoint controlPoint, Team? formerOwner)
  {
    ControlPoint = controlPoint;
    FormerOwner = formerOwner;
  }
}
