using System;
using static War3Api.Common;

namespace MacroTools.FactionSystem
{
  public sealed class LegendChangeUnitEventArgs : EventArgs
  {
    public unit PreviousUnit { get; }
    
    public Legend ChangingLegend { get; }

    public LegendChangeUnitEventArgs(Legend changingLegend, unit previousUnit)
    {
      PreviousUnit = previousUnit;
      ChangingLegend = changingLegend;
    }
  }
}