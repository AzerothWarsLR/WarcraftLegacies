using System;

namespace AzerothWarsCSharp.MacroTools.UserInterface
{
  public class MultiboardRowDataEventArgs : EventArgs
  {
    public MultiboardRowData MultiboardRowData { get; set; }
    
    public MultiboardRowDataEventArgs(MultiboardRowData rowData)
    {
      MultiboardRowData = rowData;
    }
  }
}