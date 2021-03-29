using AzerothWarsCSharp.Source.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzerothWarsCSharp.Source
{
  public class ControlPointEventArgs
  {
    public ControlPointEventArgs(ControlPoint controlPoint)
    {
      ControlPoint = controlPoint;
    }

    public ControlPoint ControlPoint { get; }
  }
}
