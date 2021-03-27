using System;
using System.Collections.Generic;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public class MultiboardRowChangedArgs : EventArgs
  {
    public MultiboardRow MultiboardRow { get; }

    public MultiboardRowChangedArgs(MultiboardRow multiboardRow)
    {
      MultiboardRow = multiboardRow;
    }
  }

  public class MultiboardRow
  {
    public EventHandler<MultiboardRowChangedArgs> ValueChanged { get; set; }
    public EventHandler<MultiboardRowChangedArgs> IconChanged { get; set; }
    public EventHandler<MultiboardRowChangedArgs> WidthChanged { get; set; }
    public EventHandler<MultiboardRowChangedArgs> VisibilityChanged { get; set; }
    public List<MultiboardItem> MultiboardItems { get; }

    public void SetValue(int column, string value)
    {
      ValueChanged?.Invoke(this, new MultiboardRowChangedArgs(this));
    }

    public void SetIcon(int column, string icon)
    {
      IconChanged?.Invoke(this, new MultiboardRowChangedArgs(this));
    }

    public void SetWidth(int column, int width)
    {
      WidthChanged?.Invoke(this, new MultiboardRowChangedArgs(this));
    }
  }
}
