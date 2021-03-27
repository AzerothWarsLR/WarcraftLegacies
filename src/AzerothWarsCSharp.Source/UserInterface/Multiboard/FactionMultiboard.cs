using AzerothWarsCSharp.Source.Libraries;
using System.Collections.Generic;
using static War3Api.Blizzard;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public class FactionMultiboard
  {
    private static readonly int COLUMN_COUNT = 3;
    private static readonly string TITLE = "Scoreboard";

    private static FactionMultiboard _instance;

    private multiboard _blzMultiboard;
    private List<MultiboardRow> _rows = new();

    public static void Initialize()
    {
      _instance = new FactionMultiboard();
      TriggerSleepAction(5);
      RenderInstance();
      Faction.FactionCreated += OnFactionCreated;
    }

    public FactionMultiboard()
    {
      foreach (Faction faction in Faction.All)
      {
        AddRow(new MultiboardFactionRow(faction));
      }
      foreach (Team team in Team.All)
      {
        AddRow(new MultiboardTeamRow(team));
      }
      Render();
    }

    private static void RenderInstance()
    {
      _instance.Render();
    }

    private void AddRow(MultiboardRow row)
    {
      _rows.Add(row);
      row.ValueChanged += OnRowValueChanged;
      row.IconChanged += OnRowIconChanged;
      row.VisibilityChanged += OnRowVisibilityChanged;
      row.WidthChanged += OnRowWidthChanged;
    }

    private void OnRowValueChanged(object sender, MultiboardRowChangedArgs e)
    {

    }

    private void OnRowIconChanged(object sender, MultiboardRowChangedArgs e)
    {

    }

    private void OnRowVisibilityChanged(object sender, MultiboardRowChangedArgs e)
    {

    }

    private void OnRowWidthChanged(object sender, MultiboardRowChangedArgs e)
    {

    }

    private void RenderRow(MultiboardRow row, int rowIndex)
    {
      var column = 0;
      foreach (var rowItem in row.MultiboardItems)
      {
        multiboarditem blzMultiboardItem = MultiboardGetItem(_blzMultiboard, rowIndex, column);
        MultiboardSetItemValue(blzMultiboardItem, rowItem.Value);
        MultiboardSetItemWidth(blzMultiboardItem, rowItem.Width);
        MultiboardSetItemStyle(blzMultiboardItem, rowItem != null, rowItem.Icon != null);
        column++;
      }
    }

    private void Render()
    {
      DestroyMultiboard(_blzMultiboard);
      _blzMultiboard = CreateMultiboardBJ(COLUMN_COUNT, 3, TITLE);
      MultiboardSetRowCount(_blzMultiboard, _rows.Count);
      var rowIndex = 0;
      foreach (MultiboardRow row in _rows)
      {
        RenderRow(row, rowIndex);
      }
    }

    private static void OnFactionCreated(object sender, FactionEventArgs e)
    {
      
    }

    private static void OnTeamCreated(object sender, TeamEventArgs e)
    {

    }
  }
}