using AzerothWarsCSharp.Source.Libraries.MacroSystem;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public sealed class MultiboardFactionRow : MultiboardRowData
  {
    public Faction Faction { get; }

    public MultiboardFactionRow(Faction faction)
    {
      Faction = faction;

      var nameAndIcon = new MultiboardItemData
      {
        Icon = faction.Icon,
        Value = faction.Name,
        Width = 0.08f,
        ShowValue = true,
        ShowIcon = true,
      };
      Items.Add(nameAndIcon);

      var controlPointCount = new MultiboardItemData()
      {
        Icon = faction.Icon,
        Value = faction.ControlPointCount.ToString(),
        Width = 0.02f,
        ShowValue = true,
        ShowIcon = false,
      };
      Items.Add(controlPointCount);

      var incomeCount = new MultiboardItemData()
      {
        Value = faction.Income.ToString(),
        Width = 0.02f,
        ShowValue = true,
        ShowIcon = false,
      };
      Items.Add(incomeCount);
    }
  }
}
