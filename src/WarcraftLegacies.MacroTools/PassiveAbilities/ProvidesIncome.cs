using WarcraftLegacies.MacroTools.Buffs;
using WarcraftLegacies.MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.PassiveAbilities
{
  /// <summary>
  /// Any unit with this effect increases its owner's income.
  /// </summary>
  public sealed class ProvidesIncome : PassiveAbility
  {
    private readonly int _income;

    public ProvidesIncome(int unitTypeId, int income) : base(unitTypeId)
    {
      _income = income;
    }

    private void ApplyBuff()
    {
      var triggerUnit = GetTriggerUnit();
      var buff = new IncomeBuff(triggerUnit, triggerUnit, _income);
      BuffSystem.Add(buff, StackBehaviour.Stack);
    }

    public override void OnUpgrade()
    {
      ApplyBuff();
    }

    public override void OnConstruction()
    {
      ApplyBuff();
    }
  }
}