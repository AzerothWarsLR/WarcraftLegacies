using System;
using System.Collections.Generic;

namespace AzerothWarsCSharp.MacroTools.UserInterface
{
  public class MultiboardRowData
  {
    public event EventHandler<MultiboardRowDataEventArgs> ChildItemChanged;

    private readonly List<MultiboardItemData> _items = new();
    
    public int Width => _items.Count;

    public MultiboardItemData this[int key] => _items[key];

    /// <summary>
    /// Adds a multiboard item to this multiboard row.
    /// </summary>
    protected void AddItem(MultiboardItemData item)
    {
      _items.Add(item);
      item.PropertyChanged += OnChildItemChanged;
    }

    private void OnChildItemChanged(object sender, MultiboardItemDataEventArgs args)
    {
      ChildItemChanged?.Invoke(this, new MultiboardRowDataEventArgs(this));
    }
  }
}