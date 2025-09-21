using MacroTools.Extensions;
using MacroTools.Wrappers;
using WCSharp.Buffs;

namespace MacroTools.Buffs;

/// <summary>
/// Increases the owner's income by an amount, and destroys the unit when its trade center dies.
/// </summary>
public sealed class TraderBuff : PassiveBuff
{
  private readonly int _goldIncomeBonus;
  private readonly TriggerWrapper _tradeCenterDiesTrigger = new();

  public TraderBuff(unit caster, unit target, int goldIncomeBonus, unit tradeCenter) : base(
    caster, target)
  {
    _goldIncomeBonus = goldIncomeBonus;
    _tradeCenterDiesTrigger.RegisterUnitEvent(tradeCenter, unitevent.Death);
    _tradeCenterDiesTrigger.AddAction(TradeCenterDies);
    Duration = float.MaxValue;
  }

  private void TradeCenterDies()
  {
    Target.Kill();
  }

  public override void OnApply()
  {
    CastingPlayer.AddBonusIncome(_goldIncomeBonus);
  }

  public override void OnDispose()
  {
    CastingPlayer.AddBonusIncome(-_goldIncomeBonus);
    _tradeCenterDiesTrigger.Dispose();
  }
}
