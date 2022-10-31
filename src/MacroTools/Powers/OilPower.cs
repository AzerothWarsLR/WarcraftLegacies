using System;
using WarcraftLegacies.MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Powers
{
  public sealed class OilPower : Power
  {
    private static readonly PeriodicTrigger<OilIncomePeriodicAction> OilIncomePeriodicTrigger = new(1f);
    private float _amount;
    private float _income;
    private OilIncomePeriodicAction? _oilIncomePeriodicAction;

    public EventHandler<OilPower>? AmountChanged;

    public OilPower()
    {
      RefreshDescription();
    }

    /// <summary>
    /// The amount of oil the <see cref="OilPower"/> has.
    /// </summary>
    public float Amount
    {
      get => _amount;
      set
      {
        _amount = value;
        AmountChanged?.Invoke(this, this);
        RefreshDescription();
      }
    }

    /// <summary>
    /// The amount of oil the <see cref="OilPower"/> gains per second.
    /// </summary>
    public float Income
    {
      get => _income;
      set
      {
        _income = value;
        RefreshDescription();
      }
    }

    public override void OnAdd(player whichPlayer)
    {
      _oilIncomePeriodicAction = new OilIncomePeriodicAction(this);
      OilIncomePeriodicTrigger.Add(_oilIncomePeriodicAction);
    }

    public override void OnRemove(player whichPlayer)
    {
      if (_oilIncomePeriodicAction != null)
      {
        _oilIncomePeriodicAction.Active = false;
        _oilIncomePeriodicAction = null;
      }
    }

    private void RefreshDescription()
    {
      Description =
        $"You can harvest oil and use it to enhance your mechanical units.|n|cffffcc00Oil:|r {Amount}|n|cffffcc00Income:|r {Income}";
    }
  }
}