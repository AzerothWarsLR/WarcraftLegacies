//using AzerothWarsCSharp.Source.Libraries;
//using AzerothWarsCSharp.Source.Multiboard;

//namespace AzerothWarsCSharp.Source.UserInterface
//{
//  public sealed class MultiboardFactionRow : MultiboardRow
//  {
//    private static readonly int COLUMN_COUNT = 3;
//    private static readonly int COLUMN_FACTION = 0;
//    private static readonly int COLUMN_CP = 1;
//    private static readonly int COLUMN_INCOME = 2;

//    public MultiboardFactionRow(Faction trackedFaction)
//    {
//      Faction = trackedFaction;
//      for (int i = 0; i < COLUMN_COUNT; i++)
//      {
//        MultiboardItems.Add(new MultiboardItem());
//      }
//      SetValue(COLUMN_FACTION, trackedFaction.ColoredName);
//      SetValue(COLUMN_CP, trackedFaction.Income.ToString());
//      SetValue(COLUMN_INCOME, trackedFaction.ControlPoints.ToString());
//    }

//    public Faction Faction { get; }

//    private void OnFactionNameChange(object sender, FactionEventArgs e)
//    {
//      SetValue(COLUMN_FACTION, e.Faction.ColoredName);
//    }

//    private void OnFactionIncomeChange(object sender, FactionEventArgs e)
//    {
//      SetValue(COLUMN_CP, e.Faction.Income.ToString());
//    }

//    private void OnFactionControlPointsChange(object sender, FactionEventArgs e)
//    {
//      SetValue(COLUMN_INCOME, e.Faction.ControlPoints.ToString());
//    }
//  }
//}
