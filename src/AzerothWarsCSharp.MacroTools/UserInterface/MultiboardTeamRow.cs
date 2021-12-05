namespace AzerothWarsCSharp.MacroTools.UserInterface
{
  public sealed class MultiboardTeamRow : MultiboardRowData
  {
    private Team Team { get; set; }
    
    public MultiboardTeamRow(Team team)
    {
      Team = team;
      var item = new MultiboardItemData
      {
        Value = $"---------{team.Name}--------",
        Width = 0.12f,
      };
      AddItem(item);
    }
  }
}
