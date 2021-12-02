using AzerothWarsCSharp.Source.Libraries.MacroSystem;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public sealed class MultiboardTeamRow : MultiboardRowData
  {
    public Team Team { get; set; }
    
    public MultiboardTeamRow(Team team)
    {
      Team = team;
      var item = new MultiboardItemData
      {
        Value = $"---------{team.Name}--------",
        Width = 0.12f,
      };
      Items.Add(item);
    }
  }
}
