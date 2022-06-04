using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Buffs
{
  /// <summary>
  /// Increases the owner's income by an amount, and destroys the unit when its trade center dies.
  /// </summary>
  public sealed class TraderBuff : PassiveBuff
  {
    private readonly int _incomeBonus;
    private readonly TriggerWrapper _tradeCenterDiesTrigger = new();

    public TraderBuff(unit caster, unit target, int incomeBonus, unit tradeCenter) : base(caster, target)
    {
      _incomeBonus = incomeBonus;
      _tradeCenterDiesTrigger.RegisterUnitEvent(tradeCenter, EVENT_UNIT_DEATH);
      _tradeCenterDiesTrigger.AddAction(TradeCenterDies);
    }

    private void TradeCenterDies()
    {
      KillUnit(Target);
    }

    public override void OnApply()
    {
      CastingPlayer.AddBonusIncome(_incomeBonus);
    }

    public override void OnDispose()
    {
      CastingPlayer.AddBonusIncome(-_incomeBonus);
      _tradeCenterDiesTrigger.Dispose();
    }
  }
}