using System;
using static War3Api.Common;

namespace MacroTools.LegendSystem
{
  public sealed class LegendChangeOwnerEventArgs : EventArgs
  {
    public Legend Legend { get; }
    public player? PreviousOwner { get; }
    
    public LegendChangeOwnerEventArgs(Legend legend, player? previousOwner = null)
    {
      Legend = legend;
      PreviousOwner = previousOwner;
    }
  }
}