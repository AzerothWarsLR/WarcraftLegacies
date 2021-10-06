using System;
using System.Collections.Generic;

namespace AzerothWarsCSharp.Source.Multiboard
{
  public class MultiboardRowChangedArgs : EventArgs
  {
    public MultiboardRow MultiboardRow { get; }

    public MultiboardRowChangedArgs(MultiboardRow multiboardRow)
    {
      MultiboardRow = multiboardRow;
    }
  }

  public abstract class MultiboardRow
  {
    public event EventHandler<MultiboardRowChangedArgs> ValueChanged;
    public event EventHandler<MultiboardRowChangedArgs> IconChanged;
    public event EventHandler<MultiboardRowChangedArgs> WidthChanged;
    public event EventHandler<MultiboardRowChangedArgs> VisibilityChanged;
    public List<MultiboardItem> MultiboardItems { get; } = new();

    public void SetValue(int column, string value)
    {
      MultiboardItems[column].Value = value;
      ValueChanged?.Invoke(this, new MultiboardRowChangedArgs(this));
    }

    public void SetIcon(int column, string icon)
    {
      MultiboardItems[column].Icon = icon;
      IconChanged?.Invoke(this, new MultiboardRowChangedArgs(this));
    }

    public void SetWidth(int column, int width)
    {
      MultiboardItems[column].Width = width;
      WidthChanged?.Invoke(this, new MultiboardRowChangedArgs(this));
    }
  }
}
