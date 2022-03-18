using System;

namespace AzerothWarsCSharp.MacroTools
{
  public static class LegendEventArgs : EventArgs
  {
    public LegendEventArgs(Legend legend)
    {
      Legend = legend;
    }

    public Legend Legend { get; }
  }
}