using AzerothWarsCSharp.MacroTools;

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
        Value = faction.PrefixColor + faction.Name,
        Width = 0.08f,
      };
      Items.Add(nameAndIcon);

      var controlPointCount = new MultiboardItemData()
      {
        Value = faction.ControlPointCount.ToString(),
        Width = 0.02f,
      };
      Items.Add(controlPointCount);

      var incomeCount = new MultiboardItemData()
      {
        Value = faction.Income.ToString(),
        Width = 0.02f,
      };
      Items.Add(incomeCount);
    }
  }
}
