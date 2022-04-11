using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Factions
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