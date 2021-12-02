using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public abstract class MultiboardEx
  {
    private readonly multiboard _multiboard = CreateMultiboard();

    protected readonly List<MultiboardRowData> MultiboardRows = new();
    
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
      set => MultiboardSetRowCount(_multiboard, value);
    }

    public int ColumnCount
    {
      get => MultiboardGetColumnCount(_multiboard);
      set => MultiboardSetColumnCount(_multiboard, value);
    }

    public List<MultiboardRowData> GetRows()
    {
      return MultiboardRows.ToList();
    }
    
    public void Clear()
    {
      MultiboardRows.Clear();
      MultiboardClear(_multiboard);
    }

    protected void AddRow(MultiboardRowData row)
    {
      MultiboardRows.Add(row);
      RowCount++;
      for (var i = 0; i < ColumnCount; i++)
      {
        var multiboardItemData = row.Items[i];
        var multiboardItem = MultiboardGetItem(_multiboard, RowCount, i);
        MultiboardSetItemStyle(multiboardItem, multiboardItemData.ShowValue, multiboardItemData.ShowIcon);
        MultiboardSetItemValue(multiboardItem, multiboardItemData.Value);
        MultiboardSetItemValueColor(multiboardItem, multiboardItemData.Color.R, multiboardItemData.Color.G,
          multiboardItemData.Color.B, multiboardItemData.Color.A);
        MultiboardSetItemWidth(multiboardItem, multiboardItemData.Width);
        MultiboardSetItemIcon(multiboardItem, multiboardItemData.Icon);
      }
    }

    protected MultiboardEx()
    {
      
    }

    ~MultiboardEx()
    {
      DestroyMultiboard(_multiboard);
    }
  }
}