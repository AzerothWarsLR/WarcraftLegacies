using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public class LegendChangedOwnerEventArgs : EventArgs
  {
    public LegendChangedOwnerEventArgs(Legend legend, player? previousOwner)
    {
      Legend = legend;
      PreviousOwner = previousOwner;
    }

    public Legend Legend { get; }
    private player? PreviousOwner { get; }
  }
}