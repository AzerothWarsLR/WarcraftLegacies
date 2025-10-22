using WCSharp.Events;

namespace WarcraftLegacies.Source.Powers;

public sealed class OilIncomePeriodicAction : IPeriodicAction
{
  private readonly OilPower _oilPower;

  public OilIncomePeriodicAction(OilPower oilPower)
  {
    _oilPower = oilPower;
  }

  public void Action()
  {
    _oilPower.Amount += _oilPower.Income;
  }

  public bool Active { get; set; } = true;
}
