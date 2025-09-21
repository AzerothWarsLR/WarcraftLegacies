using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Buffs;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.FactionMechanics.Goblins;

/// <summary>
/// When trained, the <see cref="Trader"/> patrols between the originating point and a random trade destination.
/// If the training unit dies, the <see cref="Trader"/> dies too.
/// </summary>
public sealed class Trader : PassiveAbility, IEffectOnTrained
{
  private readonly int _goldIncomeBonus;
  private readonly Point[] _tradeTargets;

  public Trader(int unitTypeId, int goldIncomeBonus, IEnumerable<Point> tradeTargets) : base(unitTypeId)
  {
    _goldIncomeBonus = goldIncomeBonus;
    _tradeTargets = tradeTargets.ToArray();
  }

  public void OnTrained()
  {
    try
    {
      var tradingCenter = @event.Unit;
      var trainedUnit = @event.TrainedUnit;
      trainedUnit.IssueOrder("patrol", _tradeTargets[GetRandomInt(0, _tradeTargets.Length - 1)]);
      var incomeBuff =
        new TraderBuff(tradingCenter, trainedUnit, _goldIncomeBonus, tradingCenter);
      BuffSystem.Add(incomeBuff);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }
}
