namespace AzerothWarsCSharp.MacroTools.UserInterface
{
  public sealed class MultiboardFactionRow : MultiboardRowData
  {
    private readonly MultiboardItemData _controlPointCount;
    private readonly MultiboardItemData _incomeCount;
    private readonly MultiboardItemData _nameAndIcon;

    public MultiboardFactionRow(Faction faction)
    {
      _nameAndIcon = new MultiboardItemData
      {
        Icon = faction.Icon,
        Value = faction.PrefixColor + faction.Name,
        Width = 0.08f
      };
      AddItem(_nameAndIcon);

      _controlPointCount = new MultiboardItemData
      {
        Value = faction.ControlPointCount.ToString(),
        Width = 0.02f
      };
      AddItem(_controlPointCount);

      _incomeCount = new MultiboardItemData
      {
        Value = faction.Income.ToString(),
        Width = 0.02f
      };
      AddItem(_incomeCount);

      faction.NameChanged += OnFactionNameChanged;
      faction.ControlPointCountChanged += OnFactionControlPointChanged;
      faction.IncomeChanged += OnFactionControlPointChanged;
      faction.IconChanged += OnFactionIconChanged;
      faction.PrefixColorChanged += OnFactionNameChanged;
    }

    private void OnFactionIconChanged(object sender, FactionEventArgs args)
    {
      _nameAndIcon.Icon = args.Faction.Icon;
    }
    
    private void OnFactionNameChanged(object sender, FactionEventArgs args)
    {
      _nameAndIcon.Value = args.Faction.PrefixColor + args.Faction.Name;
    }

    private void OnFactionControlPointChanged(object sender, FactionEventArgs args)
    {
      _controlPointCount.Value = args.Faction.ControlPointCount.ToString();
    }

    private void OnFactionIncomeChanged(object sender, FactionEventArgs args)
    {
      _incomeCount.Value = args.Faction.Income.ToString();
    }
  }
}