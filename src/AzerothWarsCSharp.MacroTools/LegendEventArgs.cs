using System;

namespace AzerothWarsCSharp.MacroTools
{
  public class LegendEventArgs : EventArgs
  {
    public Legend Legend { get; }
    
    public LegendEventArgs(Legend legend)
    {
      Legend = legend;
    }
  }
}