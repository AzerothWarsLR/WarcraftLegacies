using System;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public class MultiboardItemDataEventArgs : EventArgs
  {
    public MultiboardItemData MultiboardItemData { get; set; }
    
    public MultiboardItemDataEventArgs(MultiboardItemData multiboardData)
    {
      MultiboardItemData = multiboardData;
    }
  }
}