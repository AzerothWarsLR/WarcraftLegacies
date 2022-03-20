using System;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public class LegendChangeOwnerEventArgs : EventArgs
  {
    public Legend Legend { get; }
    public player? PreviousOwner { get; }
    
    public LegendChangeOwnerEventArgs(Legend legend, player previousOwner)
    {
      Legend = legend;
      PreviousOwner = previousOwner;
    }
  }
}