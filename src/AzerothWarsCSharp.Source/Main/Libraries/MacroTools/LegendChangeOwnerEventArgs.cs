using System;

namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
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