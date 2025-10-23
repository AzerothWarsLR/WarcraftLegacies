using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// Any unit with this effect increases its owner's income.
/// </summary>
public sealed class ProvidesIncome : UnitTypeTrait, IEffectOnUpgrade, IEffectOnConstruction, IEffectOnCreated
{
  private readonly int _income;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProvidesIncome"/> class.
  /// </summary>
  /// <param name="income">The amount of extra gold income the unit grants.</param>
  public ProvidesIncome(int income)
  {
    _income = income;
  }

  private void ApplyBuff()
  {
    var triggerUnit = @event.Unit;
    var buff = new IncomeBuff(triggerUnit, triggerUnit, _income);
    BuffSystem.Add(buff, StackBehaviour.Stack);
  }

  /// <inheritdoc />
  public void OnUpgrade()
  {
    ApplyBuff();
  }

  /// <inheritdoc />
  public void OnConstruction()
  {
    ApplyBuff();
  }

  /// <inheritdoc />
  public void OnCreated(unit createdUnit)
  {
    if (!createdUnit.IsUnitType(unittype.Structure))
    {
      ApplyBuff();
    }
  }
}
