using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public class ControlPoint
  {
    public static List<ControlPoint> All { get; } = new();

    public static event EventHandler<ControlPointEventArgs> Created;
    public static event EventHandler<ControlPointEventArgs> Destroyed;

    ~ControlPoint()
    {
      Destroyed?.Invoke(this, new ControlPointEventArgs(this));
    }

    public unit Unit
    {
      get; set;
    }
  }
}
