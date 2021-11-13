//using AzerothWarsCSharp.Source.Libraries;
//using AzerothWarsCSharp.Source.Multiboard;

//namespace AzerothWarsCSharp.Source.UserInterface
//{
//  public sealed class MultiboardTeamRow : MultiboardRow
//  {
//    private static readonly int COLUMN_COUNT = 1;
//    private static readonly int COLUMN_TEAM = 0;
//    private static readonly float WIDTH_TEAM = 0.12f;

//    public MultiboardTeamRow(Team trackedTeam)
//    {
//      Team = trackedTeam;
//      trackedTeam.ChangesSize += OnTeamChangeSize;
//      for (int i = 0; i < COLUMN_COUNT; i++)
//      {
//        MultiboardItems.Add(new MultiboardItem());
//      }
//      SetValue(COLUMN_TEAM, $"----{trackedTeam.Name}----");
//    }

//    public Team Team { get; }

//    private void OnTeamNameChange(object sender, TeamEventArgs e)
//    {
//      SetValue(COLUMN_TEAM, e.Team.Name);
//    }

//    private void OnTeamChangeSize(object sender, TeamEventArgs e)
//    {

//    }
//  }
//}
