using System;
using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public abstract class MultiboardEx
  {
    private readonly multiboard _multiboard = CreateMultiboard();

    private readonly List<MultiboardRowData> _multiboardRows = new();
    
    public bool Display
    {
      get => IsMultiboardDisplayed(_multiboard);
      set => MultiboardDisplay(_multiboard, value);
    }

    public bool Minimized
    {
      get => IsMultiboardMinimized(_multiboard);
      set => MultiboardMinimize(_multiboard, value);
    }

    public string Title
    {
      get => MultiboardGetTitleText(_multiboard);
      set => MultiboardSetTitleText(_multiboard, value);
    }

    public void SetTitleTextColor(int red, int green, int blue, int alpha)
    {
      MultiboardSetTitleTextColor(_multiboard, red, green, blue, alpha);
    }

    public int RowCount
    {
      get => MultiboardGetRowCount(_multiboard);
      private set => MultiboardSetRowCount(_multiboard, value);
    }

    public int ColumnCount
    {
      get => MultiboardGetColumnCount(_multiboard);
      set => MultiboardSetColumnCount(_multiboard, value);
    }

    public List<MultiboardRowData> GetRows()
    {
      return _multiboardRows.ToList();
    }
    
    public void Clear()
    {
      _multiboardRows.Clear();
      MultiboardClear(_multiboard);
    }

    protected void AddRow(MultiboardRowData row)
    {
      _multiboardRows.Add(row);
      RowCount++;
      RenderRow(row, RowCount-1);
      row.ChildItemChanged += OnChildRowChanged;
    }

    /// <summary>
    /// Takes data from a <see cref="MultiboardRowData"/> and renders it in the visible Multiboard.
    /// Can also be used to re-render an existing row.
    /// </summary>
    private void RenderRow(MultiboardRowData row, int rowIndex)
    {
      for (var i = 0; i < ColumnCount && i < row.Width; i++)
      {
        var multiboardItemData = row[i];
        var multiboardItem = MultiboardGetItem(_multiboard, rowIndex, i);
        MultiboardSetItemValue(multiboardItem, multiboardItemData.Value);
        MultiboardSetItemValueColor(multiboardItem, multiboardItemData.Color.R, multiboardItemData.Color.G,
          multiboardItemData.Color.B, multiboardItemData.Color.A);
        MultiboardSetItemWidth(multiboardItem, multiboardItemData.Width);
        var showIcon = multiboardItemData.Icon != null;
        var showValue = multiboardItemData.Value != null;
        MultiboardSetItemStyle(multiboardItem, showValue, showIcon);
        if (showIcon)
        {
          MultiboardSetItemIcon(multiboardItem, @$"ReplaceableTextures\CommandButtons\BTN{multiboardItemData.Icon}.blp");
        }
      }
    }
    
    private void OnChildRowChanged(object sender, MultiboardRowDataEventArgs args)
    {
      var index = _multiboardRows.FindIndex(a => a == args.MultiboardRowData);
      RenderRow(args.MultiboardRowData, index);
    }
    
    protected MultiboardEx()
    {
      MultiboardSetItemsStyle(_multiboard, false, false);
      MultiboardSetItemsWidth(_multiboard, 0f);
    }

    ~MultiboardEx()
    {
      DestroyMultiboard(_multiboard);
    }
  }
}