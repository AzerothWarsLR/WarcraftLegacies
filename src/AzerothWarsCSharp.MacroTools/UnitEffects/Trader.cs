using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.UnitEffects
{
  /// <summary>
  /// When trained, the <see cref="Trader"/> patrols between the originating point and a random trade destination.
  /// If the training unit dies, the <see cref="Trader"/> dies too.
  /// </summary>
  public sealed class Trader : UnitEffect
  {
    private readonly int _incomeBonus;
    private readonly Point[] _tradeTargets;

    public Trader(int unitTypeId, int incomeBonus, IEnumerable<Point> tradeTargets) : base(unitTypeId)
    {
      _incomeBonus = incomeBonus;
      _tradeTargets = tradeTargets.ToArray();
    }

    public override void OnCreated()
    {
      var tradingCenter = GetTrainedUnit();
      var trainedUnit = GetTrainedUnit();
      trainedUnit.IssueOrder("patrol", _tradeTargets[GetRandomInt(0, _tradeTargets.Length - 1)]);
      var incomeBuff = new TraderBuff(tradingCenter, trainedUnit, _incomeBonus, tradingCenter);
      BuffSystem.Add(incomeBuff);
    }
  }
}